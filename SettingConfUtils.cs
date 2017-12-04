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
using System.Configuration;

namespace SharpLNP
{
	/// <summary>
	/// Description of SettingConfUtils.
	/// </summary>
	public static class SettingConfUtils{
		
		public static void SetConfig(string settingkey, byte[] settingvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			
			if(setting[settingkey] == null){
				setting.Add(settingkey, Convert.ToBase64String(settingvalue));
			}else{
				setting[settingkey].Value = Convert.ToBase64String(settingvalue);
			}
			conf.Save();
		}
		
		public static void SetConfig(string settingkey, string settingvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			
			if(setting[settingkey] == null){
				setting.Add(settingkey, settingvalue);
			}else{
				setting[settingkey].Value = settingvalue;
			}
			conf.Save();
		}
		
		public static void SetConfig(string settingkey, bool settingvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				setting.Add(settingkey, settingvalue.ToString());
			}else{
				setting[settingkey].Value = settingvalue.ToString();
			}
			
			conf.Save();
		}
		
		public static void SetConfig(string settingkey, int settingvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				setting.Add(settingkey, ""+settingvalue);
			}else{
				setting[settingkey].Value = ""+settingvalue;
			}
			
			conf.Save();
			
		}
		
		public static void SetConfig(string settingkey, long settingvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				setting.Add(settingkey, ""+settingvalue);
			}else{
				setting[settingkey].Value = ""+settingvalue;
			}
			
			conf.Save();
		}
		
		public static byte[] GetConfig(string settingkey){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				return null;
			}
			
			return Convert.FromBase64String(setting[settingkey].Value);
		}
		
		public static bool GetConfig(string settingkey, bool defvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				return defvalue;
			}
			
			bool value = defvalue;
			bool.TryParse(setting[settingkey].Value, out value);
			return value;
		}
		
		public static int GetConfig(string settingkey, int defvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				return defvalue;
			}
			
			int value = defvalue;
			int.TryParse(setting[settingkey].Value, out value);
			return value;
		}
		
		public static long GetConfig(string settingkey, long defvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				return defvalue;
			}
			
			long value = defvalue;
			long.TryParse(setting[settingkey].Value, out value);
			return value;
			
			
			
		}
		
		public static string GetConfig(string settingkey, string defvalue){
			var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var setting = conf.AppSettings.Settings;
			if(setting[settingkey] == null){
				return defvalue;
			}
			return setting[settingkey].Value;
			
			
		}
	}
}
