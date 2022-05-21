#pragma warning disable CS8600, CS8602, CS8604

string[] buf = Console.ReadLine().Split();
int M = int.Parse(buf[0]) / 2;

if (M >= int.Parse(buf[1]))
{
    if (M >= int.Parse(buf[2])) Console.WriteLine((int.Parse(buf[0]) - int.Parse(buf[1])) * (int.Parse(buf[0]) - int.Parse(buf[2])) * 4);
    else Console.WriteLine((int.Parse(buf[0]) - int.Parse(buf[1])) * int.Parse(buf[2]) * 4);
}
else
{
    if (M >= int.Parse(buf[2])) Console.WriteLine(int.Parse(buf[1]) * (int.Parse(buf[0]) - int.Parse(buf[2])) * 4);
    else Console.WriteLine(int.Parse(buf[1]) * int.Parse(buf[2]) * 4);
}