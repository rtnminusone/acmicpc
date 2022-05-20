#pragma warning disable CS8602, CS8604

int N = int.Parse(Console.ReadLine());

int[] A = new int[N];
int[] B = new int[N];

string[] buf = Console.ReadLine().Split();

for (int i = 0; i < N; i++)
{
    A[i] = int.Parse(buf[i]);
}

Array.Clear(buf);

buf = Console.ReadLine().Split();

for (int i = 0; i < N; i++)
{
    B[i] = int.Parse(buf[i]);
}

Array.Sort(A);
Array.Sort(B);
Array.Reverse(B);

int S = 0;

for (int i = 0; i < N; i++)
{
    S += A[i] * B[i];
}

Console.WriteLine(S);