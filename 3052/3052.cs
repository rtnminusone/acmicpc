#pragma warning disable CS8600, CS8602, CS8604

bool[] r = new bool[42];
int k = 0;

for (int i = 0; i < 10; i++) {
	r[int.Parse(Console.ReadLine()) % 42] = true;
}

for (int i = 0; i < 42; i++) {
	if (r[i]) k++;
}

Console.WriteLine(k);