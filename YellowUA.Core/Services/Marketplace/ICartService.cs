namespace YellowUA.Core.Services.Marketplace
{
    public interface ICartService
    {
        Task AddToCart();

        Task GetCart();

        Task RemoveItemFromCart();
    }
}
