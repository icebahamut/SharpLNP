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
using System.Drawing;

namespace SharpLNP
{
	/// <summary>
	/// Description of ColorToolkit.
	/// </summary>
	public class ColorToolkit{
		public static Structs.RGB color2rgb(Color c){
			Structs.RGB rgb = new Structs.RGB();
			rgb.r = c.R/255.0;
			rgb.g = c.G/255.0;
			rgb.b = c.B/255.0;
			return rgb;
		}
		
		public static Color rgb2color(Structs.RGB rgb){
			double r=rgb.r*255d, g=rgb.g*255d, b=rgb.b*255d;
			
			if(r<0)r=0;
			if(r>255d)r=255d;
			if(g<0)r=0;
			if(g>255d)g=255d;
			if(b<0)b=0;
			if(b>255d)b=255d;
			
			return Color.FromArgb((int)r,(int)g,(int)b);
		}
		
		public static Structs.HSV rgb2hsv(Structs.RGB rgb){
			Structs.HSV hsv = new Structs.HSV();
			double min, max, delta;
			min = rgb.r < rgb.g ? rgb.r : rgb.g;
			min = min  < rgb.b ? min  : rgb.b;
			max = rgb.r > rgb.g ? rgb.r : rgb.g;
			max = max  > rgb.b ? max  : rgb.b;

			hsv.v = max;
			delta = max - min;
			if (delta < 0.000001){
				hsv.s = 0;
				hsv.h = 0;
				return hsv;
			}
			
			if( max > 0.0 ) {
				hsv.s = (delta / max);
			} else {
				hsv.s = 0.0;
				hsv.h = 0.0;
				return hsv;
			}
			
			if( rgb.r >= max ) {
				hsv.h = ( rgb.g - rgb.b ) / delta;
			} else if( rgb.g >= max ) {
				hsv.h = 2.0 + ( rgb.b - rgb.r ) / delta;
			} else {
				hsv.h = 4.0 + ( rgb.r - rgb.g ) / delta;
			}
                            
			hsv.h /= 6d;
			if( hsv.h < 0.0 ) hsv.h += 1d;

			return hsv;
		}

		public static Structs.RGB hsv2rgb(Structs.HSV hsv){
			double hh, p, q, t, ff;
			long i;
			Structs.RGB rgb = new Structs.RGB();

			if(hsv.s <= 0.0) {
				rgb.r = hsv.v;
				rgb.g = hsv.v;
				rgb.b = hsv.v;
				return rgb;
			}
			
			hh = hsv.h;
			if(hh >= 1d) hh = 1.0-hh;
			hh *= 6d;
			i = (long)(hh);
			ff = hh - i;
			p = hsv.v * (1.0 - hsv.s);
			q = hsv.v * (1.0 - (hsv.s * ff));
			t = hsv.v * (1.0 - (hsv.s * (1.0 - ff)));

			switch(i) {
				case 0:
					rgb.r = hsv.v;
					rgb.g = t;
					rgb.b = p;
					break;
				case 1:
					rgb.r = q;
					rgb.g = hsv.v;
					rgb.b = p;
					break;
				case 2:
					rgb.r = p;
					rgb.g = hsv.v;
					rgb.b = t;
					break;
				case 3:
					rgb.r = p;
					rgb.g = q;
					rgb.b = hsv.v;
					break;
				case 4:
					rgb.r = t;
					rgb.g = p;
					rgb.b = hsv.v;
					break;
				default:
					rgb.r = hsv.v;
					rgb.g = p;
					rgb.b = q;
					break;
			}
			return rgb;
		}
		
	
	}
}
