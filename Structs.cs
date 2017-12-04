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
using System.Collections.Generic;
using System.Drawing;
using LNPcmd;

namespace SharpLNP
{
	/// <summary>
	/// Description of Structs.
	/// </summary>
	public static class Structs{
		//public const Dictionary<LEDGroupType> LEDGroupTypes 
		
		public class Device{
			public LNP LNPDevice;
			Color[][] led;
			public int[] LEDCount = new int[2];
			
			
			public Device(LNP lnp){
				this.LNPDevice = lnp;
				LEDCount[0] = 50;
				LEDCount[1] = 50;
				led = new Color[Program.ChannelCount][];
				for(int i=0;i<led.Length;i++){
					EmptyLEDColor(i);
				}
			}

			public Color[] GetChannelLED(int channel){
				if(channel<0 || channel>=led.Length){
					throw new IndexOutOfRangeException(string.Format("Channel Index is Out of Available Channel! Available max Channel {0}, but selected index is {1}", Program.ChannelCount, channel));
				}
				
				return led[channel];
			}
			
			public void EmptyLEDColor(int channel){
				if(channel<0 || channel>=led.Length){
					throw new IndexOutOfRangeException(string.Format("Channel Index is Out of Available Channel! Available max Channel {0}, but selected index is {1}", Program.ChannelCount, channel));
				}
				led[channel] = new Color[LEDCount[channel]];
				for(int i=0;i<led[channel].Length;i++){
					led[channel][i] = Color.Black;
				}
			}
			
			public override string ToString(){
				return string.Format("{0} ({1})", LNPDevice.GetDescription(), LNPDevice.GetLNPDeviceVer());
			}
			
		}
		
		
		
		//Pattern -> Animation Frame[] -> LED[]
		public class Pattern{
			public string name = ""; //pattern name
			public int device = -1; //device
			public int channel = 0; //device channel
			public List<Color[]> led; //leds
		}
		
		
		public class LEDGroup{
			public long id = 0;
			public LEDGroupType type = LEDGroupTypes.SP;
			public int startindex = 0;
			public int device = 0;
			public int channel = 0;
			public int audioStyle = 1;
			public int audioChannel = 0;
			public Color[] audioStyleEfxColor = new Color[]{Color.Green,Color.Yellow, Color.Orange, Color.Red};
			
			
			public override string ToString(){
				if(id == -1 && device == -1 && channel == -1){
					return string.Format("Ungroup LED");
				}
				
				if(type.ledcount>1){
					return string.Format("{0} ([{1}:{2}]LED {3} -> {4})", type.name, device, channel, startindex+1, startindex+type.ledcount);
				}
				
				return string.Format("{0} ([{1}:{2}]LED {3})", type.name, device, channel, startindex+1);
				
			}
 
		}
		
		
		public struct LEDGroupType{
			public string name;
			public int ledcount;
			
			
			public override string ToString()
			{
				return string.Format("{0}", name);
			}
 
		}
		
		public static List<string> LEDAudioStyles = new List<string>(){"Off","Audio Loudness", "Audio Loudness + Animation Pattern", "VU Meter", "VU Meter(Dual)"};
		

		
		public static class LEDGroupTypes{
			public static LEDGroupType None = new LEDGroupType{name="None", ledcount=0};
			public static LEDGroupType SP = new LEDGroupType{name="RGB SP", ledcount=1};
			public static LEDGroupType HD = new LEDGroupType{name="RGB HD", ledcount=12};
			public static LEDGroupType LL = new LEDGroupType{name="RGB LL", ledcount=16};
			public static LEDGroupType ML = new LEDGroupType{name="RGB ML", ledcount=4};
			public static LEDGroupType LEDPro = new LEDGroupType{name="LED Strip", ledcount=10};
			
			public static List<LEDGroupType> GetTypeList = new List<LEDGroupType>(){None,SP,HD,LL,ML, LEDPro};
			
			public static int GetLEDTypeIndex(LEDGroupType type){
				int index = GetTypeList.IndexOf(type);
				if(index == -1){
					index = 0;
				}
				return index;
			}
			
			public static LEDGroupType GetLEDType(int index){
				if(index<0 || index>=GetTypeList.Count){
					return None;
				}
				return GetTypeList[index];
			}
		}
		
		public struct DataItem{
			public int index;
			public string Name;
			
			public override string ToString(){
				return string.Format("{0}", Name);
			}

		}
		
		
		public struct HSV{
			public double h;
			public double s;
			public double v;
		}
		
		public struct RGB{
			public double r;
			public double g;
			public double b;
		}
	}
}
