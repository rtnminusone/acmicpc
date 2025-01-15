#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
bool[] V = new bool[N];

List<int>[] L = new List<int>[N];
for (int i = 0; i < N; i++)
{
	L[i] = new List<int>();
}

for (int i = 0; i < M; i++)
{
	S = Console.ReadLine().Split();
	L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]) - 1);
	L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]) - 1);
}

int K = 0;
Queue<int> Q = new Queue<int>();
for (int i = 0; i < N; i++)
{
	if (!V[i])
	{
		K++;
		V[i] = true;
		Q.Enqueue(i);
		foreach (var t in L[i])
		{
			if (!V[t])
			{
				Q.Enqueue(t);
				V[t] = true;
			}
		}
	}
	while (Q.Count != 0)
	{
		int P = Q.Dequeue();
		foreach (var t in L[P])
		{
			if (!V[t])
			{
				Q.Enqueue(t);
				V[t] = true;
			}
		}
	}
}

if (M == 0) Console.WriteLine(N);
else Console.WriteLine(K);