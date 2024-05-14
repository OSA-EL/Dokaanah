using Dokaanah.Models;
using Dokaanah.Repositories.RepoClasses;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dokaanah.Controllers
{
    public class CartProductController : Controller
    {
        private readonly ICartProductRepo _cartproductRepo;
        private readonly IProductsRepo _productRepo;

        public CartProductController(ICartProductRepo cartproductRepo , IProductsRepo productsRepo)
        {
            _cartproductRepo = cartproductRepo;
            _productRepo = productsRepo;

        }
        [HttpPost]
        public IActionResult AddProductToCart(int productId, int cartId)
        {
            List<Product> products = _productRepo.GetRandomProducts(5);
            try
            {
                // Check if the product already exists in the cart
                var existingCartItem = _cartproductRepo.GetCartItem(productId, cartId);
                if (existingCartItem != null)
                {
                    // If the product already exists, increment its quantity
                    existingCartItem.ProductItemsNumbers++;
                    _cartproductRepo.UpdateCartItem(existingCartItem);
                }
                else
                {
                    // If the product does not exist, create a new cart item
                    var newCartItem = new Cart_Product
                    {
                        Prid = productId,
                        Caid = cartId,
                        ProductItemsNumbers = 1 // Set initial quantity to 1
                    };
                    _cartproductRepo.AddCartItem(newCartItem);
                }

                return RedirectToAction("Index", "Cart"); // Redirect to cart page or any other page
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "An error occurred while adding the product to the cart.");
            }
        }

        public IActionResult YourCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveProductFromCart(int productId, int cartId)
        {
            try
            {
                var cartItem = _cartproductRepo.GetCartItem(productId, cartId);
                if (cartItem != null)
                {
                    _cartproductRepo.RemoveCartItem(cartItem);
                }

                return RedirectToAction("Index", "Cart"); // Redirect to cart page or any other page
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "An error occurred while removing the product from the cart.");
            }
        }

        [HttpPost]
        public IActionResult UpdateCartProductQuantity(int productId, int cartId, int quantity)
        {
            try
            {
                var cartItem = _cartproductRepo.GetCartItem(productId, cartId);
                if (cartItem != null)
                {
                    cartItem.ProductItemsNumbers = quantity;
                    _cartproductRepo.UpdateCartItem(cartItem);
                }

                return RedirectToAction("Index", "Cart"); // Redirect to cart page or any other page
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, "An error occurred while updating the cart product quantity.");
            }
        }

    }
}
