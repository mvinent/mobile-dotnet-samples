﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CartoMobileSample
{
	static class Extensions
	{
		public static string[] ToStringArray(this List<Type> list)
		{
			string[] sampleNames = new string[list.Count];

			for (int i = 0; i < list.Count; i++)
			{
				sampleNames[i] = list[i].Name;
			}

			return sampleNames;
		}

		public static string Description(this Type type)
		{
			try
			{
				IEnumerable<System.Reflection.CustomAttributeData> list = typeof(CartoVisJSONActivity).CustomAttributes;
				string description = (string)list.ToList()[1].NamedArguments[0].TypedValue.Value;

				return description;
			} catch {
				return "";
			}
		}
	}
}

