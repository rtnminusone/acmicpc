#pragma warning disable CS8600, CS8602, CS8604

string[] s = Console.ReadLine().Split();

if (int.Parse(s[0]) - int.Parse(s[1]) > 0) Console.WriteLine(">");
else if (int.Parse(s[0]) - int.Parse(s[1]) < 0) Console.WriteLine("<");
else Console.WriteLine("==");