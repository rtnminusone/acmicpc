#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

StringBuilder sb = new StringBuilder();
int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split(' ');
	int D = int.Parse(S[1]) - int.Parse(S[0]);
	int K = (int)Math.Sqrt(D);
	if (D == K * K) sb.AppendLine(K * 2 - 1 + "");
	else if (D <= K * K + K) sb.AppendLine(K * 2 + "");
	else sb.AppendLine(K * 2 + 1 + "");
}

Console.WriteLine(sb);