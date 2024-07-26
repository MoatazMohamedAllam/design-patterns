// Console.WriteLine("chat system...");
// var mediator = new ChatMedaitor();
// var user1 = new ConcreteUser(mediator, "Moataz");
// var user2 = new ConcreteUser(mediator, "Ali");
// var user3 = new ConcreteUser(mediator, "Mohamed");
// mediator.AddUser(user1);
// mediator.AddUser(user2);
// mediator.AddUser(user3);
// user1.Send("Hello this moataz a new joiner to flynas");
// Console.WriteLine("End");


using mediator.AirlineBookingSystem;
Console.WriteLine("Airline Booking System....");
var flightBooking = new FlightBooking();
var seatReservation = new SeatReservation();
var paymentProcessing = new PaymentProcessing();
var bookingMediator = new BookingMediator(flightBooking, seatReservation, paymentProcessing);
flightBooking.BookFlight();