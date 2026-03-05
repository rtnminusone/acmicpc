#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<char, bool> D = new Dictionary<char, bool>();
D['a'] = true;
D['e'] = true;
D['i'] = true;
D['o'] = true;
D['u'] = true;
int N = int.Parse(Console.ReadLine());
string S = Console.ReadLine();
int R = 0;
for (int i = 0; i < N; i++)
{
	if (D.ContainsKey(S[i])) R++;
}

Console.WriteLine(R);