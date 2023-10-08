namespace MBKS_Pr2.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public List<Symbol> Symbols { get; set; } = new List<Symbol>();
}