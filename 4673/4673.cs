#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		bool[] b = new bool[10001];

		for (int i = 1; i < 10000; i++)
		{
			string s = i.ToString();
			int t = i;
			for (int j = 0; j < s.Length; j++)
			{
				t += s[j] - '0';
			}
			if (t <= 10000) b[t] = true;;
		}

		for (int i = 1; i <= 10000; i++)
		{
			if (!b[i]) sb.AppendLine(i.ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}