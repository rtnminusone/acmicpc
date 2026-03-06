#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

int A = int.Parse(Console.ReadLine());
int B = int.Parse(Console.ReadLine());
int C = int.Parse(Console.ReadLine());
int D = int.Parse(Console.ReadLine());
int P = int.Parse(Console.ReadLine());

int X = A * P;
int Y = P <= C ? B : B + (P - C) * D;

Console.WriteLine(Math.Min(X, Y));