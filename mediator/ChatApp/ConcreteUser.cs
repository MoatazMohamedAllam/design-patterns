public class ConcreteUser : User
{
    public ConcreteUser(IChatMediator chatMediator, string name): base(chatMediator, name)
    {
    }

    public override void Send(string msg)
    {
        Console.WriteLine($"User: {_name} sending mesage:{msg}");
        _chatMediator.SendMessage(this, msg);
    }

    public override void Receive(string msg)
    {
        Console.WriteLine($"User: {_name} Received msg: {msg}");
    }
}