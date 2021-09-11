using System;

using Command.Business.Repositories;

namespace Command.Business.Commands.Vendors
{

    public class RemoveAllOfCartCommand : ICommand
    {

        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly int _id;
        private CartItem _onCart;
        
        public RemoveAllOfCartCommand(int id,
                                      IProductRepository      productRepository,
                                      IShoppingCartRepository shoppingCartRepository)
        {
            _id = id;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Execute()
        {
            Console.WriteLine(@$"[{this.GetType().Name}] - Executing command removing all {_id}");
            _onCart = _shoppingCartRepository.Get(_id);
            
            _shoppingCartRepository.RemoveAll(_id);
            _productRepository.IncreaseStock(_id, _onCart.Quantity);
        }

        public bool CanExecute()
        {
            var onCart = _shoppingCartRepository.Get(_id);

            if (onCart is not null) {
                Console.WriteLine(@$"[{this.GetType().Name}] - Can Execute Command {_id}");
                return true;
            }

            Console.WriteLine(@$"[{this.GetType().Name}] - Cannot Execute Command {_id}");
            return false;
        }

        public void Undo()
        {
            Console.WriteLine(@$"[{this.GetType().Name}] - Executing rollback command adding {_id}");
            
            var lineItem = _productRepository.GetProduct(_id);
            
            _productRepository.DecreaseStock(_onCart.Id, _onCart.Quantity);
            _shoppingCartRepository.Add(lineItem, _onCart.Quantity);
        }

    }

}