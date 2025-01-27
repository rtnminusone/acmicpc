#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
int M = int.Parse(Console.ReadLine());
int[,] T = new int[N, N];
int[] R = new int[2];
StringBuilder sb = new StringBuilder();

int cur = N * N;
int x = 0;
int y = 0;
int dir = 0;
int[,] D = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

for (int i = 0; i < N * N; i++)
{
	if (cur == M)
	{
		R[0] = x + 1;
		R[1] = y + 1;
	}
	T[x, y] = cur--;

	int nX = x + D[dir, 0];
	int nY = y + D[dir, 1];
	while (nX < 0 || nY < 0 || nX >= N || nY >= N || T[nX, nY] != 0)
	{
		if (x == N / 2 && y == N / 2) break;
		dir++;
		if (dir > 3) dir = 0;
		nX = x + D[dir, 0];
		nY = y + D[dir, 1];
	}
	
	x = nX;
	y = nY;
}

for (int i = 0; i < N; i++)
{
	for (int j = 0; j < N; j++)
	{
		sb.Append(T[i, j] + " ");
	}
	sb.AppendLine();
}
sb.AppendLine(R[0] + " " + R[1]);

Console.WriteLine(sb);