namespace YellowUA.Core.DTO.Response.Marketplace
{
    public class BuyProductResponseDTO
    {
        public string Message { get; set; } = string.Empty;

        public string Product { get; set; } = string.Empty;

        public decimal Total { get; set; }
    }
}