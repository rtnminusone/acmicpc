#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;
using System.Text;

string[] S = Console.ReadLine().Split();

int N = int.Parse(S[0]);
int M = int.Parse(S[1]);

StringBuilder sb = new StringBuilder();

int[] K = new int[N];
int[] Section = new int[N + 1];

S = Console.ReadLine().Split();
K[0] = int.Parse(S[0]);
Section[0] = 0;
Section[1] = K[0];
for (int i = 1; i < N; i++)
{
	K[i] = int.Parse(S[i]);
	Section[i + 1] = Section[i] + K[i];
}

for (int i = 0; i < M; i++)
{
	S = Console.ReadLine().Split();
	sb.AppendLine(Section[int.Parse(S[1])] - Section[int.Parse(S[0]) - 1] + "");
}

Console.WriteLine(sb);