﻿using System.Windows.Forms;
using ReClassNET.Gui;

namespace ReClassNET.Logger
{
	class GuiLogger : BaseLogger
	{
		private LogForm form;

		public LogLevel Level { get; set; } = LogLevel.Warning;

		public GuiLogger()
		{
			form = new LogForm();
			form.FormClosing += delegate (object sender, FormClosingEventArgs e)
			{
				form.Clear();

				form.Hide();

				e.Cancel = true;
			};

			NewLogEntry += OnNewLogEntry;
		}

		private void OnNewLogEntry(LogLevel level, string message)
		{
			if (level < Level)
			{
				return;
			}

			ShowForm();

			form.Add(level, message);
		}

		public void ShowForm()
		{
			if (!form.Visible)
			{
				form.Show();
			}
		}
	}
}
