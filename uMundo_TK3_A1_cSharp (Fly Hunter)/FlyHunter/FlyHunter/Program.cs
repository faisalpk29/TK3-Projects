using System;
using System.Windows.Forms;

namespace FlyHunter
{
	using System.Runtime.InteropServices;

	static class Program
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern void SetDllDirectory(string lpPathName);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Set the DLL directory as per the OS version.
			if (System.Environment.Is64BitProcess)
			{
				SetDllDirectory(System.IO.Directory.GetCurrentDirectory() + "\\umundo\\bindings\\csharp64");
			}
			else
			{
				SetDllDirectory(System.IO.Directory.GetCurrentDirectory() + "\\umundo\\bindings\\csharp");
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form2());
		}
	}
}
