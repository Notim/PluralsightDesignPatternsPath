namespace Command.Business.Repositories
{

    public interface IProductRepository
    {

        Product GetProduct(int productId);

        void DecreaseStock(int productId, int quantity);

        void IncreaseStock(int productId, int quantity);

        int GetStock(int productId);

    }

}