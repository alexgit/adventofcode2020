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
	
	var p = new Policy() { character = 'b', min = 3, max = 4 };
	p.Validate("bmngrgttz").Dump();
	
	counter.Dump();		
}

public class Policy {
	public char character;
	public int min;
	public int max;
	
	public bool Validate(string password) {
		int counter = 0;
		foreach(var c in password) {
			if(c == character) {
				counter++;
				
				if(counter > max) {
					return false;
				}
			}
		}
		
		return counter >= min && counter <= max;
	}
}

static Regex regex = new Regex(@"([\d]+)-([\d]+) ([a-z]): ([a-z]+)", RegexOptions.Compiled);

static (Policy, string) ParseLine(string line) 
{
	var m = regex.Match(line);
	
	int min = int.Parse(m.Groups[1].Value);
	int max = int.Parse(m.Groups[2].Value);
	char character = m.Groups[3].Value[0];
	string password = m.Groups[4].Value;

	return (new Policy { min = min, max = max, character = character }, password);
}

