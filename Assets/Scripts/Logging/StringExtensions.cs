using System;
using System.Globalization;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logging {
	public static class StringExtensions {
		public static string Bold(this string str) => "<b>" + str + "</b>";
		public static string Color(this string str,string clr) => $"<color={clr}>{str}</color>";
		public static string Color(this string str, Color clr) => $"<color=#{ColorUtility.ToHtmlStringRGB(clr)}>{str}</color>";
		public static string Italic(this string str) => "<i>" + str + "</i>";
		public static string Size(this string str, int size) => $"<size={size}>{str}</size>";

		public static string ToStringFormat(this object obj) {
			return obj switch {
				null => "Null",
				IToString ls => ls.ToString(),
				Object go => go.name,
				IFormattable formattable => formattable.ToString((string)null, (IFormatProvider)CultureInfo.InvariantCulture),
				_ => obj.ToString()
			};
		}
	}
	
	public interface IToString {
		public string ToString();
	}
}