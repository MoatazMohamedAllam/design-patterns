public class ChatMedaitor : IChatMediator
{
    private List<User> _users = new List<User>();
    
    public void SendMessage(User user, string msg)
    {
        foreach (var u in _users)       
        {
            if (u != user)
            {
                u.Receive(msg);
            }
        }
    }

    public void AddUser(User user)
    {
        _users.Add(user);    
    }
}