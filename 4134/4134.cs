#pragma warning disable CS8600, CS8602, CS8604, CS8618

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
StringBuilder sb = new StringBuilder();

for (int i = 0; i < N; i++)
{
	long K = long.Parse(Console.ReadLine());
	bool flag = true;
	if (K < 2) K = 2;
	while (flag)
	{
		flag = false;
		for (int j = 2; j <= Math.Sqrt(K); j++)
		{
			if (K % j == 0)
			{
				K++;
				flag = true;
				break;
			}
		}
	}
	sb.AppendLine(K + "");
}

Console.WriteLine(sb);