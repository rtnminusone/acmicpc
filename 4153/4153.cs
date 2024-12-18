#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();

while (true)
{
	string[] S = Console.ReadLine().Split(' ');
	long[] B = new long[3] { long.Parse(S[0]), long.Parse(S[1]), long.Parse(S[2]) };
	if (B[0] == 0) break;
	Array.Sort(B);

	if (B[0] * B[0] + B[1] * B[1] == B[2] * B[2]) sb.AppendLine("right");
	else sb.AppendLine("wrong");
}

Console.WriteLine(sb);