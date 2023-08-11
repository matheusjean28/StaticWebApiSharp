namespace Models.Pay;
using Models.Product;
public class Pay
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    
     public List<Product> Products { get; set; }
 
}