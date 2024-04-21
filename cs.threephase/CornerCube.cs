using System;
using System.Collections.Generic;
using System.Text;

namespace cs.threephase
{
	public class CornerCube
	{

		/**
		 * 18 move cubes
		 */
		private static CornerCube[] moveCube = new CornerCube[18];

		private static int[] cpmv = {1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1,
										1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1};

		public byte[] cp = { 0, 1, 2, 3, 4, 5, 6, 7 };
		public byte[] co = { 0, 0, 0, 0, 0, 0, 0, 0 };

		CornerCube temps = null;//new CornerCube();

		public CornerCube()
		{
		}

		public CornerCube(Random r)
		{
			this.setCPerm(r.Next(40320));
			this.setTwist(r.Next(2187));
		}

		CornerCube(int cperm, int twist)
		{
			this.setCPerm(cperm);
			this.setTwist(twist);
		}

		CornerCube(CornerCube c)
		{
			copy(c);
		}

		public void copy(CornerCube c)
		{
			for (int i = 0; i < 8; i++)
			{
				this.cp[i] = c.cp[i];
				this.co[i] = c.co[i];
			}
		}

		public int getParity()
		{
			return Util.parity(cp);
		}

		static byte[][] cornerFacelet = { new byte[]{ Moves.U9, Moves.R1, Moves.F3 }, new byte[]{ Moves.U7, Moves.F1, Moves.L3 }, new byte[]{ Moves.U1, Moves.L1, Moves.B3 }, new byte[]{ Moves.U3, Moves.B1, Moves.R3 },
			new byte[]{ Moves.D3, Moves.F9, Moves.R7 }, new byte[]{ Moves.D1, Moves.L9, Moves.F7 }, new byte[]{ Moves.D7, Moves.B9, Moves.L7 }, new byte[]{ Moves.D9, Moves.R9, Moves.B7 } };

		public void fill333Facelet(char[] facelet)
		{
			for (int corn = 0; corn < 8; corn++)
			{
				int j = cp[corn];
				int ori = co[corn];
				for (int n = 0; n < 3; n++)
				{
					facelet[cornerFacelet[corn][(n + ori) % 3]] = "URFDLB"[cornerFacelet[j][n] / 9];
				}
			}
		}

		/**
		 * prod = a * b, Corner Only.
		 */
		static void CornMult(CornerCube a, CornerCube b, CornerCube prod)
		{
			for (int corn = 0; corn < 8; corn++)
			{
				prod.cp[corn] = a.cp[b.cp[corn]];
				byte oriA = a.co[b.cp[corn]];
				byte oriB = b.co[corn];
				byte ori = oriA;
				ori += (oriA < 3) ? oriB : (byte)(6 - oriB);
				ori %= 3;
				if ((oriA >= 3) ^ (oriB >= 3))
				{
					ori += 3;
				}
				prod.co[corn] = ori;
			}
		}

		void setTwist(int idx)
		{
			int twst = 0;
			for (int i = 6; i >= 0; i--)
			{
				twst += co[i] = (byte)(idx % 3);
				idx /= 3;
			}
			co[7] = (byte)((15 - twst) % 3);
		}

		void setCPerm(int idx)
		{
			Util.set8Perm(cp, idx);
		}

		public void move(int idx)
		{
			if (temps == null)
			{
				temps = new CornerCube();
			}
			CornMult(this, moveCube[idx], temps);
			copy(temps);
		}

		static CornerCube()
		{
			initMove();
		}

		static void initMove()
		{
			moveCube[0] = new CornerCube(15120, 0);
			moveCube[3] = new CornerCube(21021, 1494);
			moveCube[6] = new CornerCube(8064, 1236);
			moveCube[9] = new CornerCube(9, 0);
			moveCube[12] = new CornerCube(1230, 412);
			moveCube[15] = new CornerCube(224, 137);
			for (int a = 0; a < 18; a += 3)
			{
				for (int p = 0; p < 2; p++)
				{
					moveCube[a + p + 1] = new CornerCube();
					CornMult(moveCube[a + p], moveCube[a], moveCube[a + p + 1]);
				}
			}
		}
	}
}
