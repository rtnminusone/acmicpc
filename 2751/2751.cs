#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
int[] list = new int[N];
StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++)
{
	list[i] = int.Parse(Console.ReadLine());
}

Array.Sort(list);

for (int i = 0; i < N; i++)
{
	sb.Append(list[i] + "\n");
}

Console.WriteLine(sb);