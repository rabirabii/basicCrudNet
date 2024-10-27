namespace BelajarWebApi_EntityFramework.Entities
{
    public class FirstModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string firstName { get; set; } = string.Empty;

        public string lastName { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;
    }
}
