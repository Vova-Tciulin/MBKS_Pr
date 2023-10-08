namespace MBKS_Pr2.Models;

public class UserDeleteVm
{
    public string UserId { get; set; }

    public UserDeleteVm()
    {
    }

    public UserDeleteVm(string userId)
    {
        UserId = userId;
    }
}