namespace EcommerceApp.Core.Models.ProductStocks
{
    public class ProductStock<T>
    {
        public T Size { get; set; }
        public int Quantity { get; set; }
    }
}
