<Query Kind="Program" />

void Main()
{
	var lines = File
		.ReadAllLines(@"c:\temp\input.txt")
		.Select(l => l.ToCharArray())
		.ToArray();

	var slopes = new[] {
		(1, 1),
		(3, 1),
		(5, 1),
		(7, 1),
		(1, 2),
	};

	int product = 1;
	foreach (var (right, down) in slopes)
	{
		product *= CheckSlope(right, down, lines).Dump();
	}

	product.Dump();
}

int CheckSlope(int right, int down, char[][] lines)
{
	var lineLength = lines.First().Length;

	int horizontalPosition = 0;
	int counter = 0;

	for (var i = 1; i < lines.Length; i += down)
	{
		horizontalPosition += right;
		var c = lines[i][horizontalPosition % lineLength];

		if (c == '#')
			counter++;
	}

	return counter;
}