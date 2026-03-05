#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

Dictionary<string, string> D = new Dictionary<string, string>();
D["M"] = "MatKor";
D["W"] = "WiCys";
D["C"] = "CyKor";
D["A"] = "AlKor";
D["$"] = "$clear";
Console.WriteLine(D[Console.ReadLine()]);