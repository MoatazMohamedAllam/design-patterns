
using mediator.AirlineBookingSystem;

public class BookingMediator : IBookingMediator
{
    private FlightBooking _flightBooking;
    private SeatReservation _seatReservation;
    private PaymentProcessing _paymentProcessing;

    public BookingMediator(FlightBooking flightBooking, SeatReservation seatReservation, PaymentProcessing paymentProcessing)
    {
        _flightBooking = flightBooking;
        _seatReservation = seatReservation;
        _paymentProcessing = paymentProcessing;
        
        _flightBooking.SetMediator(this);
        _seatReservation.SetMediator(this);
        _paymentProcessing.SetMediator(this);
    }
    
    //mediator should contain all concrete components and pass it to them
    public void Notify(object sender, string eventCode)
    {
        switch (eventCode)
        {
            case "FlightBooked":
                _seatReservation.ReserveSeat();
                break;
            case "SeatReserved":
                _paymentProcessing.ProcessPayment();
                break;
            case "PaymentProcessed":
                Console.WriteLine("Booking completed successfully!");
                break;
        }
    }
}