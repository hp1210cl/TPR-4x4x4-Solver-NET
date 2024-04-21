using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace cs.threephase
{

	public class Tools
	{

		//		private static void read(int[] arr, DataInput in) throws IOException
		//		{
		//		for (int i=0, len=arr.length; i<len; i++) {
		//			arr[i] = in.readInt();
		//	}
		//}

		//private static void write(int[] arr, DataOutput out) throws IOException
		//{
		//		for (int i=0, len=arr.length; i<len; i++) {
		//			out.writeInt(arr[i]);
		//	}
		//}

		//private static void read(int[][] arr, DataInput in) throws IOException
		//{
		//		for (int i=0, leng=arr.length; i<leng; i++) {
		//		for (int j = 0, len = arr[i].length; j < len; j++)
		//		{
		//			arr[i][j] = in.readInt();
		//		}
		//	}
		//}

		//private static void write(int[][] arr, DataOutput out) throws IOException
		//{
		//		for (int i=0, leng=arr.length; i<leng; i++) {
		//		for (int j = 0, len = arr[i].length; j < len; j++)
		//		{
		//				out.writeInt(arr[i][j]);
		//		}
		//	}
		//}

		static Random r = new Random();

		public static String randomCube()
		{
			return randomCube(r);
		}

		public static String randomCube(Random r)
		{
			FullCube c = new FullCube(r);
			byte[] f = new byte[96];
			c.toFacelet(f);
			StringBuilder sb = new StringBuilder();
			foreach (var i in f)
			{
				sb.Append("URFDLB"[i]);
			}
			return sb.ToString();
		}

		private static void read(byte[] arr, FileStream fileStream)
		{
			fileStream.Read(arr, 0, arr.Length);
		}
		private static void write(byte[] arr, FileStream fileStream)
		{
			fileStream.Write(arr);
		}

		private static void read(char[] arr, FileStream fileStream)
		{
			byte[] b = new byte[arr.Length * 2];
			fileStream.Read(b, 0, b.Length);
			Buffer.BlockCopy(b, 0, arr, 0, b.Length);
		}
		private static void write(char[] arr, FileStream fileStream)
		{
			byte[] b = new byte[arr.Length * 2];
			Buffer.BlockCopy(arr, 0, b, 0, b.Length);
			fileStream.Write(b);
		}
		private static void read(int[] arr, FileStream fileStream)
		{
			byte[] b = new byte[arr.Length * 4];
			fileStream.Read(b, 0, b.Length);
			Buffer.BlockCopy(b, 0, arr, 0, b.Length);
		}
		private static void write(int[] arr, FileStream fileStream)
		{
			byte[] b = new byte[arr.Length * 4];
			Buffer.BlockCopy(arr, 0, b, 0, b.Length);
			fileStream.Write(b);
		}
		private static void read(char[][] arr, FileStream fileStream)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				byte[] b = new byte[arr[i].Length * 2];
				fileStream.Read(b, 0, b.Length);
				Buffer.BlockCopy(b, 0, arr[i], 0, b.Length);
			}
		}
		private static void write(char[][] arr, FileStream fileStream)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				byte[] b = new byte[arr[i].Length * 2];
				Buffer.BlockCopy(arr[i], 0, b, 0, b.Length);
				fileStream.Write(b);
			}
		}
		private static void read(int[][] arr, FileStream fileStream)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				byte[] b = new byte[arr[i].Length * 4];
				fileStream.Read(b, 0, b.Length);
				Buffer.BlockCopy(b, 0, arr[i], 0, b.Length);
			}
		}
		private static void write(int[][] arr, FileStream fileStream)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				byte[] b = new byte[arr[i].Length * 4];
				Buffer.BlockCopy(arr[i], 0, b, 0, b.Length);
				fileStream.Write(b);
			}
		}


		public static void initFrom(FileStream fileStream)
		{
			if (Search.inited)
			{
				return;
			}

			Debug.WriteLine("Initialize Center1 Solver...");

			Center1.initSym();
			Center1.initSym2Raw();
			read(Center1.ctsmv, fileStream);
			//string s = File.ReadAllText("ctsmv");
			//Center1.ctsmv = JsonSerializer.Deserialize<int[][]>(s);

			Center1.createPrun();

			Debug.WriteLine("Initialize Center2 Solver...");

			Center2.init();

			Debug.WriteLine("Initialize Center3 Solver...");

			Center3.init();

			Debug.WriteLine("Initialize Edge3 Solver...");

			Edge3.initMvrot();
			Edge3.initRaw2Sym();
			read(Edge3.eprun, fileStream);
			//s = File.ReadAllText("eprun");
			//Edge3.eprun = JsonSerializer.Deserialize<int[]>(s);

			Debug.WriteLine("OK");

			Search.inited = true;
		}

		public static void saveTo(FileStream fileStream)
		{
			if (!Search.inited)
			{
				Search.init();
			}
			write(Center1.ctsmv, fileStream);
			write(Edge3.eprun, fileStream);
			//string s = JsonSerializer.Serialize(Center1.ctsmv);
			//File.WriteAllText("ctsmv", s);
			//s = JsonSerializer.Serialize(Edge3.eprun);
			//File.WriteAllText("eprun", s);
		}
	}
}
