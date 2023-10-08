namespace MBKS_Pr2.Models;

public class ChangeSymbolVm
{

    public string UserId { get; set; }
    public string SId { get; set; }
    public string Value { get; set; }

    public ChangeSymbolVm()
    {
        
    }

    public ChangeSymbolVm(string userId, string sId, string? value)
    {
        UserId = userId;
        SId = sId;
        Value = value;
    }
}