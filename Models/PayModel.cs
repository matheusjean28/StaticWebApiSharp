using ModelsProduct;

namespace ModelsPay
{

    public class Pay
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;

        public List<Product> Products { get; set; } = new List<Product>();

    }
}