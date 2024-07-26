namespace mediator.AirlineBookingSystem;

public class FlightBooking : Component
{
    public void BookFlight()
    {
        Console.WriteLine("Filght Booked");
        _bookingMediator.Notify(this, "FlightBooked");
    }
}