#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

List<int> L = new List<int>();
string S = Console.ReadLine();

int R = 0;
StringBuilder sb = new StringBuilder();
foreach (char c in S)
{
	if (c == '-' || c == '+')
	{
		R += int.Parse(sb.ToString());
		sb.Clear();
		if (c == '-')
		{
			L.Add(R);
			R = 0;
		}
	}
	else sb.Append(c);
}
R += int.Parse(sb.ToString());
L.Add(R);

if (L.Count != 1) R = L[0];
for (int i = 1; i < L.Count; i++)
{
	R -= L[i];
}

Console.WriteLine(R);