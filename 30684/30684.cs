#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<string, string> PQ = new PriorityQueue<string, string>();

int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	string S = Console.ReadLine();
	if (S.Length != 3) continue;
	PQ.Enqueue(S, S);
}

Console.WriteLine(PQ.Dequeue());