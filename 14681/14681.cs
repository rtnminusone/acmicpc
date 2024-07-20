#pragma warning disable CS8600, CS8602, CS8604

int i = int.Parse(Console.ReadLine());
int j = int.Parse(Console.ReadLine());
int k;

if (i > 0) {
	if (j > 0) k = 1;
	else k = 4;
}
else {
	if (j > 0) k = 2;
	else k = 3;
}

Console.WriteLine(k);