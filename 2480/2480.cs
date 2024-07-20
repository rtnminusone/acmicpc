#pragma warning disable CS8600, CS8602, CS8604

using System;

string[] s = Console.ReadLine().Split();
int[] i = new int[]{int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2])};

if (i[0] == i[1] && i[0] == i[2]) Console.WriteLine(10000 + i[0] * 1000);
else if (i[0] != i[1] && i[0] != i[2] && i[1] != i[2]) Console.WriteLine(i.Max() * 100);
else {
	if (i[0] == i[1]) Console.WriteLine(1000 + i[0] * 100);
	else if (i[0] == i[2]) Console.WriteLine(1000 + i[0] * 100);
	else Console.WriteLine(1000 + i[1] * 100);
}