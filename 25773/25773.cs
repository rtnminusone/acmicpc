#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<char, int> PQ = new PriorityQueue<char, int>();

string S = Console.ReadLine();
for (int i = 0; i < S.Length; i++)
{
	PQ.Enqueue(S[i], -S[i]);
}

for (int i = 0; i < S.Length; i++)
{
	Console.Write(PQ.Dequeue());
}