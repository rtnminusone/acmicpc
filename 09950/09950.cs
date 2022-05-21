#pragma warning disable CS8600, CS8602, CS8604

using System;
using System.Text;

StringBuilder sb = new StringBuilder();

while (true)
{
    string[] buf = Console.ReadLine().Split();

    if (buf[2].Equals("0") && int.Parse(buf[0]) != 0)
    {
        sb.AppendFormat("{0} {1} {2}\n", buf[0], buf[1], int.Parse(buf[0]) * int.Parse(buf[1]));
    }
    else if (int.Parse(buf[2]) != 0)
    {
        if (buf[0].Equals("0")) sb.AppendFormat("{0} {1} {2}\n", int.Parse(buf[2]) / int.Parse(buf[1]), buf[1], buf[2]);
        else sb.AppendFormat("{0} {1} {2}\n", buf[0], int.Parse(buf[2]) / int.Parse(buf[0]), buf[2]);
    }
    else break;
}

Console.WriteLine(sb);