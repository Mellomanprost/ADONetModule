namespace SF.EF.DAL
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Company Company { get; set; } = null!;

        public List<Post> Post { get; set; } = null!;
    }
}