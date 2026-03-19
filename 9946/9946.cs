#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

StringBuilder sb = new StringBuilder();
int idx = 1;

while (true)
{
	string S1 = Console.ReadLine();
	string S2 = Console.ReadLine();
	if (S1.Equals("END") && S1.Equals(S2)) break;
	sb.Append("Case " + (idx++) + ": ");
	if (S1.Length != S2.Length) sb.AppendLine("different");
	else
	{
		char[] C1 = S1.ToCharArray();
		char[] C2 = S2.ToCharArray();
		Array.Sort(C1);
		Array.Sort(C2);
		if (new String(C1).Equals(new String(C2))) sb.AppendLine("same");
		else sb.AppendLine("different");
	}
}

Console.WriteLine(sb);