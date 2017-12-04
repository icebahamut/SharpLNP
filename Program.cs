 /*
Copyright (c) 2017 icebahamut (icebahamut[at]hotmail[dot]com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;


namespace SharpLNP
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program{
		static Mutex mutex = new Mutex(true,Assembly.GetExecutingAssembly().GetType().GUID.ToString());
		
		public static int ChannelCount = 2;

		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args){
			if(mutex.WaitOne(TimeSpan.Zero,true)){
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				if(SettingConfUtils.GetConfig("ShowLicenseStartup",true)){
					Application.Run(new frm_disclaim());
				}
				
				Application.Run(new MainForm());
				mutex.ReleaseMutex();
			}else{
				MessageBox.Show("SharpLNP already running!");
			}
			
		}
		
		
		
		
	}
}
