﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAdvancedFirewallApi.Utils
{
	public static class StringUtils
	{
		public static bool IsPath(this string value)
		{
			if (value == null)
			{
				return false;
			}
			return value.Contains(Path.AltDirectorySeparatorChar) || value.Contains(Path.DirectorySeparatorChar);
		}

		public static string GetFileNameOfPath(this string value)
		{
			if (value == null)
			{
				return null;
			}

			if (value.IsPath())
			{
				return Path.GetFileName(value);
			}

			return value;
		}
	}
}
