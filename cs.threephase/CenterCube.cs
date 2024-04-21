﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace cs.threephase
{
	public class CenterCube
	{

		public byte[] ct = new byte[24];

		public CenterCube()
		{
			for (int i = 0; i < 24; i++)
			{
				ct[i] = (byte)(FullCube.centerFacelet[i] / 16);
			}
		}

		CenterCube(CenterCube c)
		{
			copy(c);
		}

		public CenterCube(Random r):this()
		{
			//this();
			//for (int i = 0; i < 24; i++)
			//{
			//	ct[i] = (byte)(FullCube.centerFacelet[i] / 16);
			//}
			for (int i = 0; i < 23; i++)
			{
				int t = i + r.Next(24 - i);
				if (ct[t] != ct[i])
				{
					byte m = ct[i];
					ct[i] = ct[t];
					ct[t] = m;
				}
			}
		}

		CenterCube(int[] moveseq):this()
		{
			//this();
			//for (int i = 0; i < 24; i++)
			//{
			//	ct[i] = (byte)(FullCube.centerFacelet[i] / 16);
			//}
			for (int m = 0; m < moveseq.Length; m++)
			{
				move(m);
			}
		}

		public void copy(CenterCube c)
		{
			for (int i = 0; i < 24; i++)
			{
				this.ct[i] = c.ct[i];
			}
		}

		void print()
		{
			for (int i = 0; i < 24; i++)
			{
				Debug.Write(ct[i]);
				Debug.Write('\t');
			}
			Debug.WriteLine("");
		}

		static int[] center333Map = { 0, 4, 2, 1, 5, 3 };

		public void fill333Facelet(char[] facelet)
		{
			int firstIdx = 4, inc = 9;
			for (int i = 0; i < 6; i++)
			{
				int idx = center333Map[i] << 2;
				if (ct[idx] != ct[idx + 1] || ct[idx + 1] != ct[idx + 2] || ct[idx + 2] != ct[idx + 3])
				{
					throw new Exception("Unsolved Center");
				}
				facelet[firstIdx + i * inc] = "URFDLB"[ct[idx]];
			}
		}

		public void move(int m)
		{
			int key = m % 3;
			m /= 3;
			switch (m)
			{
				case 0: //U
					Util.swap(ct, 0, 1, 2, 3, key);
					break;
				case 1: //R
					Util.swap(ct, 16, 17, 18, 19, key);
					break;
				case 2: //F
					Util.swap(ct, 8, 9, 10, 11, key);
					break;
				case 3: //D
					Util.swap(ct, 4, 5, 6, 7, key);
					break;
				case 4: //L
					Util.swap(ct, 20, 21, 22, 23, key);
					break;
				case 5: //B
					Util.swap(ct, 12, 13, 14, 15, key);
					break;
				case 6: //u
					Util.swap(ct, 0, 1, 2, 3, key);
					Util.swap(ct, 8, 20, 12, 16, key);
					Util.swap(ct, 9, 21, 13, 17, key);
					break;
				case 7: //r
					Util.swap(ct, 16, 17, 18, 19, key);
					Util.swap(ct, 1, 15, 5, 9, key);
					Util.swap(ct, 2, 12, 6, 10, key);
					break;
				case 8: //f
					Util.swap(ct, 8, 9, 10, 11, key);
					Util.swap(ct, 2, 19, 4, 21, key);
					Util.swap(ct, 3, 16, 5, 22, key);
					break;
				case 9: //d
					Util.swap(ct, 4, 5, 6, 7, key);
					Util.swap(ct, 10, 18, 14, 22, key);
					Util.swap(ct, 11, 19, 15, 23, key);
					break;
				case 10://l
					Util.swap(ct, 20, 21, 22, 23, key);
					Util.swap(ct, 0, 8, 4, 14, key);
					Util.swap(ct, 3, 11, 7, 13, key);
					break;
				case 11://b
					Util.swap(ct, 12, 13, 14, 15, key);
					Util.swap(ct, 1, 20, 7, 18, key);
					Util.swap(ct, 0, 23, 6, 17, key);
					break;
			}
		}
	}
}
