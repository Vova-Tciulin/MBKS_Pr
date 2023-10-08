namespace MBKS_Pr2.Models;

public class MsgVm
{
    public string Message { get; set; }

    public MsgVm()
    {
        
    }

    public MsgVm(string message)
    {
        Message = message;
    }
}