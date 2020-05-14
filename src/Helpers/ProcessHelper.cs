// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.05.03
// Modified: 2020.05.14

using System;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SKit.Common.Helpers
{
#pragma warning disable CA1031
#pragma warning disable CA1051

    // https://gist.github.com/AlexMAS/276eed492bc989e13dcce7c78b9e179d
    public static class ProcessHelper
    {
        public static async Task<ProcessResult> ExecuteShellCommand(string command, string arguments, int timeout)
        {
            var result = new ProcessResult();

            using (var process = new Process())
            {
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                var outputBuilder = new StringBuilder();
                var outputCloseEvent = new TaskCompletionSource<bool>();

                process.OutputDataReceived += (s, e) =>
                                                {
                                                // The output stream has been closed i.e. the process has terminated
                                                if (e.Data == null)
                                                    {
                                                        outputCloseEvent.SetResult(true);
                                                    }
                                                    else
                                                    {
                                                        outputBuilder.AppendLine(e.Data);
                                                    }
                                                };

                var errorBuilder = new StringBuilder();
                var errorCloseEvent = new TaskCompletionSource<bool>();

                process.ErrorDataReceived += (s, e) =>
                                                {
                                                // The error stream has been closed i.e. the process has terminated
                                                if (e.Data == null)
                                                    {
                                                        errorCloseEvent.SetResult(true);
                                                    }
                                                    else
                                                    {
                                                        errorBuilder.AppendLine(e.Data);
                                                    }
                                                };

                bool isStarted;

                try
                {
                    isStarted = process.Start();
                }
                catch (Exception error)
                {
                    // Usually it occurs when an executable file is not found or is not executable

                    result.Completed = true;
                    result.ExitCode = -1;
                    result.Output = error.Message;

                    isStarted = false;
                }

                if (isStarted)
                {
                    // Reads the output stream first and then waits because deadlocks are possible
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    // Creates task to wait for process exit using timeout
                    var waitForExit = WaitForExitAsync(process, timeout);

                    // Create task to wait for process exit and closing all output streams
                    var processTask = Task.WhenAll(waitForExit, outputCloseEvent.Task, errorCloseEvent.Task);

                    // Waits process completion and then checks it was not completed by timeout
                    if (await Task.WhenAny(Task.Delay(timeout), processTask).ConfigureAwait(false) == processTask && waitForExit.Result)
                    {
                        result.Completed = true;
                        result.ExitCode = process.ExitCode;

                        // Adds process output if it was completed with error
                        if (process.ExitCode != 0)
                        {
                            result.Output = $"{outputBuilder}{errorBuilder}";
                        }
                    }
                    else
                    {
                        try
                        {
                            // Kill hung process
                            process.Kill();
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return result;
        }

        private static Task<bool> WaitForExitAsync(Process process, int timeout)
        {
            return Task.Run(() => process.WaitForExit(timeout));
        }
    }

    public class ProcessResult
    {
        public bool Completed;
        public int? ExitCode;
        public string Output;
    }

}

// В чем смысл TaskCompletionSource<T> и когда его лучше использовать?
// https://ru.stackoverflow.com/questions/780270/%D0%92-%D1%87%D0%B5%D0%BC-%D1%81%D0%BC%D1%8B%D1%81%D0%BB-taskcompletionsourcet-%D0%B8-%D0%BA%D0%BE%D0%B3%D0%B4%D0%B0-%D0%B5%D0%B3%D0%BE-%D0%BB%D1%83%D1%87%D1%88%D0%B5-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D1%8C

//Task ExecuteProcess(string path)
//{
//    var p = new Process() { EnableRaisingEvents = true, StartInfo = { FileName = path } };
//    var tcs = new TaskCompletionSource<bool>();
//    p.Exited += (sender, args) => { tcs.SetResult(true); p.Dispose(); };
//    // запуск выгружаем на пул потоков, потому что он медленный
//    Task.Run(() => p.Start());
//    return tcs.Task;
//}