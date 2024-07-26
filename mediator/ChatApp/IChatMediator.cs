public interface IChatMediator
{
    public void SendMessage(User user, string msg);
    public void AddUser(User user);
}