#pragma warning disable CS8600, CS8602, CS8604

string[] s = Console.ReadLine().Split();
int i = int.Parse(s[0]);
int j = int.Parse(s[1]);
j += int.Parse(Console.ReadLine());

if (j >= 60) {
	i += j / 60;
	j %= 60;
	if (i >= 24) i %= 24;
}

Console.WriteLine(i + " " + j);