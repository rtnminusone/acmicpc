#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<string, (int, string)> PQ = new PriorityQueue<string, (int, string)>();

int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	string[] S = Console.ReadLine().Split();
	PQ.Enqueue(S[0], (-int.Parse(S[1]), S[0]));
}

Console.WriteLine(PQ.Dequeue());