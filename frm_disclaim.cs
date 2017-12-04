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
using System.Windows.Forms;

namespace SharpLNP
{
	/// <summary>
	/// Description of frm_disclaim.
	/// </summary>
	public partial class frm_disclaim : Form{
		public frm_disclaim(){
			
			InitializeComponent();
			richTextBox1.Rtf = @"{\rtf1\ansi \fs30 \b Sharp LNP(#LNP)\b0
\line \fs18
This software is under the license terms of MIT license.
\line
Which is mean, this software is free software, without any cost and comes without any warranty!
\line
-------------------------------------------------
\line
Copyright (c) 2017 icebahamut (icebahamut[at]hotmail[dot]com)
\line
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\line
\line
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\line
\line
THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
\line
-------------------------------------------------
}
";
		}
		
		
		bool agree = false;
		void Button1Click(object sender, EventArgs e){
			agree = true;
			SettingConfUtils.SetConfig("ShowLicenseStartup", checkBox1.Checked);
			Close();
		}
		void Button2Click(object sender, EventArgs e){
			agree = false;
			Environment.Exit(0);
		}
		void Frm_disclaimFormClosing(object sender, FormClosingEventArgs e){
			if(!agree){
				Environment.Exit(0);
			}else{
				SettingConfUtils.SetConfig("ShowLicenseStartup", checkBox1.Checked);
			}
		}
	}
}
