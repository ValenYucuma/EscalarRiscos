namespace EscalarRisco.Data.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Weight { get; set; }
        public int Calories { get; set; }
    }
}

