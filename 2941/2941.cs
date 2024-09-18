#pragma warning disable CS8600, CS8602, CS8604

using System.Text;
using System;

String N = Console.ReadLine();
int count = 0;

for (int i = 0; i < N.Length; i++)
{
	if (N[i] == 'c')
	{
		if (N.Length - 1 >= i + 1 && N[i + 1] == '=') i++;
		else if (N.Length - 1 >= i + 1 && N[i + 1] == '-') i++;
	}
	else if (N[i] == 'd')
	{
		if (N.Length - 1 >= i + 1 && N[i + 1] == '-') i++;
		else if (N.Length - 1 >= i + 2 && N.Substring(i, 3).Equals("dz=")) i += 2;
	}
	else if (N[i] == 'l' || N[i] == 'n')
	{
		if (N.Length - 1 >= i + 1 && N[i + 1] == 'j') i++;
	}
	else if (N[i] == 's' || N[i] == 'z')
	{
		if (N.Length - 1 >= i + 1 && N[i + 1] == '=') i++;
	}

	count++;
}

Console.WriteLine(count);
