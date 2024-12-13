#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

string[] S = Console.ReadLine().Split();
int a1 = int.Parse(S[0]);
int a0 = int.Parse(S[1]);
int c = int.Parse(Console.ReadLine());
int n0 = int.Parse(Console.ReadLine());

bool B = true;
for (int i = n0; i <= 100000; i++)
{
	if (a1 * i + a0 > c * i)
	{
		B = false;
		break;
	}
}

if (B) Console.WriteLine(1);
else Console.WriteLine(0);