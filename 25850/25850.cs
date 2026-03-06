#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<char, int> PQ = new PriorityQueue<char, int>();

char C = 'A';
int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	for (int j = 1; j < S.Length; j++)
	{
		PQ.Enqueue((char)((int)C + i), int.Parse(S[j]));
	}
}

while (PQ.Count > 0)
{
	Console.Write(PQ.Dequeue());
}