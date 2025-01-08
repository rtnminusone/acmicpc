#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();
bool[] B = new bool[20];
int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	switch (S[0])
	{
		case "add":
			B[int.Parse(S[1]) - 1] = true;
			break;
		case "remove":
			B[int.Parse(S[1]) - 1] = false;
			break;
		case "check":
			if (B[int.Parse(S[1]) - 1]) sb.AppendLine("1");
			else sb.AppendLine("0");
			break;
		case "toggle":
			B[int.Parse(S[1]) - 1] = !B[int.Parse(S[1]) - 1];
			break;
		case "all":
			Array.Fill(B, true);
			break;
		case "empty":
			Array.Fill(B, false);
			break;
	}
}

Console.WriteLine(sb);