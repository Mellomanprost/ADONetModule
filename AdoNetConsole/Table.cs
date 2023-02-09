namespace AdoNetConsole
{
    public class Table
    {
        public string Name { get; set; }
        public List<string> Fields { get; set; }
        public string ImportantField { get; set; }

        public Table()
        {
            Fields = new List<string>();
        }
    }
}
