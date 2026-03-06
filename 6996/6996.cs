#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

StringBuilder sb = new StringBuilder();
int T = int.Parse(Console.ReadLine());
while (T-- > 0)
{
	string[] S = Console.ReadLine().Split();
	if (S[0].Length != S[1].Length)
	{
		sb.AppendLine(S[0] + " & " + S[1] + " are NOT anagrams.");
		continue;
	}
	char[] A = S[0].ToCharArray();
	char[] B = S[1].ToCharArray();
	Array.Sort(A);
	Array.Sort(B);
	bool flg = false;
	for (int i = 0; i < S[0].Length; i++)
	{
		if (A[i] != B[i]) flg = true;
	}
	if (flg) sb.AppendLine(S[0] + " & " + S[1] + " are NOT anagrams.");
	else sb.AppendLine(S[0] + " & " + S[1] + " are anagrams.");
}

Console.WriteLine(sb.ToString());