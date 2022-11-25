var heights = new List<int> { 178, 191, 182, 180, 167, 172, 178, 191 ,188, 150, 180, 178 };
var persons = new List<string> {"John", "George", "Bob", "Joseph"};
//before linq:

//var max = heights[0];

//for (int i = 1; i < heights.Length; i++)
//{
//    if (heights[i] > max)
//    {
//        max = heights[i];
//    }
//}

//Console.WriteLine(heights.Max());
//Console.WriteLine(heights.Min());
//Console.WriteLine(heights.Count());
//Console.WriteLine(heights.Sum());
//Console.WriteLine(heights.Average());

//filtering Where

var highHeights = heights.Where(x => x >= 178);

var oddHeights = heights.Where(x => x%2 == 1);

var longNames = persons.Where(x => x.Length > 4);

//sorting (ordering) OrderBy, OrderByDescending

var orderedByValue = heights.OrderBy(x=>x);
var orderedByName = persons.OrderBy(x=>x);
var orderedByNameLength = persons.OrderBy(x => x.Length);


var orderedByValueDescending = heights.OrderByDescending(x => x);
var orderedByNameDescending = persons.OrderByDescending(x => x);
var orderedByNameLengthDescending = persons.OrderByDescending(x => x.Length);

//projection Select

var isHigh = heights.Select(x => x >= 178);
var ones = heights.Select(x => x % 10);
var capitalized = persons.Select(x => x.ToUpper());


var combination = heights
    .Where(x => x >= 178)
    .Select(x => x % 10)
    .OrderByDescending(x => x)
    .Distinct();

Display(combination);


void Display<T>(IEnumerable<T> input)
{
    foreach (var v in input) Console.WriteLine(v);
}