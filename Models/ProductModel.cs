
using ModelsPay;
namespace ModelsProduct
{

    public class Product
    {
            public int Id { get; set; }
        public string Owner { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }

        public int PayId { get; set; } 
        public Pay? Pay { get; set; } 

    }
}