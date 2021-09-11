using System;

using Command.Business.Repositories;

namespace Command.Business.Commands.Vendors
{

    public class DecreaseToCartCommand : ICommand
    {
        private readonly IProductRepository      _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        private readonly int _id;
        private readonly int _quantity;

        public DecreaseToCartCommand(int id,
                                     int quantity, 
                                     IProductRepository productRepository,
                                     IShoppingCartRepository shoppingCartRepository)
        {
            _id = id;
            _quantity = quantity;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Execute()
        {
            Console.WriteLine(@$"[{this.GetType().Name}] - Executing command adding {_id} {_quantity}");
            _shoppingCartRepository.DescreseQuantity(_id, _quantity);
            _productRepository.IncreaseStock(_id, _quantity);
        }

        public bool CanExecute()
        {
            var onCart = _shoppingCartRepository.Get(_id);

            if (onCart is not null) {
                Console.WriteLine(@$"[{this.GetType().Name}] - Can Execute Command {_id} {_quantity}");
                return true;
            }

            Console.WriteLine(@$"[{this.GetType().Name}] - Cannot Execute Command {_id} {_quantity}");
            return false;
        }

        public void Undo()
        {
            Console.WriteLine(@$"[{this.GetType().Name}] - Executing rollback command adding {_id} {_quantity}");
            
            var (id, _, _) = _productRepository.GetProduct(_id);
            
            _shoppingCartRepository.IncreaseQuantity(id, _quantity);
            _productRepository.DecreaseStock(id, _quantity);
        }

    }

}