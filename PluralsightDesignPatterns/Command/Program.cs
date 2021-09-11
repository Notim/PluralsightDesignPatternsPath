using System;
using System.Text.Json;

using Command.Business.Commands;
using Command.Business.Commands.Vendors;
using Command.Business.Repositories;

namespace Command
{

    class Program
    {

        static void Main(string[] args)
        {
            var manager = new CommandManager();
            
            var productRepository = new ProductRepositoryMocked();
            var cartRepository = new ShoppingCartRepositoryMocked();

            var product = productRepository.GetProduct(1);

            manager.Invoke(new AddToCartCommand(product, 1, productRepository, cartRepository));
            Console.WriteLine(JsonSerializer.Serialize(cartRepository.Get(product.Id)));
            manager.Commit();
            
            manager.Invoke(new IncreaseToCartCommand(product.Id, 1, productRepository, cartRepository));
            Console.WriteLine(JsonSerializer.Serialize(cartRepository.Get(product.Id)));
            
            manager.Invoke(new IncreaseToCartCommand(product.Id, 1, productRepository, cartRepository));
            Console.WriteLine(JsonSerializer.Serialize(cartRepository.Get(product.Id)));
            
            manager.Invoke(new DecreaseToCartCommand(product.Id, 6, productRepository, cartRepository));
            Console.WriteLine(JsonSerializer.Serialize(cartRepository.Get(product.Id)));

            manager.Invoke(new RemoveAllOfCartCommand(product.Id, productRepository, cartRepository));
            Console.WriteLine(JsonSerializer.Serialize(cartRepository.Get(product.Id)));

            manager.Undo();
            Console.WriteLine(JsonSerializer.Serialize(cartRepository.Get(product.Id)));
        }

    }

}