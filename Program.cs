using Microsoft.Win32;

namespace MKLinkHelper_WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.

			// Check Windows theme (light or dark)
			// this doesn't work for some reason --> Application.SetColorMode(SystemColorMode.System);
			using var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
			var value = key?.GetValue("AppsUseLightTheme");

            if (value is int intValue && intValue == 0)
            {
                Application.SetColorMode(SystemColorMode.Dark);
            }

			ApplicationConfiguration.Initialize();
            Application.Run(new Form1(args));
        }
    }
}