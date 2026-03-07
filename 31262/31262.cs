#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

PriorityQueue<char, char> PQ1 = new PriorityQueue<char, char>();
PriorityQueue<int, int> PQ2 = new PriorityQueue<int, int>();

string S = Console.ReadLine();
for (int i = 0; i < 6; i++)
{
	if (i < 3) PQ1.Enqueue(S[i], S[i]);
	else PQ2.Enqueue(S[i] - '0', -(S[i] - '0'));
}
for (int i = 0; i < 3; i++)
{
	Console.Write(PQ1.Dequeue());
	Console.Write(PQ2.Dequeue());
}