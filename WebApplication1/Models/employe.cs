using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class employe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }
        public string? adreess { get; set; }
        public string? iamge { get; set; }

        [ForeignKey("department")]
        public int dept_id { get; set; }
        public virtual department? department { get; set; }
    }
}
