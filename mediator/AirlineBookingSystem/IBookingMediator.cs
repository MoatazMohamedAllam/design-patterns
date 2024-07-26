namespace mediator.AirlineBookingSystem;

public interface IBookingMediator
{
    public void Notify(object sender, string eventCode);
}