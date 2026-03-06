#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

List<int> L1 = new List<int>();
List<int> L2 = new List<int>();

string[] S = Console.ReadLine().Split();
for (int i = 0; i < 5; i++)
{
	L1.Add(int.Parse(S[i]));
}
S = Console.ReadLine().Split();
for (int i = 0; i < 5; i++)
{
	L2.Add(int.Parse(S[i]));
}
L1.Sort();
L2.Sort();
int R = 0;
for (int i = 0; i < 5; i++)
{
	if (L1[i] > L2[i]) R++;
}

Console.WriteLine(R);