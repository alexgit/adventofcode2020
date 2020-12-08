<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(@"d:\temp\input.txt").Select(ParseLine);	

	
	int counter = 0;
	foreach (var (policy, password) in lines) 
	{
		if(policy.Validate(password)) {
			counter++;
		}
	}
		
	counter.Dump();		
}

public class Policy {
	public char character;
	public int index1;
	public int index2;
	
	public bool Validate(string password) {
		char a = password[index1];
		char b = password[index2];
		
		return (a == character && b != character) || (a != character && b == character);
	}
}

static Regex regex = new Regex(@"([\d]+)-([\d]+) ([a-z]): ([a-z]+)", RegexOptions.Compiled);

static (Policy, string) ParseLine(string line) 
{
	var m = regex.Match(line);
	
	int index1 = int.Parse(m.Groups[1].Value) - 1;
	int index2 = int.Parse(m.Groups[2].Value) - 1;
	char character = m.Groups[3].Value[0];
	string password = m.Groups[4].Value;

	return (new Policy { index1 = index1, index2 = index2, character = character }, password);
}

