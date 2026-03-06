#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<string, double> PQ = new PriorityQueue<string, double>();

int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	string S = Console.ReadLine();
	PQ.Enqueue(S, double.Parse(S));
}
PQ.Dequeue();

Console.WriteLine(PQ.Dequeue());