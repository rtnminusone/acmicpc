#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int A = int.Parse(Console.ReadLine());
int B = int.Parse(Console.ReadLine());
if (A == B) Console.WriteLine(0);
else Console.WriteLine(A > B ? 1 : -1);