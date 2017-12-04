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
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.Streams;

namespace SharpLNP
{
	/// <summary>
	/// Description of AudioCapture.
	/// </summary>
	public class AudioCapture:IDisposable{
		public delegate void SampleData(float left, float right);
		public event SampleData OnSampleCaptured;
		
		MMDevice mmdevice;
		WasapiCapture capture;
		IWaveSource waveSource;
		//float[] sample = new float[2];
		public AudioCapture(AudioDevice device){
			this.mmdevice = device.device;
		}
		
		public void Dispose(){
			StopCapture();
		}
		
		public static List<AudioDevice> ListDevice(){
			List<AudioDevice> devices = new List<AudioDevice>();

			using (var deviceEnumerator = new MMDeviceEnumerator())
				
				using (var deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active)){
				foreach (var device in deviceCollection){
					devices.Add(new AudioDevice(device));
				}
			}
			return devices;
		}
		
		public class AudioDevice{
			public MMDevice device;
			public AudioDevice(MMDevice device){
				this.device = device;
			}
			public override string ToString(){
				return this.device.FriendlyName;
			}
			
			public string DeviceID{
			get{
				if(device==null){
					return null;
				}
				return device.DeviceID;
			}
		}
			
			
		}
		
		public bool StartCapture(){
			
			if (mmdevice == null) return false;
			
			Console.WriteLine("Prepare to capturing!");
			if(mmdevice.DataFlow == DataFlow.Capture){
				capture = new WasapiCapture();
			}else if(mmdevice.DataFlow == DataFlow.Render){
				capture = new WasapiLoopbackCapture();
			}
			
			if(capture == null){
				Console.WriteLine("Not able to open capture mode!");
				return false;
			}
			
			Console.WriteLine("Selected Device: "+mmdevice.FriendlyName);
			
			capture.Device = mmdevice;
			capture.Initialize();

			var soundInSource = new SoundInSource(capture);
			
			var singleBlockNotificationStream = new SingleBlockNotificationStream(soundInSource.ToSampleSource());
			waveSource = singleBlockNotificationStream.ToWaveSource();
			singleBlockNotificationStream.SingleBlockRead += SingleBlockNotificationStreamOnSingleBlockRead;
			
			byte[] buffer = new byte[waveSource.WaveFormat.BytesPerSecond / 2];
			soundInSource.DataAvailable += delegate {
				int read;
				while((read = waveSource.Read(buffer, 0, buffer.Length)) > 0){}
			};


			capture.Start();
			return true;
		}
		
		void SingleBlockNotificationStreamOnSingleBlockRead(object sender, SingleBlockReadEventArgs e){
			if(OnSampleCaptured!=null){
				OnSampleCaptured(e.Left, e.Right);
			}
		}
		
		public void StopCapture(){
			
			if (capture != null){
				
				Console.WriteLine("Stop Capturing...");
				capture.Stop();
				capture.Dispose();
				capture = null;
				waveSource.Dispose();
				Console.WriteLine("Stopped!");
			}
		}
	}
}
