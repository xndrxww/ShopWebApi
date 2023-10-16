namespace Shop.Domain.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
    }
}
