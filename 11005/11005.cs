#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

class Program
{
	public static char conv(long c)
	{
		if (0 <= c && c <= 9) return (char)(c + '0');
		else return (char)(c + '7');
	}

	public static void Main(string[] args)
	{
		string[] s = Console.ReadLine().Split(' ');
		long N = long.Parse(s[0]);
		int B = int.Parse(s[1]);
		StringBuilder sb = new StringBuilder();
		string R;
		char[] C;

		if (N == 0) R = "0";
		else if (N == B) R = 10 + "";
		else if (N < B) R = conv(N) + "";
		else
		{
			while (N != 0)
			{
				if (N >= B)
				{
					sb.Append(conv(N % B) + "");
					N /= B;
				}
				else
				{
					sb.Append(conv(N % B) + "");
					N = 0;
				}
			}

			C = sb.ToString().ToCharArray();
			Array.Reverse(C);
			R = new string(C);
		}

		Console.WriteLine(R);
	}
}