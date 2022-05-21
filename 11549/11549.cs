#pragma warning disable CS8600, CS8602, CS8604

using System.Text;
using System;

string N = Console.ReadLine();
string[] buf = Console.ReadLine().Split();
int R = 0;

for (int i = 0; i < 5; i++)
{
    if (buf[i].Equals(N)) R++;
}

Console.WriteLine(R);