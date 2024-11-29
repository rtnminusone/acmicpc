#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
int[] K = new int[N];
int[] C = new int[8001];
List<int> L = new List<int>();
double S = 0;
int K1 = -1;
int K2 = -1;

for (int i = 0; i < N; i++)
{
	K[i] = int.Parse(Console.ReadLine());
	C[K[i] + 4000]++;
	S += K[i];
}

for (int i = 0; i <= 8000; i++)
{
	if (C[i] == K1) L.Add(i - 4000);
	else if (C[i] > K1)
	{
		K1 = C[i];
		L.Clear();
		K2 = i - 4000;
		L.Add(K2);
	}
}

Array.Sort(K);

Console.WriteLine((int)Math.Round(S / N));
Console.WriteLine(K[N / 2]);
if (L.Count > 1)
{
	L.Sort();
	Console.WriteLine(L[1]);
}
else Console.WriteLine(K2);
Console.WriteLine(K[N - 1] - K[0]);