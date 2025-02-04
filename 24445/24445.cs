#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split();
int N = int.Parse(S[0]);
int M = int.Parse(S[1]);
int K = int.Parse(S[2]);
int[] R = new int[N];
bool[] V = new bool[N];
List<int>[] L = new List<int>[N];
Queue<int> Q = new Queue<int>();

for (int i = 0; i < N; i++)
{
	L[i] = new List<int>();
}

for (int i = 0; i < M; i++)
{
	S = Console.ReadLine().Split();
	L[int.Parse(S[0]) - 1].Add(int.Parse(S[1]));
	L[int.Parse(S[1]) - 1].Add(int.Parse(S[0]));
}

for (int i = 0; i < N; i++)
{
	L[i].Sort();
	L[i].Reverse();
}

Q.Enqueue(K);
V[K - 1] = true;
int r = 1;

while (Q.Count != 0)
{
	int q = Q.Dequeue();
	R[q - 1] = r++;

	foreach (int l in L[q - 1])
	{
		if (!V[l - 1])
		{
			Q.Enqueue(l);
			V[l - 1] = true;
		}
	}
}

Console.WriteLine(String.Join("\n", R));