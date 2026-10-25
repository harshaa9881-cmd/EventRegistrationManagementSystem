using Event_Management_Mod;
using Event_Management_Mod.Models;
using Event_Management_Serv.Services;
using Participant_Registration_Management_Serv.Services;
using Records.Services;
using Registration_Management_Serv.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Program_main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EventManagement EService = new EventManagement();
            Participants PService = new Participants();
            RegistrationManagement RService = new RegistrationManagement();
            Reports RpService = new Reports();

            RService.pm = PService;
            RService.em = EService;

            EService.rm = RService;

            RpService.em = EService;
            RpService.pm = PService;
            RpService.rm = RService;
            int ch = 0;
            

            while (ch != 28)
            {
                Console.WriteLine("----------------------------------------Choose one------------------------------------");
                Console.WriteLine("1. Register event");
                Console.WriteLine("2. Display event");
                Console.WriteLine("3. Search event by id");
                Console.WriteLine("4. Search event by name/venue");
                Console.WriteLine("5. Update event");
                Console.WriteLine("6. Register participant");
                Console.WriteLine("7. Display participant");
                Console.WriteLine("8. Search participant by id");
                Console.WriteLine("9. Search participant by name or email");
                Console.WriteLine("10. Update participant");
                Console.WriteLine("11. Register for event");
                Console.WriteLine("12. Display registrations");
                Console.WriteLine("13. Search registration by ID");
                Console.WriteLine("14. Mark Attendance");
                Console.WriteLine("15. Cancel registration");
                Console.WriteLine("16. Delete Event");
                Console.WriteLine("17. Participants by Event");
                Console.WriteLine("18. Events by Participant");
                Console.WriteLine("19. Remaining Capacity");
                Console.WriteLine("20. Full Events");
                Console.WriteLine("21. Group Registrations by Event");
                Console.WriteLine("22. Active Registration Count");
                Console.WriteLine("23. Payments by Event");
                Console.WriteLine("24. Overall Payments");
                Console.WriteLine("25. Attendance Count");
                Console.WriteLine("26. Attendance Percentage");
                Console.WriteLine("27. Exit");

                if (!int.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        EService.RegEvent();
                        break;

                    case 2:
                        EService.Display();
                        break;

                    case 3:
                        EService.SearchbyId();
                        break;

                    case 4:
                        EService.Searchbyname();
                        break;

                    case 5:
                        EService.Update();
                        break;

                    case 6:
                        PService.RegPart();
                        break;

                    case 7:
                        PService.Display();
                        break;

                    case 8:
                        PService.SearchbyId();
                        break;

                    case 9:
                        PService.Searchbyname();
                        break;

                    case 10:
                        PService.Update();
                        break;

                    case 11:
                        RService.RegEvent();
                        break;

                    case 12:
                        RService.Display();
                        break;

                    case 13:
                        RService.SearchbyId();
                        break;
                    case 14:
                        RService.MarkAttended();
                        break;
                    case 15:
                        RService.Cancel();
                        break;
                    case 16:
                        EService.Delete();
                        break;
                    case 17:
                        RpService.ParticipantsByEvent();
                        break;

                    case 18:
                        RpService.EventsByParticipant();
                        break;

                    case 19:
                        RpService.RemainingCapacity();
                        break;

                    case 20:
                        RpService.FullEvents();
                        break;

                    case 21:
                        RpService.GroupRegistrationsByEvent();
                        break;

                    case 22:
                        RpService.ActiveRegistrationCount();
                        break;

                    case 23:
                        RpService.PaymentsByEvent();
                        break;

                    case 24:
                        RpService.OverallPayments();
                        break;

                    case 25:
                        RpService.AttendanceCount();
                        break;

                    case 26:
                        RpService.AttendancePercentage();
                        break;
                    case 27:
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
        }
    }
}

