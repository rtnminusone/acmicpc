#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		int R = 0, r = 0, k = 0;
		string S = Console.ReadLine();
		for (int i = 0; i < S.Length - 1; i++)
		{
			if (S[i] == '*') r = i % 2 == 0 ? 1 : 3;
			else if (i % 2 == 0) R += S[i] - '0';
			else R += (S[i] - '0') * 3;
		}
		R += S[S.Length - 1] - '0';
		for (int i = 0; i < 10; i++)
		{
			k = R;
			if ((k + (i * r)) % 10 == 0)
			{
				Console.WriteLine(i);
				break;
			}
		}
	}
}