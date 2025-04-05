namespace Estore.Models
{
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ClientId { get; set; }
    }
}
