#pragma warning disable CS8600, CS8602, CS8604

int i = int.Parse(Console.ReadLine());
string[] s = Console.ReadLine().Split();
int j = int.Parse(Console.ReadLine());
int k = 0;

for (int l = 0; l < i; l++) {
	if (j == int.Parse(s[l])) k++;
}

Console.WriteLine(k);