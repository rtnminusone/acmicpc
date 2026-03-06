#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		int N = int.Parse(S[0]);
		int r = int.Parse(S[1]);
		int c = int.Parse(S[2]);
		int R = 0;
		for (int i = N - 1; i >= 0; i--)
		{
			int half = 1 << i;
			int area = half * half;

			if (r < half && c < half) continue;
			else if (r < half && c >= half)
			{
				R += area;
				c -= half;
			}
			else if (r >= half && c < half)
			{
				R += area * 2;
				r -= half;
			}
			else
			{
				R += area * 3;
				r -= half;
				c -= half;
			}
		}

		Console.WriteLine(R);
	}
}