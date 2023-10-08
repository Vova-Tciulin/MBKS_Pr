namespace MBKS_Pr2.Models.Repository;

public class UserRepo
{
    private List<User> Users { get; set; }
    

    public UserRepo()
    {
        var user1 =
            Users = new List<User>()
            {
                new User() { Name = "Alex", Symbols = new List<Symbol>()
                {
                    new Symbol(){S='q'},new Symbol(){S='w'},new Symbol(){S='e'},new Symbol(){S='r'},new Symbol(){S='t'},new Symbol(){S='y'},
                    new Symbol(){S='y'},new Symbol(){S='u'},new Symbol(){S='i'},new Symbol(){S='o'},new Symbol(){S='p'},new Symbol(){S='a'},
                    new Symbol(){S='s'},new Symbol(){S='d'},new Symbol(){S='f'}
                } },
                new User() { Name = "Vova", Symbols = new List<Symbol>() 
                    { new Symbol(){S='a'},new Symbol(){S='k'},new Symbol(){S='l'},new Symbol(){S=','},new Symbol(){S='b'},new Symbol(){S='v'} } },
                new User() {  Name = "Andrey", Symbols = new List<Symbol>() 
                    { new Symbol(){S='a'},new Symbol(){S='s'},new Symbol(){S='d'},new Symbol(){S='f'} } },
                new User() {  Name = "Nikita", Symbols = new List<Symbol>() 
                    { new Symbol(){S='1'},new Symbol(){S='2'},new Symbol(){S='3'},new Symbol(){S='4'},new Symbol(){S=';'},new Symbol(){S=' '} } },
                new User() {  Name = "Maksim", Symbols = new List<Symbol>()
                    { new Symbol(){S='z'},new Symbol(){S='x'},new Symbol(){S='c'},new Symbol(){S='v'},new Symbol(){S='b'},new Symbol(){S='n'} } },
            };
    }

    public User? Add(string name,string symbols)
    {
        if (String.IsNullOrEmpty(name))
        {
            return null;
        }
        var user = new User() { Name = name };
        foreach (var s in symbols)
        {
            if (!user.Symbols.Exists(u=>u.S==s))
            {
                user.Symbols.Add(new Symbol(){S=s});
            }
            if (user.Symbols.Count()>14)
            {
                break;
            }
        }
        Users.Add(user);
        return user;
    }

    public List<User> GetUsers()
    {
        return Users;
    }

    public bool RemoveUser(string id)
    {
        var user=Users.Find(u => u.Id == id);
        if (user==null)
        {
            return false;
        }
        Users.Remove(user);
        return true;
    }

    public void UpdateSymbol(string userId, string sId,string value)
    {
        var user = Users.Find(u => u.Id == userId);
        if (user==null)
        {
            return;
        }

        var symbol = user.Symbols.Find(u => u.Id == sId);
        if (symbol==null)
        {
            if (!String.IsNullOrEmpty(value)&&!user.Symbols.Exists(u=>u.S==value[0]))
            {
                user.Symbols.Add(new Symbol(){S=value[0]});
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(value)&&!user.Symbols.Exists(u=>u.S==value[0]))
            {
                symbol.S = value[0];
            }
            else
            {
                user.Symbols.Remove(symbol);
            }
        }
    }

    public void RemoveSymbol(string id, Symbol symbol)
    {
        var user = Users.Find(u => u.Id == id);
        if (user==null)
        {
            return;
        }

        user.Symbols.Remove(symbol);
    }
    
}