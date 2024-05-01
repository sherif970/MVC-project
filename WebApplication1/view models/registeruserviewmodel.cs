using System.ComponentModel.DataAnnotations;

namespace WebApplication1.view_models
{
    public class registeruserviewmodel
    {
        public string username { get; set; }
        [DataType("password")]
        public string password { get; set; }
        [Compare("password")]
        public string confirmpassword { get; set; }
        public string address { get; set; }
    }
}
