
class Solution{

    //Q1: Select all the outbound and inbound flights at given airport, the arrival time should be used to order the result.
    public static IQueryable<Flight> Q1(FlightContext db, string airport)
    {
        var q = from f in db.Flights

                where f.ArrivalAirport.ToLower().Contains(airport.ToLower())
                 || f.DepartureAirport.ToLower().Contains(airport.ToLower())
                orderby f.ArrivalTime ascending
                select f;

        return q;

    }


    //Q2: For given person name 
    //    find the boarding passes (flight id, Ticket id, fare, seat number and issue date) with passenger name [BoardingPassWithName].
    public static IQueryable<BoardingPassWithName> Q2(FlightContext db, string person) {
        
        var q = from b in db.BoardingPasses
            join ticket in db.Tickets on b.TicketID equals ticket.Id
            where ticket.Name == person
            select new BoardingPassWithName(b, ticket.Name);

        return q; 

    }



    //Q3: Returns an instance of BookingOverview for a given booking: 
    //    List of Tuples containing Departure and Arrival airports (FlightDetails); 
    //    Calculate the total fare of given booking (TotalFare).
    public static BookingOverview Q3(FlightContext db, int booking) {   
        q = (from ticket in db.Tickets
            where ticket.BookingRef == booking   
            //tickets with bookingref the correct ones
            join boarding in db.BoardingPasses on ticket.Id equals boarding.TicketID
            //join ticket on to boardinf pass
            //where 

            join flight in db.Flights on boarding.FlightID equals flight.Id
               // where boarding.TicketID == ticket.Id

            select new Tuple<string, string>(flight.DepartureAirport, flight.ArrivalAirport);

            var flightDetails = q.ToList();



            decimal totalFare = (
                from boarding in db.BoardingPasses
                where boarding.TicketID. == booking 
                select ticket.Fare
            ).Sum();

    return new BookingOverview(flightDetails, totalFare);

            //boarding passes with tickets, needs to be a joing

            //from ticket to ticket Id inboarding pass

        return q;  //this line of code should be changed    
        
    }






            

    







    //Q4: List down number of seats booked (TotalSeats) per flight (FlightID)  [SeatsInFlight]
    //    do not forget to include flights with no Boarding passes issued (no seats booked), 
    //    as well if any -> LEFT JOIN
    //    Using the Sum method might be useful to compute TotalSeats.
    
    public static IQueryable<SeatsInFlight> Q4(FlightContext db) {
        
        return (new List<SeatsInFlight>()).AsQueryable();  //this line of code should be changed   
              
    }
 
    //Q5: List down the flights [if any] that were never booked
    public static IQueryable<Flight> Q5(FlightContext db) {
        
        return (new List<Flight>()).AsQueryable();  //this line of code should be changed 
        
    }
    
    //Q6: Given two ticket IDs, 
    //    merge the FlightInfo elements (projection of Flight entity) belonging to both given tickets 
    //    WITHOUT repetitions.
    public static List<FlightInfo> Q6(FlightContext db, int TicketID1, int TicketID2) {
          
        return (new List<FlightInfo>());  //this line of code should be changed 
        
    }

    //Q7: Create a new flight, new booking, new ticket and a new boarding pass
    //    and make the changes persistent.
    //    HINT: having a look at the implementation of the seed methods in Data class (FlightModel.cs) can be useful.
    //          as well as DateTimeUtils methods in DataFormats.cs
    public static void Q7(FlightContext db) {

    }
}


