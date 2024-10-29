#pragma warning disable CS8600, CS8602, CS8604

using System;

int N = int.Parse(Console.ReadLine());
int[] M = new int[N];
int[] K = new int[N - 1];
int C = 0;
int R = 0;

for (int i = 0; i < N; i++)
{
	M[i] = int.Parse(Console.ReadLine());
}

for (int i = 0; i < N - 1; i++)
{
	K[i] = M[i + 1] - M[i];
}

Array.Sort(K);

for (int i = K[0]; i > 0; i--)
{
	bool t = true;
	for (int j = 0; j < N - 1; j++)
	{
		if (K[j] % i != 0)
		{
			t = false;
			break;
		}
	}
	if (t)
	{
		C = i;
		break;
	}
}

for (int i = M[0]; i <= M[N - 1]; i += C)
{
	R++;
}

Console.WriteLine(R - M.Length);