namespace mediator.AirlineBookingSystem;

public abstract class Component
{
    protected IBookingMediator _bookingMediator;

    public void SetMediator(IBookingMediator mediator)
    {
        _bookingMediator = mediator;
    }
}