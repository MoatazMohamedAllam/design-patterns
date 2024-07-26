namespace mediator.AirlineBookingSystem;

public class PaymentProcessing : Component
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing Payment");
        _bookingMediator.Notify(this, "PaymentProcessed");
    }
}