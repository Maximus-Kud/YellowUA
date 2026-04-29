namespace YellowUA.Core.DTO.Admin
{
    public class ChangeProductDTO
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? InStock { get; set; }

        public bool? IsAvailable { get; set; }

        public string? Code { get; set; }
    }
}
