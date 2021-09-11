using System;

using Command.Business.Repositories;

namespace Command.Business.Commands.Vendors
{

    public class AddToCartCommand : ICommand
    {

        private readonly IProductRepository _productRepository;

        private readonly IShoppingCartRepository _shoppingCartRepository;

        private readonly Product _product;
        private readonly int     _quantity;

        public AddToCartCommand(Product product, int quantity, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _product = product;
            _quantity = quantity;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Execute()
        {
            Console.WriteLine(@$"[{this.GetType().Name}] - Executing command adding {_product.Id} {_quantity}");
            _productRepository.DecreaseStock(_product.Id, _quantity);
            _shoppingCartRepository.Add(_product, _quantity);
        }

        public bool CanExecute()
        {
            var onStock = _productRepository.GetStock(_product.Id);

            if (onStock > 0 && _quantity <= onStock) {
                Console.WriteLine(@$"[{this.GetType().Name}] - Can Execute Command {_product.Id} {_quantity}");
                return true;
            }

            Console.WriteLine(@$"[{this.GetType().Name}] - Cannot Execute Command {_product.Id} {_quantity}");

            return false;
        }

        public void Undo()
        {
            Console.WriteLine(@$"[{this.GetType().Name}] - Executing rollback command adding {_product.Id} {_quantity}");
            var lineItem = _shoppingCartRepository.Get(_product.Id);
            _productRepository.IncreaseStock(lineItem.Id, lineItem.Quantity);
            _shoppingCartRepository.RemoveAll(lineItem.Id);
        }

    }

}