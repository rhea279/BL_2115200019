using System;
using System.Linq;

namespace TicketReservationSystem
{
    class Ticket
    {
        public int TicketID;
        public string CustomerName;
        public string MovieName;
        public int SeatNumber;
        public DateTime BookingTime;
        public Ticket Next; // Points to the next ticket

        public Ticket(int ticketID, string customerName, string movieName, int seatNumber)
        {
            TicketID = ticketID;
            CustomerName = customerName;
            MovieName = movieName;
            SeatNumber = seatNumber;
            BookingTime = DateTime.Now;
            Next = null;
        }
    }

    class TicketReservation
    {
        private Ticket last; // Points to the last booked ticket (circular linked list)
        private int ticketCount;

        public TicketReservation()
        {
            last = null;
            ticketCount = 0;
        }

        // Add a new ticket reservation at the end of the circular list
        public void AddTicket(int ticketID, string customerName, string movieName, int seatNumber)
        {
            Ticket newTicket = new Ticket(ticketID, customerName, movieName, seatNumber);

            if (last == null)
            {
                // First ticket in the system
                last = newTicket;
                last.Next = last; // Circular link
            }
            else
            {
                newTicket.Next = last.Next;
                last.Next = newTicket;
                last = newTicket;
            }

            ticketCount++;
            Console.WriteLine($"Ticket {ticketID} booked successfully for {customerName}.");
        }

        // Remove a ticket by Ticket ID
        public void RemoveTicket(int ticketID)
        {
            if (last == null)
            {
                Console.WriteLine("No tickets found.");
                return;
            }

            Ticket current = last.Next;
            Ticket prev = last;
            bool found = false;

            do
            {
                if (current.TicketID == ticketID)
                {
                    found = true;
                    if (current == last && current.Next == last) // Only one node case
                    {
                        last = null;
                    }
                    else
                    {
                        if (current == last)
                            last = prev; // Update last if needed

                        prev.Next = current.Next;
                    }

                    ticketCount--;
                    Console.WriteLine($"Ticket {ticketID} removed successfully.");
                    return;
                }

                prev = current;
                current = current.Next;
            } while (current != last.Next);

            if (!found)
            {
                Console.WriteLine($"Ticket {ticketID} not found.");
            }
        }

        // Display all booked tickets
        public void DisplayTickets()
        {
            if (last == null)
            {
                Console.WriteLine("No tickets booked.");
                return;
            }

            Ticket temp = last.Next;
            Console.WriteLine("\n--- Current Ticket Reservations ---");
            do
            {
                Console.WriteLine($"Ticket ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}, Time: {temp.BookingTime}");
                temp = temp.Next;
            } while (temp != last.Next);
        }

        // Search for a ticket by Customer Name or Movie Name
        public void SearchTicket(string keyword)
        {
            if (last == null)
            {
                Console.WriteLine("No tickets found.");
                return;
            }

            Ticket temp = last.Next;
            bool found = false;

            do
            {
                if (temp.CustomerName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    temp.MovieName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"Ticket Found - ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}, Time: {temp.BookingTime}");
                    found = true;
                }
                temp = temp.Next;
            } while (temp != last.Next);

            if (!found)
            {
                Console.WriteLine("No matching ticket found.");
            }
        }


        // Get the total number of booked tickets
        public int GetTotalTickets()
        {
            return ticketCount;
        }
    }

    class Program
    {
        static void Main()
        {
            TicketReservation system = new TicketReservation();

            while (true)
            {
                Console.WriteLine("\n--- Online Ticket Reservation System ---");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Remove Ticket");
                Console.WriteLine("3. Display All Tickets");
                Console.WriteLine("4. Search Ticket");
                Console.WriteLine("5. Total Booked Tickets");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Ticket ID: ");
                        int ticketID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Customer Name: ");
                        string customerName = Console.ReadLine();
                        Console.Write("Enter Movie Name: ");
                        string movieName = Console.ReadLine();
                        Console.Write("Enter Seat Number: ");
                        int seatNumber = Convert.ToInt32(Console.ReadLine());

                        system.AddTicket(ticketID, customerName, movieName, seatNumber);
                        break;

                    case 2:
                        Console.Write("Enter Ticket ID to Remove: ");
                        int removeID = Convert.ToInt32(Console.ReadLine());
                        system.RemoveTicket(removeID);
                        break;

                    case 3:
                        system.DisplayTickets();
                        break;

                    case 4:
                        Console.Write("Enter Customer Name or Movie Name: ");
                        string keyword = Console.ReadLine();
                        system.SearchTicket(keyword);
                        break;

                    case 5:
                        Console.WriteLine($"Total Booked Tickets: {system.GetTotalTickets()}");
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
