using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BiDomoDotNet.Helpers
{
	public static class DataHelper
	{
		public static string WriteAsCsv<T>(this IEnumerable<T> listToWrite, string delimeter, bool includeHeaders = false)
		{
			StringBuilder sb = new StringBuilder();

			IList<PropertyInfo> properties = typeof(T).GetProperties();

			if (includeHeaders)
			{
				foreach (PropertyInfo property in properties)
				{
					sb.Append(property.Name).Append(",");
				}
				sb.Remove(sb.Length - 1, 1).AppendLine();
			}

			foreach (T obj in listToWrite)
			{
				T row = obj;

				var line = String.Join(delimeter, properties.Select(x => CleanValuesForCsv(x.GetValue(row, null), delimeter)));

				sb.AppendLine(line);
			}

			return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
		}

		public static string CleanValuesForCsv(object value, string delimeter)
		{
			string output;
			if (value == null)
				return "";
			if (value is DateTime)
			{
				output = ((DateTime)value).ToString();
			}
			else
			{
				output = value.ToString();
			}

			if (output.Contains(delimeter) || output.Contains("\""))
			{
				output = '"' + output.Replace("\"", "\"\"") + '"';
			}


			output = output.Replace("\n", " ").Replace("\r", "").Replace(",", "");

			return output;
		}
	}
}
