#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

char[] c = Console.ReadLine().ToCharArray();
StringBuilder sb = new StringBuilder();

String[] p = { "000", "001", "010", "011", "100", "101", "110", "111" };

for (int i = 0; i < c.Length; i++)
{
	sb.Append(p[c[i] - '0']);
 }

for (int i = 0; i < 2; i++)
{
	if (sb[0] == '0') sb.Remove(0, 1);
}

Console.WriteLine(sb);