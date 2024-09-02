using System.Globalization;
using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>' - to cancel a booking");
        Console.WriteLine("'undo' - to undo the last command");
        Console.WriteLine("'find <BookingId>' - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>' - to search bookings");
        Console.WriteLine("'exit' - to exit the application");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];
        DateTime startDate, endDate;
        CurrencyDto currency;

        switch (commandName)
        {
            case "book":
                if (parts.Length != 6)
                {
                    throw new ArgumentException("Invalid number of arguments for booking.");
                }

                if (!DateTime.TryParse(parts[3], out startDate))
                {
                    throw new ArgumentException("Invalid start date format. Expected format: 'dd/mm/yyyy'");
                }

                if (!DateTime.TryParse(parts[4], out endDate))
                {
                    throw new ArgumentException("Invalid end date format. Expected format: 'dd/mm/yyyy'");
                }

                if (!Enum.TryParse(parts[5], true, out currency))
                {
                    throw new ArgumentException($"Invalid currency {parts[5]}");
                }

                BookingDto bookingDto = new()
                {
                    UserId = int.Parse(parts[1]),
                    Category = parts[2],
                    StartDate = startDate,
                    EndDate = endDate,
                    Currency = currency,
                };

                BookCommand bookCommand = new(_bookingService, bookingDto);
                bookCommand.Execute();
                _executedCommands.Add(++s_commandIndex, bookCommand);
                Console.WriteLine("Booking command run is successful.");
                break;

            case "cancel":
                if (parts.Length != 2)
                {
                    throw new ArgumentException("Invalid number of arguments for canceling.");
                }

                Guid bookingId = Guid.Parse(parts[1]);
                CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
                cancelCommand.Execute();
                _executedCommands.Add(++s_commandIndex, cancelCommand);
                Console.WriteLine("Cancellation command run is successful.");
                break;

            case "undo":
                if (_executedCommands.Count == 0)
                {
                    throw new InvalidOperationException("List command is empty");
                }

                _executedCommands[s_commandIndex].Undo();
                _executedCommands.Remove(s_commandIndex);
                s_commandIndex--;
                Console.WriteLine("Last command undone.");

                break;
            case "find":
                if (parts.Length != 2)
                {
                    throw new ArgumentException("Invalid arguments for 'find'. Expected format: 'find <BookingId>'");
                }
                if (!Guid.TryParse(parts[1], out Guid id))
                {
                    throw new ArgumentException("Invalid format bookingId");
                }
                FindBookingByIdCommand findCommand = new(_bookingService, id);
                findCommand.Execute();
                break;

            case "search":
                if (parts.Length != 4)
                {
                    throw new ArgumentException("Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
                }

                if (!DateTime.TryParse(parts[2], out startDate))
                {
                    throw new ArgumentException("Invalid start date format. Expected format: 'dd/mm/yyyy'");
                }

                if (!DateTime.TryParse(parts[3], out endDate))
                {
                    throw new ArgumentException("Invalid end date format. Expected format: 'dd/mm/yyyy'");
                }

                string categoryName = parts[4];
                SearchBookingsCommand searchCommand = new(_bookingService, startDate, endDate, categoryName);
                searchCommand.Execute();

                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
