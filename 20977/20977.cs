#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

StringBuilder sb = new StringBuilder();
int N = int.Parse(Console.ReadLine());
int[] T = new int[3];
string[] K = new string[3] { "J", "O", "I" };
string S = Console.ReadLine();
for (int i = 0; i < N; i++)
{
	if (S[i] == 'J') T[0]++;
	else if (S[i] == 'O') T[1]++;
	else T[2]++;
}

for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < T[i]; j++)
	{
		sb.Append(K[i]);
	}
}

Console.WriteLine(sb.ToString());