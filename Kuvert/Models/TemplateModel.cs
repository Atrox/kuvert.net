namespace Kuvert.Models
{
    public class TemplateModel
    {
        public Email Email { get; set; }
        public Product Product { get; set; }

        public TemplateModel(Email email, Product product)
        {
            Email = email;
            Product = product;
        }
    }
}
