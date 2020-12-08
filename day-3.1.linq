<Query Kind="Program" />

void Main()
{
	var lines = File
		.ReadAllLines(@"c:\temp\input.txt")
		.Select(l => l.ToCharArray())
		.ToArray();

	var lineLength = lines.First().Length;

	int right = 0;
	int counter = 0;

	for (var i = 1; i < lines.Length; i++)
	{
		right += 3;

		var c = lines[i][right % lineLength];

		if (c == '#')
			counter++;
	}
	
	counter.Dump();

}