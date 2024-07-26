namespace mediator.AirlineBookingSystem;

public class SeatReservation : Component
{
    public void ReserveSeat()
    {
        Console.WriteLine("Seat Reserved");
        _bookingMediator.Notify(this, "SeatReserved");
    }
}