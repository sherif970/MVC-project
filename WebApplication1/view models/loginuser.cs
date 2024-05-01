using System.ComponentModel.DataAnnotations;

namespace WebApplication1.view_models
{
    public class loginuser
    {
        public string name {  get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}
