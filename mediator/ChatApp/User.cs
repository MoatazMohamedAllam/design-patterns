public abstract class User
{
    protected IChatMediator _chatMediator;
    protected string _name;

    protected User(IChatMediator chatMedatior, string name)
    {
        _chatMediator = chatMedatior;
        _name = name;
    }

    public abstract void Send(string msg);
    public abstract void Receive(string msg);
}