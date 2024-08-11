#pragma warning disable CS8600, CS8602, CS8604

int[] a = { 1, 1, 2, 2, 2, 8 };
string[] s = Console.ReadLine().Split();

for (int i = 0; i < 6; i++) {
	Console.Write(a[i] - int.Parse(s[i]) + " ");
}