#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

char[] S = Console.ReadLine().ToCharArray();
HashSet<string> H = new HashSet<string>();
StringBuilder sb = new StringBuilder();

for (int i = 0; i < S.Length; i++)
{
	for (int j = i + 1; j <= S.Length; j++)
	{
		sb.Clear();
		for (int k = i; k < j; k++)
		{
			sb.Append(S[k]);
		}
		H.Add(sb.ToString());
	}
}

Console.WriteLine(H.Count);