#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

List<int> L = new List<int>();
StringBuilder sb = new StringBuilder();
string[] S = Console.ReadLine().Split(' ');
int N = int.Parse(S[0]);
int K = int.Parse(S[1]);
int I = K - 1;

for (int i = 1; i <= N; i++)
{
	L.Add(i);
}

sb.Append("<" + L[I]);
L.RemoveAt(I);

while (L.Count != 1 && L.Count > 0)
{
	I = (I + K - 1) % L.Count;
	sb.Append(", " + L[I]);
	L.RemoveAt(I);
}

if (L.Count == 0) Console.WriteLine(sb + ">");
else Console.WriteLine(sb + ", " + L[0] + ">");