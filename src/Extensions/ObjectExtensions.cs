using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common.Extensions
{
    public static class ObjectExtensions
    {
		public static Dictionary<string, string> GetPropertiesWithValues(this object obj)
		{
			var props = new Dictionary<string, string>();
			if (obj == null)
				return props;

			var type = obj.GetType();
			foreach (var prop in type.GetProperties())
			{
				var val = prop.GetValue(obj, Array.Empty<object>());
				var valStr = val == null ? "" : val.ToString();
				props.Add(prop.Name, valStr);
			}

			return props;
		}
	}
}
