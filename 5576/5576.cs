#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();

for (int i = 0; i < 10; i++)
{
	int k = int.Parse(Console.ReadLine());
	PQ.Enqueue(k, -k);
}
int R = PQ.Dequeue() + PQ.Dequeue() + PQ.Dequeue();
PQ.Clear();
for (int i = 10; i < 20; i++)
{
	int k = int.Parse(Console.ReadLine());
	PQ.Enqueue(k, -k);
}

Console.WriteLine(R + " " + (PQ.Dequeue() + PQ.Dequeue() + PQ.Dequeue()));