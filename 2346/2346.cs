#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
string[] S = Console.ReadLine().Split(' ');
List<int[]> L = new List<int[]>();
StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++)
{
	L.Add(new int[] { (i + 1), int.Parse(S[i]) });
}

int P = 0;
int K = L[P][1];
if (K > 0) K--;
sb.Append("1 ");
L.RemoveAt(P);

while (L.Count > 1)
{
	P += K;
	while (P < 0)
	{
		P += L.Count;
	}
	while (P >= L.Count)
	{
		P -= L.Count;
	}
	K = L[P][1];
	if (K > 0) K--;
	sb.Append(L[P][0] + " ");
	L.RemoveAt(P);
}
if (L.Count == 1) sb.Append(L[0][0] + "");

Console.WriteLine(sb);