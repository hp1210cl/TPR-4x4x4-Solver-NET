using System;
using System.Collections.Generic;
using System.Text;

namespace cs.threephase
{

	class Moves
	{
		public static byte U1 = 0;
		public static byte U2 = 1;
		public static byte U3 = 2;
		public static byte U4 = 3;
		public static byte U5 = 4;
		public static byte U6 = 5;
		public static byte U7 = 6;
		public static byte U8 = 7;
		public static byte U9 = 8;
		public static byte R1 = 9;
		public static byte R2 = 10;
		public static byte R3 = 11;
		public static byte R4 = 12;
		public static byte R5 = 13;
		public static byte R6 = 14;
		public static byte R7 = 15;
		public static byte R8 = 16;
		public static byte R9 = 17;
		public static byte F1 = 18;
		public static byte F2 = 19;
		public static byte F3 = 20;
		public static byte F4 = 21;
		public static byte F5 = 22;
		public static byte F6 = 23;
		public static byte F7 = 24;
		public static byte F8 = 25;
		public static byte F9 = 26;
		public static byte D1 = 27;
		public static byte D2 = 28;
		public static byte D3 = 29;
		public static byte D4 = 30;
		public static byte D5 = 31;
		public static byte D6 = 32;
		public static byte D7 = 33;
		public static byte D8 = 34;
		public static byte D9 = 35;
		public static byte L1 = 36;
		public static byte L2 = 37;
		public static byte L3 = 38;
		public static byte L4 = 39;
		public static byte L5 = 40;
		public static byte L6 = 41;
		public static byte L7 = 42;
		public static byte L8 = 43;
		public static byte L9 = 44;
		public static byte B1 = 45;
		public static byte B2 = 46;
		public static byte B3 = 47;
		public static byte B4 = 48;
		public static byte B5 = 49;
		public static byte B6 = 50;
		public static byte B7 = 51;
		public static byte B8 = 52;
		public static byte B9 = 53;

		public static byte u0 = 0x0;
		public static byte u1 = 0x1;
		public static byte u2 = 0x2;
		public static byte u3 = 0x3;
		public static byte u4 = 0x4;
		public static byte u5 = 0x5;
		public static byte u6 = 0x6;
		public static byte u7 = 0x7;
		public static byte u8 = 0x8;
		public static byte u9 = 0x9;
		public static byte ua = 0xa;
		public static byte ub = 0xb;
		public static byte uc = 0xc;
		public static byte ud = 0xd;
		public static byte ue = 0xe;
		public static byte uf = 0xf;
		public static byte r0 = 0x10;
		public static byte r1 = 0x11;
		public static byte r2 = 0x12;
		public static byte r3 = 0x13;
		public static byte r4 = 0x14;
		public static byte r5 = 0x15;
		public static byte r6 = 0x16;
		public static byte r7 = 0x17;
		public static byte r8 = 0x18;
		public static byte r9 = 0x19;
		public static byte ra = 0x1a;
		public static byte rb = 0x1b;
		public static byte rc = 0x1c;
		public static byte rd = 0x1d;
		public static byte re = 0x1e;
		public static byte rf = 0x1f;
		public static byte f0 = 0x20;
		public static byte f1 = 0x21;
		public static byte f2 = 0x22;
		public static byte f3 = 0x23;
		public static byte f4 = 0x24;
		public static byte f5 = 0x25;
		public static byte f6 = 0x26;
		public static byte f7 = 0x27;
		public static byte f8 = 0x28;
		public static byte f9 = 0x29;
		public static byte fa = 0x2a;
		public static byte fb = 0x2b;
		public static byte fc = 0x2c;
		public static byte fd = 0x2d;
		public static byte fe = 0x2e;
		public static byte ff = 0x2f;
		public static byte d0 = 0x30;
		public static byte d1 = 0x31;
		public static byte d2 = 0x32;
		public static byte d3 = 0x33;
		public static byte d4 = 0x34;
		public static byte d5 = 0x35;
		public static byte d6 = 0x36;
		public static byte d7 = 0x37;
		public static byte d8 = 0x38;
		public static byte d9 = 0x39;
		public static byte da = 0x3a;
		public static byte db = 0x3b;
		public static byte dc = 0x3c;
		public static byte dd = 0x3d;
		public static byte de = 0x3e;
		public static byte df = 0x3f;
		public static byte l0 = 0x40;
		public static byte l1 = 0x41;
		public static byte l2 = 0x42;
		public static byte l3 = 0x43;
		public static byte l4 = 0x44;
		public static byte l5 = 0x45;
		public static byte l6 = 0x46;
		public static byte l7 = 0x47;
		public static byte l8 = 0x48;
		public static byte l9 = 0x49;
		public static byte la = 0x4a;
		public static byte lb = 0x4b;
		public static byte lc = 0x4c;
		public static byte ld = 0x4d;
		public static byte le = 0x4e;
		public static byte lf = 0x4f;
		public static byte b0 = 0x50;
		public static byte b1 = 0x51;
		public static byte b2 = 0x52;
		public static byte b3 = 0x53;
		public static byte b4 = 0x54;
		public static byte b5 = 0x55;
		public static byte b6 = 0x56;
		public static byte b7 = 0x57;
		public static byte b8 = 0x58;
		public static byte b9 = 0x59;
		public static byte ba = 0x5a;
		public static byte bb = 0x5b;
		public static byte bc = 0x5c;
		public static byte bd = 0x5d;
		public static byte be = 0x5e;
		public static byte bf = 0x5f;

		public static int U = 0;
		public static int R = 1;
		public static int F = 2;
		public static int D = 3;
		public static int L = 4;
		public static int B = 5;

		public static int Ux1 = 0;
		public static int Ux2 = 1;
		public static int Ux3 = 2;
		public static int Rx1 = 3;
		public static int Rx2 = 4;
		public static int Rx3 = 5;
		public static int Fx1 = 6;
		public static int Fx2 = 7;
		public static int Fx3 = 8;
		public static int Dx1 = 9;
		public static int Dx2 = 10;
		public static int Dx3 = 11;
		public static int Lx1 = 12;
		public static int Lx2 = 13;
		public static int Lx3 = 14;
		public static int Bx1 = 15;
		public static int Bx2 = 16;
		public static int Bx3 = 17;
		public static int ux1 = 18;
		public static int ux2 = 19;
		public static int ux3 = 20;
		public static int rx1 = 21;
		public static int rx2 = 22;
		public static int rx3 = 23;
		public static int fx1 = 24;
		public static int fx2 = 25;
		public static int fx3 = 26;
		public static int dx1 = 27;
		public static int dx2 = 28;
		public static int dx3 = 29;
		public static int lx1 = 30;
		public static int lx2 = 31;
		public static int lx3 = 32;
		public static int bx1 = 33;
		public static int bx2 = 34;
		public static int bx3 = 35;
		public static int eom = 36;//End Of Moves


		public static String[] move2str = {"U  ", "U2 ", "U' ", "R  ", "R2 ", "R' ", "F  ", "F2 ", "F' ",
											 "D  ", "D2 ", "D' ", "L  ", "L2 ", "L' ", "B  ", "B2 ", "B' ",
											 "Uw ", "Uw2", "Uw'", "Rw ", "Rw2", "Rw'", "Fw ", "Fw2", "Fw'",
											 "Dw ", "Dw2", "Dw'", "Lw ", "Lw2", "Lw'", "Bw ", "Bw2", "Bw'"};

		public static String[] moveIstr = {"U' ", "U2 ", "U  ", "R' ", "R2 ", "R  ", "F' ", "F2 ", "F  ",
											 "D' ", "D2 ", "D  ", "L' ", "L2 ", "L  ", "B' ", "B2 ", "B  ",
											 "Uw'", "Uw2", "Uw ", "Rw'", "Rw2", "Rw ", "Fw'", "Fw2", "Fw ",
											 "Dw'", "Dw2", "Dw ", "Lw'", "Lw2", "Lw ", "Bw'", "Bw2", "Bw "};

		public static int[] move2std = {Ux1, Ux2, Ux3, Rx1, Rx2, Rx3, Fx1, Fx2, Fx3,
							 Dx1, Dx2, Dx3, Lx1, Lx2, Lx3, Bx1, Bx2, Bx3,
							 ux2, rx1, rx2, rx3, fx2, dx2, lx1, lx2, lx3, bx2, eom};

		public static int[] move3std = {Ux1, Ux2, Ux3, Rx2, Fx1, Fx2, Fx3, Dx1, Dx2, Dx3, Lx2, Bx1, Bx2, Bx3,
							 ux2, rx2, fx2, dx2, lx2, bx2, eom};

		static int[] std2move = new int[37];
		static int[] std3move = new int[37];

		public static bool[][] ckmv = new bool[37][];
		public static bool[][] ckmv2 = new bool[29][];
		public static bool[][] ckmv3 = new bool[21][];

		static int[] skipAxis = new int[36];
		public static int[] skipAxis2 = new int[28];
		public static int[] skipAxis3 = new int[20];

		static Moves()
		{
            //static bool[][] ckmv = new bool[37][36];
            //static bool[][] ckmv2 = new bool[29][28];
            //static bool[][] ckmv3 = new bool[21][20];
            for (int i = 0; i < 37; i++)
            {
				ckmv[i] = new bool[36];
            }
            for (int i = 0; i < 29; i++)
            {
				ckmv2[i] = new bool[28];
            }
            for (int i = 0; i < 21; i++)
            {
				ckmv3[i] = new bool[20];
            }

			for (int i = 0; i < 29; i++)
			{
				std2move[move2std[i]] = i;
			}
			for (int i = 0; i < 21; i++)
			{
				std3move[move3std[i]] = i;
			}
			for (int i = 0; i < 36; i++)
			{
				for (int j = 0; j < 36; j++)
				{
					ckmv[i][j] = (i / 3 == j / 3) || ((i / 3 % 3 == j / 3 % 3) && (i > j));
				}
				ckmv[36][i] = false;
			}
			for (int i = 0; i < 29; i++)
			{
				for (int j = 0; j < 28; j++)
				{
					ckmv2[i][j] = ckmv[move2std[i]][move2std[j]];
				}
			}
			for (int i = 0; i < 21; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					ckmv3[i][j] = ckmv[move3std[i]][move3std[j]];
				}
			}
			for (int i = 0; i < 36; i++)
			{
				skipAxis[i] = 36;
				for (int j = i; j < 36; j++)
				{
					if (!ckmv[i][j])
					{
						skipAxis[i] = j - 1;
						break;
					}
				}
			}
			for (int i = 0; i < 28; i++)
			{
				skipAxis2[i] = 28;
				for (int j = i; j < 28; j++)
				{
					if (!ckmv2[i][j])
					{
						skipAxis2[i] = j - 1;
						break;
					}
				}
			}
			for (int i = 0; i < 20; i++)
			{
				skipAxis3[i] = 20;
				for (int j = i; j < 20; j++)
				{
					if (!ckmv3[i][j])
					{
						skipAxis3[i] = j - 1;
						break;
					}
				}
			}
		}
	}
}
