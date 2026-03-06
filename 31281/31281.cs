#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<long, long> PQ = new PriorityQueue<long, long>();

string[] S = Console.ReadLine().Split();
for (int i = 0; i < 3; i++)
{
	long k = long.Parse(S[i]);
	PQ.Enqueue(k, k);
}
PQ.Dequeue();

Console.WriteLine(PQ.Dequeue());