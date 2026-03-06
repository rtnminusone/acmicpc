#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<char, int> D = new Dictionary<char, int>();
D['A'] = 0;
D['B'] = 0;

int N = int.Parse(Console.ReadLine());
string S = Console.ReadLine();
for (int i = 0; i < N; i++)
{
	D[S[i]]++;
}

if (D['A'] == D['B']) Console.WriteLine("Tie");
else Console.WriteLine(D['A'] > D['B'] ? "A" : "B");