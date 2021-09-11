namespace Command.Business.Repositories
{

    public interface IShoppingCartRepository
    {

        CartItem Get(int Id);

        void Add(Product product, int quantity);

        void IncreaseQuantity(int Id, int quantity);

        void RemoveAll(int Id);

        void DescreseQuantity(int Id, int quantity);

    }

}