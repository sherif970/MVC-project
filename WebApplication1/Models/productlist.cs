namespace WebApplication1.Models
{
    public class productlist
    {
        List<product> products;

        public productlist()
        {
            products = new List<product>();
            products.Add(new product() { Id=1 ,name = "phone1",description="ipone",image="1.jpg",price=1000});
            products.Add(new product() { Id = 2, name = "phone2", description = "samsoung", image = "2.jpg", price = 500 });
            products.Add(new product() { Id = 3, name = "phone3", description = "oppo", image = "1.jpg", price = 300 });
        }
        public product getbyid(int id)
        {
            product pro = new product();
            pro = products.SingleOrDefault(p => p.Id == id);
            return pro;
        }
        public List<product> getall()
        {
            return products ;
        }
    }
}
