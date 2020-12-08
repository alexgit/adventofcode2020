<Query Kind="Program" />

void Main()
{
	var numbers = File.ReadAllLines(@"d:\temp\input.txt").Select(int.Parse).ToArray();
	// Array.Sort(numbers);

	var (a, b, c) = ThreeSum(numbers, 2020).Dump();

	(a * b * c).Dump();
}

static (int, int, int) ThreeSum(int[] numbers, int targetValue)
{


	foreach (var number in numbers)
	{
		var twoSumTarget = targetValue - number;

		var (a, b) = TwoSum(numbers, twoSumTarget);

		if (a == -1)
			continue;

		return (a, b, number);
	}

	throw new Exception("no two sum found");

}

static (int, int) TwoSum(int[] numbers, int targetValue)
{
	var dict = new Dictionary<int, int>(numbers.Length);

	for (var i = 0; i < numbers.Length; i++)
	{
		dict.Add(numbers[i], i);
	}

	for (var i = 0; i < numbers.Length; i++)
	{
		var numberToLookFor = targetValue - numbers[i];

		if (dict.TryGetValue(numberToLookFor, out _))
		{
			return (numbers[i], numberToLookFor);
		}
	}

	return (-1, -1);
}