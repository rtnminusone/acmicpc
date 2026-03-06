#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<char, int> D = new Dictionary<char, int>();

string S = Console.ReadLine();
for (int i = 0; i < S.Length; i++)
{
	if (!D.ContainsKey(S[i])) D[S[i]] = 1;
	else D[S[i]]++;
}
var L = D.Values.OrderBy(x => x).ToArray();
int t = D.Count, idx = 0, R = 0;
while (t-- > 2)
{
	R += L[idx++];
}

Console.WriteLine(R);