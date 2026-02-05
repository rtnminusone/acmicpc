#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static char[] R = new char[10002];

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		int i = S[0].Length - 1;
		int j = S[1].Length - 1;
		int k = 0;
		int carry = 0;

		while (i >= 0 || j >= 0 || carry > 0)
		{
			int sum = carry;
			if (i >= 0) sum += S[0][i--] - '0';
			if (j >= 0) sum += S[1][j--] - '0';
			R[k++] = (char)((sum % 10) + '0');
			carry = sum / 10;
		}

		for (int x = k - 1; x >= 0; x--)
		{
			sb.Append(R[x]);
		}

		Console.WriteLine(sb.ToString());
	}
}