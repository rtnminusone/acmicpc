#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();

int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
	int k = int.Parse(Console.ReadLine());
	PQ.Enqueue(k, -k);
}
int Limit = Math.Min(PQ.Count, 42);
int R1 = 0, R2 = 0;
for (int i = 0; i < Limit; i++)
{
	int k = PQ.Dequeue();
	R1 += k;
	if (60 <= k && k < 100) R2++;
	else if (100 <= k && k < 140) R2 += 2;
	else if (140 <= k && k < 200) R2 += 3;
	else if (200 <= k && k < 250) R2 += 4;
	else if (250 <= k) R2 += 5;
}

Console.WriteLine(R1 + " " + R2);