#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

int MAX = 123456 * 2;
bool[] B = new bool[MAX + 1];
StringBuilder sb = new StringBuilder();

for (long i = 2; i <= MAX; i++)
{
	for (long j = i; i * j <= MAX; j++)
	{
		B[i * j] = true;
	}
}

while (true)
{
	int N = int.Parse(Console.ReadLine());
	if (N == 0) break;

	int C = 0;

	for (int i = N + 1; i <= N * 2; i++)
	{
		if (!B[i]) C++;
	}

	sb.AppendLine(C + "");
}

Console.WriteLine(sb);