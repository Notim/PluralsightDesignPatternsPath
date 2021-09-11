namespace Command.Business.Repositories
{

    public class ProductRepositoryMocked : IProductRepository
    {

        private readonly Product _product = new(Id: 54688611, Name: "Rice", Price: (decimal) 10.50);

        private int Stock = 5;

        public Product GetProduct(int productId)
        {
            return _product;
        }

        public void DecreaseStock(int productId, int quantity)
        {
            Stock -= quantity;
        }

        public void IncreaseStock(int productId, int quantity)
        {
            Stock += quantity;
        }

        public int GetStock(int productId)
        {
            return Stock;
        }

    }

}