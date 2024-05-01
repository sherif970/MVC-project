namespace WebApplication1.Models
{
    public class department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string managername { get; set; }
        public List<employe> employees { get; set; }
    }
}
