#pragma warning disable CS8600, CS8602, CS8604

bool[] r = new bool[30];

for (int i = 0; i < 28; i++) {
	r[int.Parse(Console.ReadLine()) - 1] = true;
}

for (int i = 0; i < 30; i++) {
	if (!r[i]) Console.WriteLine(i + 1);
}