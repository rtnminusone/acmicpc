#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

int N = int.Parse(Console.ReadLine());
int ans = N;

for (int i = 0; i < N; i++)
{
	string s = Console.ReadLine();
	char c = s[0];
	int[] check = new int[26];
	check[c - 'a']++;

	for (int j = 1; j < s.Length; j++)
	{
		if (s[j] == c) continue;
		c = s[j];
		if (++check[c - 'a'] > 1)
		{
			ans--;
			break;
		}
	}
}

Console.WriteLine(ans);