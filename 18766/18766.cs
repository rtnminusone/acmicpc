#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();

		int T = int.Parse(Console.ReadLine());
		while (T-- > 0)
		{
			int N = int.Parse(Console.ReadLine());
			string[] A = Console.ReadLine().Split();
			string[] B = Console.ReadLine().Split();
			Array.Sort(A);
			Array.Sort(B);
			bool flg = true;
			for (int i = 0; i < N; i++)
			{
				if (A[i] != B[i])
				{
					flg = false;
					break;
				}
			}

			sb.AppendLine(flg ? "NOT CHEATER" : "CHEATER");
		}

		Console.WriteLine(sb.ToString());
	}
}