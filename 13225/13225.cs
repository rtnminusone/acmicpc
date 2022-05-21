#pragma warning disable CS8600, CS8602, CS8604

using System.Text;
using System;

StringBuilder sb = new StringBuilder();

int N = int.Parse(Console.ReadLine());

for (int i = 0; i < N; i++)
{
    int M = int.Parse(Console.ReadLine());
    int R = 0;
    for (int j = 1; j < M; j++)
    {
        if (M % j == 0) R++;
    }
    sb.AppendFormat("{0} {1}\n", M, R + 1);
}

Console.WriteLine(sb);