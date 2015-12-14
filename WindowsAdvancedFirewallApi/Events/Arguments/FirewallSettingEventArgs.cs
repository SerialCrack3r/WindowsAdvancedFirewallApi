﻿using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsAdvancedFirewallApi.Events.Objects;
using WindowsAdvancedFirewallApi.Utils;

namespace WindowsAdvancedFirewallApi.Events.Arguments
{
	public class FirewallSettingEventArgs : FirewallEventArgs<FirewallSetting>
	{
		private static Logger LOG = LogManager.GetCurrentClassLogger();

		public FirewallSetting Setting
		{
			get { return Data; }
			protected set { Data = value; }
		}

		internal FirewallSettingEventArgs(EntryWrittenEventArgs eventArgs) : base(eventArgs)
		{
			SetAttributes();
		}

		protected void SetAttributes()
		{
			SetAttributes(0, 5, 6, 7);

			LOG.Debug("ReplacementStrings: {0}", string.Join(",", FirewallLogEventArgs.Entry.ReplacementStrings));

			Setting.Type = EnumUtils.ParseStringValue(FirewallLogEventArgs.Entry.ReplacementStrings[1], FirewallSetting.SettingType.Unkown);
			Setting.ValueSize = FirewallLogEventArgs.Entry.ReplacementStrings[2].ParseInteger(0);
			Setting.Value = EnumUtils.ParseStringValue(FirewallLogEventArgs.Entry.ReplacementStrings[3], FirewallSetting.SettingValue.Unkown);
			Setting.ValueString = FirewallLogEventArgs.Entry.ReplacementStrings[4];
		}
	}
}