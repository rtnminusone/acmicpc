#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

string Make(int N)
{
	StringBuilder sb = new StringBuilder();

	for (int i = 0; i < N; i++)
	{
		sb.Append("IO");
	}
	sb.Append("I");

	return sb.ToString();
}

int[] MakeT(string P)
{
	int[] T = new int[P.Length];

	int p = 0;

	for (int i = 1; i < P.Length; i++)
	{
		while (p > 0 && P[i] != P[p])
		{
			p = T[p - 1];
		}
		if (P[i] == P[p]) T[i] = ++p;
	}

	return T;
}

int KMP(string S, string P, int[] T)
{
	int R = 0, p = 0;

	for (int i = 0; i < S.Length; i++)
	{
		while (p > 0 && S[i] != P[p])
		{
			p = T[p - 1];
		}
		if (S[i] == P[p])
		{
			if (p == P.Length - 1)
			{
				R++;
				p = T[p];
			}
			else p++;
		}
	}

	return R;
}

int N = int.Parse(Console.ReadLine());
int M = int.Parse(Console.ReadLine());
string S = Console.ReadLine();

string P = Make(N);
int[] T = MakeT(P);

Console.WriteLine(KMP(S, P, T));

/*
int N = int.Parse(Console.ReadLine());
int M = int.Parse(Console.ReadLine());
string S = Console.ReadLine();

int P = 2 * N + 1;
int C = 0;
int R = 0;

while (C <= M - P)
{
	if (S[C] == 'I')
	{
		bool F = true;
		for (int i = 1; i < P; i += 2)
		{
			if (S[C + i] != 'O' || S[C + i + 1] != 'I')
			{
				F = false;
				break;
			}
		}
		if (F)
		{
			R++;
			C += 2;
		}
		else C++;
	}
	else C++;
}

Console.WriteLine(R);
*/