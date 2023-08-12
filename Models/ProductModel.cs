namespace Models.Product;
using Models.Pay;
public class Product
{
    public int Id { get; set; }
    public string? Owner {get; set;}
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public int PayId { get; set; }
    public Pay? Pay { get; set; }

}