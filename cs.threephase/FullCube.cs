using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace cs.threephase
{
	/*
	Edge Cubies: 
						14	2	
					1			15
					13			3
						0	12	
		1	13			0	12			3	15			2	14	
	9			20	20			11	11			22	22			9
	21			8	8			23	23			10	10			21
		17	5			18	6			19	7			16	4	
						18	6	
					5			19
					17			7
						4	16	

	Center Cubies: 
				0	1
				3	2

	20	21		8	9		16	17		12	13
	23	22		11	10		19	18		15	14

				4	5
				7	6

				|************|
				|*U1**U2**U3*|
				|************|
				|*U4**U5**U6*|
				|************|
				|*U7**U8**U9*|
				|************|
	************|************|************|************|
	*L1**L2**L3*|*F1**F2**F3*|*R1**R2**F3*|*B1**B2**B3*|
	************|************|************|************|
	*L4**L5**L6*|*F4**F5**F6*|*R4**R5**R6*|*B4**B5**B6*|
	************|************|************|************|
	*L7**L8**L9*|*F7**F8**F9*|*R7**R8**R9*|*B7**B8**B9*|
	************|************|************|************|
				|************|
				|*D1**D2**D3*|
				|************|
				|*D4**D5**D6*|
				|************|
				|*D7**D8**D9*|
				|************|


					|****************|
					|*u0**u1**u2**u3*|
					|****************|
					|*u4**u5**u6**u7*|
					|****************|
					|*u8**u9**ua**ub*|
					|****************|
					|*uc**ud**ue**uf*|
					|****************|
	****************|****************|****************|****************|
	*l0**l1**l2**l3*|*f0**f1**f2**f3*|*r0**r1**r2**r3*|*b0**b1**b2**b3*|
	****************|****************|****************|****************|
	*l4**l5**l6**l7*|*f4**f5**f6**f7*|*r4**r5**r6**r7*|*b4**b5**b6**b7*|
	****************|****************|****************|****************|
	*l8**l9**la**lb*|*f8**f9**fa**fb*|*r8**r9**ra**rb*|*b8**b9**ba**bb*|
	****************|****************|****************|****************|
	*lc**ld**le**lf*|*fc**fd**fe**ff*|*rc**rd**re**rf*|*bc**bd**be**bf*|
	****************|****************|****************|****************|
					|****************|
					|*d0**d1**d2**d3*|
					|****************|
					|*d4**d5**d6**d7*|
					|****************|
					|*d8**d9**da**db*|
					|****************|
					|*dc**dd**de**df*|
					|****************|
		 */



	public class FullCube : FastPriorityQueueNode, IComparable<FullCube>
	{

		public static byte[] centerFacelet = { Moves.u5, Moves.u6, Moves.ua, Moves.u9, Moves.d5, Moves.d6, Moves.da, Moves.d9, Moves.f5, Moves.f6, Moves.fa, Moves.f9, Moves.b5, Moves.b6, Moves.ba, Moves.b9, Moves.r5, Moves.r6, Moves.ra, Moves.r9, Moves.l5, Moves.l6, Moves.la, Moves.l9 };
		static byte[][] edgeFacelet = {
		new byte[]{Moves.ud, Moves.f1}, new byte[]{Moves.u4, Moves.l1}, new byte[]{Moves.u2, Moves.b1}, new byte[]{Moves.ub, Moves.r1}, new byte[]{Moves.dd, Moves.be}, new byte[]{Moves.d4, Moves.le}, new byte[]{Moves.d2, Moves.fe}, new byte[]{Moves.db, Moves.re}, new byte[]{Moves.lb, Moves.f8}, new byte[]{Moves.l4, Moves.b7}, new byte[]{Moves.rb, Moves.b8}, new byte[]{Moves.r4, Moves.f7},
		new byte[]{Moves.f2, Moves.ue}, new byte[]{Moves.l2, Moves.u8}, new byte[]{Moves.b2, Moves.u1}, new byte[]{Moves.r2, Moves.u7}, new byte[]{Moves.bd, Moves.de}, new byte[]{Moves.ld, Moves.d8}, new byte[]{Moves.fd, Moves.d1}, new byte[]{Moves.rd, Moves.d7}, new byte[]{Moves.f4, Moves.l7}, new byte[]{Moves.bb, Moves.l8}, new byte[]{Moves.b4, Moves.r7}, new byte[]{Moves.fb, Moves.r8}};
		static byte[][] cornerFacelet = { new byte[]{ Moves.uf, Moves.r0, Moves.f3 }, new byte[]{ Moves.uc, Moves.f0, Moves.l3 }, new byte[]{ Moves.u0, Moves.l0, Moves.b3 }, new byte[]{ Moves.u3, Moves.b0, Moves.r3 },
			new byte[]{ Moves.d3, Moves.ff, Moves.rc }, new byte[]{ Moves.d0, Moves.lf, Moves.fc }, new byte[]{ Moves.dc, Moves.bf, Moves.lc }, new byte[]{ Moves.df, Moves.rf, Moves.bc } };


		public FullCube(byte[] f)
		{
			edge = new EdgeCube();
			center = new CenterCube();
			corner = new CornerCube();
			for (int i = 0; i < 24; i++)
			{
				center.ct[i] = f[centerFacelet[i]];
			}
			for (int i = 0; i < 24; i++)
			{
				for (byte j = 0; j < 24; j++)
				{
					if (f[edgeFacelet[i][0]] == edgeFacelet[j][0] / 16 && f[edgeFacelet[i][1]] == edgeFacelet[j][1] / 16)
					{
						edge.ep[i] = j;
					}
				}
			}
			byte col1, col2, ori;
			for (byte i = 0; i < 8; i++)
			{
				// get the colors of the cubie at corner i, starting with U/D
				for (ori = 0; ori < 3; ori++)
					if (f[cornerFacelet[i][ori]] == Moves.u0 / 16 || f[cornerFacelet[i][ori]] == Moves.d0 / 16)
						break;
				col1 = f[cornerFacelet[i][(ori + 1) % 3]];
				col2 = f[cornerFacelet[i][(ori + 2) % 3]];

				for (byte j = 0; j < 8; j++)
				{
					if (col1 == cornerFacelet[j][1] / 16 && col2 == cornerFacelet[j][2] / 16)
					{
						// in cornerposition i we have cornercubie j
						corner.cp[i] = j;
						corner.co[i] = (byte)(ori % 3);
						break;
					}
				}
			}
		}

		public void toFacelet(byte[] f)
		{
			for (int i = 0; i < 24; i++)
			{
				f[centerFacelet[i]] = center.ct[i];
			}
			for (int i = 0; i < 24; i++)
			{
				f[edgeFacelet[i][0]] = (byte)(edgeFacelet[edge.ep[i]][0] / 16);
				f[edgeFacelet[i][1]] = (byte)(edgeFacelet[edge.ep[i]][1] / 16);
			}
			for (byte c = 0; c < 8; c++)
			{
				byte j = corner.cp[c];
				byte ori = corner.co[c];
				for (byte n = 0; n < 3; n++)
					f[cornerFacelet[c][(n + ori) % 3]] = (byte)(cornerFacelet[j][n] / 16);
			}
		}

		public String toString()
		{
			getEdge();
			getCenter();
			getCorner();

			byte[] f = new byte[96];
			StringBuilder sb = new StringBuilder();
			toFacelet(f);
			for (int i = 0; i < 96; i++)
			{
				sb.Append("URFDLB"[f[i]]);
				if (i % 4 == 3)
				{
					sb.Append('\n');
				}
				if (i % 16 == 15)
				{
					sb.Append('\n');
				}
			}
			return sb.ToString();
		}

		//	public static class ValueComparator implements Comparator<FullCube> {
		//		public int compare(FullCube c1, FullCube c2)
		//	{
		//		return c2.value - c1.value;
		//	}
		//}

		private EdgeCube edge;
		private CenterCube center;
		private CornerCube corner;

		public int value = 0;
		public bool add1 = false;
		public int length1 = 0;
		public int length2 = 0;
		int length3 = 0;

		public int compareTo(FullCube c)
		{
			return value - c.value;
		}

		public class ValueComparator : IComparer<FullCube>
		{
			public virtual int Compare(FullCube c1, FullCube c2)
			{
				return c1.value - c2.value;
			}
		}


		public FullCube()
		{
			edge = new EdgeCube();
			center = new CenterCube();
			corner = new CornerCube();
		}

		public FullCube(FullCube c):this()
		{
			//this();
			//edge = new EdgeCube();
			//center = new CenterCube();
			//corner = new CornerCube();
			copy(c);
		}

		public FullCube(Random r)
		{
			edge = new EdgeCube(r);
			center = new CenterCube(r);
			corner = new CornerCube(r);
		}

		public FullCube(int[] moveseq):this()
		{
			//this();
			//edge = new EdgeCube();
			//center = new CenterCube();
			//corner = new CornerCube();
			foreach (int m in moveseq)
			{
				doMove(m);
			}
		}

		public void copy(FullCube c)
		{
			edge.copy(c.edge);
			center.copy(c.center);
			corner.copy(c.corner);

			this.value = c.value;
			this.add1 = c.add1;
			this.length1 = c.length1;
			this.length2 = c.length2;
			this.length3 = c.length3;

			this.sym = c.sym;

			for (int i = 0; i < 60; i++)
			{
				this.moveBuffer[i] = c.moveBuffer[i];
			}
			this.moveLength = c.moveLength;
			this.edgeAvail = c.edgeAvail;
			this.centerAvail = c.centerAvail;
			this.cornerAvail = c.cornerAvail;
		}

		public bool checkEdge()
		{
			return getEdge().checkEdge();
		}

		public String getMoveString(bool inverse, bool rotation)
		{
			int[] fixedMoves = new int[moveLength - (add1 ? 2 : 0)];
			int idx = 0;
			for (int i = 0; i < length1; i++)
			{
				fixedMoves[idx++] = moveBuffer[i];
			}
			int sym = this.sym;
			for (int i = length1 + (add1 ? 2 : 0); i < moveLength; i++)
			{
				if (Center1.symmove[sym][moveBuffer[i]] >= Moves.dx1)
				{
					fixedMoves[idx++] = Center1.symmove[sym][moveBuffer[i]] - 9;
					int rot = move2rot[Center1.symmove[sym][moveBuffer[i]] - Moves.dx1];
					sym = Center1.symmult[sym][rot];
				}
				else
				{
					fixedMoves[idx++] = Center1.symmove[sym][moveBuffer[i]];
				}
			}
			int finishSym = Center1.symmult[Center1.syminv[sym]][Center1.getSolvedSym(getCenter())];

			StringBuilder sb = new StringBuilder();
			sym = finishSym;
			if (inverse)
			{
				for (int i = idx - 1; i >= 0; i--)
				{
					int move = fixedMoves[i];
					move = move / 3 * 3 + (2 - move % 3);
					if (Center1.symmove[sym][move] >= Moves.dx1)
					{
						sb.Append(Moves.move2str[Center1.symmove[sym][move] - 9]).Append(' ');
						int rot = move2rot[Center1.symmove[sym][move] - Moves.dx1];
						sym = Center1.symmult[sym][rot];
					}
					else
					{
						sb.Append(Moves.move2str[Center1.symmove[sym][move]]).Append(' ');
					}
				}
				if (rotation)
				{
					sb.Append(Center1.rot2str[Center1.syminv[sym]] + " ");//cube rotation after solution. for wca scramble, it should be omitted.
				}
			}
			else
			{
				for (int i = 0; i < idx; i++)
				{
					sb.Append(Moves.move2str[fixedMoves[i]]).Append(' ');
				}
				if (rotation)
				{
					sb.Append(Center1.rot2str[finishSym]);//cube rotation after solution.
				}
			}
			return sb.ToString();
		}

		private static int[] move2rot = { 35, 1, 34, 2, 4, 6, 22, 5, 19 };

		public String to333Facelet()
		{
			char[] ret = new char[54];
			getEdge().fill333Facelet(ret);
			getCenter().fill333Facelet(ret);
			getCorner().fill333Facelet(ret);
			return new String(ret);
		}

		byte[] moveBuffer = new byte[60];
		private int moveLength = 0;
		private int edgeAvail = 0;
		private int centerAvail = 0;
		private int cornerAvail = 0;

		public int sym = 0;

		public void move(int m)
		{
			moveBuffer[moveLength++] = (byte)m;
			return;
		}

		void doMove(int m)
		{
			getEdge().move(m);
			getCenter().move(m);
			getCorner().move(m % 18);
		}

		public EdgeCube getEdge()
		{
			while (edgeAvail < moveLength)
			{
				edge.move(moveBuffer[edgeAvail++]);
			}
			return edge;
		}

		public CenterCube getCenter()
		{
			while (centerAvail < moveLength)
			{
				center.move(moveBuffer[centerAvail++]);
			}
			return center;
		}

		public CornerCube getCorner()
		{
			while (cornerAvail < moveLength)
			{
				corner.move(moveBuffer[cornerAvail++] % 18);
			}
			return corner;
		}

		public int CompareTo([AllowNull] FullCube other)
		{
			return this.value.CompareTo(other.value);
		}
	}
}

