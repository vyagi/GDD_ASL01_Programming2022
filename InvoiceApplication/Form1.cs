namespace InvoiceApplication
{
    public partial class InoviceAppMainForm : Form
    {
        public InoviceAppMainForm()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            var (lines, success) = ReadLinesFromFile(filePathTextBox.Text); //this is new school
            if (!success)
            {
                MessageBox.Show("File not accessible or does not exist");
                return;
            }

            Display(ParseLines(lines));
        }

        private void categoryButton_Click(object sender, EventArgs e)
        {
            var result = ReadLinesFromFile(filePathTextBox.Text); //this is old school
            if (!result.success)
            {
                MessageBox.Show("File not accessible or does not exist");
                return;
            }

            var dictionary = GroupByCategory(result.lines);

            var outputLines = ConvertToArrayForDisplay(dictionary);

            Display(outputLines);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //If we don't make it, this will be your homework
        }

        private (string[] lines, bool success) ReadLinesFromFile(string path)
        {
            try
            {
                return (File.ReadAllLines(path), true);
            }
            catch
            {
                return (Array.Empty<string>(), false);
            }
        }

        private string[] ParseLines(string[] lines)
        {
            var result = new List<string>();

            foreach (var line in lines) 
                result.Add(line.Replace(";", "\t") + Environment.NewLine);

            return result.ToArray();
        }

        private Dictionary<string, decimal> GroupByCategory(string[] lines)
        {
            var dictionary = new Dictionary<string, decimal>();

            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];

                var split = line.Split(";");

                var category = split[1];
                var price = Convert.ToDecimal(split[2].Replace(".", ","));

                if (dictionary.ContainsKey(category))
                {
                    dictionary[category] += price;
                }
                else
                {
                    dictionary[category] = price;
                }
            }

            return dictionary;
        }

        private string[] ConvertToArrayForDisplay(Dictionary<string, decimal> dictionary)
        {
            var result = new List<string>();

            result.Add($"Category\tTotal spent{Environment.NewLine}");

            foreach (var entry in dictionary)
            {
                result.Add($"{entry.Key}\t{entry.Value}{Environment.NewLine}");
            }
            
            return result.ToArray();
        }

        private void Display(string[] lines)
        {
            outputTextBox.Clear();

            foreach (var line in lines) 
                outputTextBox.Text += line;
        }
    }
}