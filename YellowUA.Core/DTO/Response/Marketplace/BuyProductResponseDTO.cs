namespace YellowUA.Core.DTO.Response.Marketplace
{
    public class BuyProductResponseDTO
    {
        public string Message { get; set; } = string.Empty;

        public string Product { get; set; }

        public decimal Total { get; set; }
    }
}