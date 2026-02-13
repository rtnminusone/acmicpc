#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static Dictionary<long, long> D = new Dictionary<long, long>();

	public static long Reverse(long x)
	{
		long r = 0;

		while (x > 0)
		{
			r = r * 10 + (x % 10);
			x /= 10;
		}

		return r;
	}

	public static long Solve(long n)
	{
		if (n < 10) return n;
		if (D.TryGetValue(n, out var cached)) return cached;
		if (n % 10 == 0)
		{
			long v = 1 + Solve(n - 1);
			D[n] = v;

			return v;
		}

		long x = 1;

		while (x * 10 <= n)
		{
			x *= 10;
		}

		long r = Math.Min(n, Solve(x) + (n - x));
		string s = n.ToString();

		for (int i = 1; i <= s.Length; i++)
		{
			string pre = s.Substring(0, i);
			string post = s.Substring(i);
			char[] arr = pre.ToCharArray();
			Array.Reverse(arr);
			long preRev = long.Parse(new string(arr));
			long tmp = preRev - 1;

			if (post.Length > 0) tmp += long.Parse(post);

			r = Math.Min(r, Solve(x) + tmp + 1);
		}

		D[n] = r;

		return r;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int n = int.Parse(Console.ReadLine());
		for (int a = 1; a <= n; a++)
		{
			sb.AppendLine("Case #" + a + ": " + Solve(long.Parse(Console.ReadLine())));
		}

		Console.WriteLine(sb.ToString());
	}
}