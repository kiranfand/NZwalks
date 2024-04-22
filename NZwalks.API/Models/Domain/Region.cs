namespace NZwalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public String Code { get; set; }

        public string Name { get; set; }

        public string? regionImageUrl { get; set; }
    }
}
