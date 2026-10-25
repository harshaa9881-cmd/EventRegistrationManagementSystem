using Event_Management_Mod.Models;
using Participant_Management_mod.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Participant_Registration_Management_Serv.Services
{
    public class Participants
    {
        public List<PartMan> Pman = new List<PartMan>();
        public void RegPart()
        {
            Console.WriteLine("Welcome to Participant Registration");

            // Participant ID
            Console.Write("Enter Participant ID: ");
            string? PartId = Console.ReadLine();

            if (!int.TryParse(PartId, out int pid))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            if (Pman.Any(p => p.PId == pid))
            {
                Console.WriteLine("Participant ID already exists.");
            }

            // Participant name
            Console.Write("Enter Participant Name: ");
            string? PartName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(PartName))
            {
                Console.WriteLine("Participant name cannot be empty.");
                return;
            }

            // Participant email
            Console.Write("Enter Participant Email: ");
            string? email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("email cannot be null");
            }
            if (Pman.Any(p => p.Email == email))
            {
                Console.WriteLine("Email already exists.");
                return;
            }

            // Participant phone number
            Console.Write("Enter Participant Phone Number: ");
            string? ph = Console.ReadLine();
            double phno = double.Parse(ph);
            if (string.IsNullOrWhiteSpace(ph))
            {
                Console.WriteLine("Phone number must contain 10 digits.");
                return;
            }
            if (ph.Length != 10)
            {
                Console.WriteLine("enter 10 digit contact numaber");
            }

            //add record
            PartMan par = new PartMan(pid, PartName, email, phno);
            Pman.Add(par);
            Console.WriteLine("Participant registered successfully.");

        }

        // Display all participants
        public void Display()
        {
            if (Pman == null)
            {
                Console.WriteLine("No participant records found.");
            }
            else
            {
                foreach (var p in Pman)
                {
                    Console.WriteLine($"Participant ID: {p.PId}, " + $"Name: {p.PName}, " + $"Email: {p.Email}, " + $"Phone Number: {p.Phno}");
                }
            }
        }

        // Search participant by ID
        public void SearchbyId()
        {
            Console.WriteLine("Enter the Participant ID to search:");
            string? PartId = Console.ReadLine();

            if (!int.TryParse(PartId, out int pid))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            if (Pman.Any(p => p.PId == pid))
            {
                Console.WriteLine("Participant found.");
                var res = Pman.Where(p => p.PId == pid);
                foreach (var p in res)
                {
                    Console.WriteLine($"Participant ID: {p.PId}, " + $"Name: {p.PName}, " + $"Email: {p.Email}, " + $"Phone Number: {p.Phno}");
                }
            }
            else
            {
                Console.WriteLine("Participant ID not found.");
            }
        }

        // Search participant by name or email
        public void Searchbyname()
        {
            Console.WriteLine("Enter participant name or email to search:");
            string? key = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("Name or email cannot be empty.");
                return;
            }
            var res = Pman.Where(p => p.PName.Contains(key, StringComparison.OrdinalIgnoreCase) || p.Email.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (res.Any())
            {
                Console.WriteLine("Participant found.");

                foreach (var p in res)
                {
                    Console.WriteLine($"Participant ID: {p.PId}, " + $"Name: {p.PName}, " + $"Email: {p.Email}, " + $"Phone Number: {p.Phno}");
                }
            }
            else
            {
                Console.WriteLine("Participant not found.");
            }
        }

        // Update participant details
        public void Update()
        {
            Console.Write("Enter Participant ID to update: ");
            string? PartId = Console.ReadLine();

            if (!int.TryParse(PartId, out int pid))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            if (!Pman.Any(p => p.PId == pid))
            {
                Console.WriteLine("Participant ID not found.");
                return;
            }
            // Participant name
            Console.Write("Enter new Participant Name: ");
            string? PartName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(PartName))
            {
                Console.WriteLine("Participant name cannot be empty.");
                return;
            }
            // Participant email
            Console.Write("Enter new Email: ");
            string? email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Invalid email address.");
                return;
            }
            if (Pman.Any(p => p.PId != pid &&
                p.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Email already exists.");
                return;
            }

            // Participant phone number
            Console.Write("Enter new Phone Number: ");
            string? ph = Console.ReadLine();
            int phno = int.Parse(ph);
            if (string.IsNullOrWhiteSpace(ph))
            {
                Console.WriteLine("Phone number must contain 10 digits.");
                return;
            }
            var res = Pman.Where(p => p.PId == pid);

            foreach (var p in res)
            {
                p.PName = PartName;
                p.Email = email;
                p.Phno = phno;
            }
            Console.WriteLine("Participant details updated.");

        }

    }
}

