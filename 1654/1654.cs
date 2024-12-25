#pragma warning disable CS8600, CS8601, CS8602, CS8604, CS8618

using System;

string[] S = Console.ReadLine().Split(' ');
int K = int.Parse(S[0]);
int N = int.Parse(S[1]);
long[] L = new long[K];

for (int i = 0; i < K; i++)
{
	L[i] = long.Parse(Console.ReadLine());
}

Array.Sort(L);

long T = 0;
long front = 1;
long rear = L[K - 1];
long mid = 0;
long R = 0;

while (front <= rear)
{
	mid = (front + rear) / 2;

	for (int i = 0; i < K; i++)
	{
		T += L[i] / mid;
	}
	if (T >= N)
	{
		R = mid;
		front = mid + 1;
	}
	else
	{
		rear = mid - 1;
	}
	T = 0;
}

Console.WriteLine(R);