using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Command.Business.Repositories
{

    public class ShoppingCartRepositoryMocked : IShoppingCartRepository
    {

        private IList<CartItem> _list = new List<CartItem>();

        public CartItem Get(int Id)
        {
            return _list.FirstOrDefault(x => x.Id == Id);
        }

        public void Add(Product product, int quantity)
        {
            _list.Add(new CartItem(product.Id, product.Name, product.Price, quantity));
        }

        public void IncreaseQuantity(int Id, int quantity)
        {
            _list = _list.Where(x => x.Id == Id).Select(item => item with{
                Quantity = item.Quantity + quantity
            }).ToList();
        }

        public void DescreseQuantity(int Id, int quantity)
        {
            _list = _list.Where(x => x.Id == Id).Select(item => item with{
                Quantity = item.Quantity - quantity
            }).ToList();
        }

        public void RemoveAll(int Id)
        {
            var item = _list.FirstOrDefault(x => x.Id == Id);

            if (item is not null) {
                _list.Remove(item);
            }
        }

    }

}