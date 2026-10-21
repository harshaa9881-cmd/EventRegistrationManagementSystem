using Event_Management_Serv.Services;
using Participant_Registration_Management_Serv.Services;
using Registration_Management_mod.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Registration_Management_Serv.Services
{
    public class RegistrationManagement
    {
        // List for registration management
        public List<Reg> Rman = new List<Reg>();
        Participants pm = new Participants();
        EventManagement em = new EventManagement();
        int rid = 1;
        // Register for an event
        public void RegEvent()
        {

            Console.WriteLine("Enter Participant ID:");
            int pid = int.Parse(Console.ReadLine());
            var part = pm.Pman.FirstOrDefault(p => p.PId == pid);

            if (part == null)
                Console.WriteLine("Participant not found");
            Console.WriteLine("Enter Event ID:");
            int eid = int.Parse(Console.ReadLine());

            var ev = em.Eman.FirstOrDefault(e => e.EventId == eid);

            if (ev == null)
                Console.WriteLine("Event not found");
            if (ev.EventDate < DateTime.Now)
                Console.WriteLine("Event date has passed");
            int count = Rman.Count(r => r.EId == eid && r.PStatus == Status.Registered);
            if (count >= ev.Capacity)
                Console.WriteLine("Event is full");
            if (Rman.Any(r => r.PId == pid && r.EId == eid && r.PStatus == Status.Registered))
                Console.WriteLine("Participant is already registered for this event");
            Reg reg = new Reg(pid, eid, rid, DateTime.Now, ev.RegFee, Status.Registered);

            Rman.Add(reg);
            rid++;
            Console.WriteLine("Registration successful");
            Console.WriteLine("Registrationid: " + reg.RId);
            Console.WriteLine("Registration fee: " + reg.Paidfee);

        }
        // Display all registrations
        public void Display()
        {
            if (Rman.Count == 0)
            {
                Console.WriteLine("No registrations found");
                return;
            }
            else
            {
                foreach (Reg r in Rman)
                {
                    Console.WriteLine($"Registration ID: {r.RId}, Participant ID: {r.PId},Event ID: {r.EId},Registration Date: {r.RDate},Fee: {r.Paidfee},Status: {r.PStatus}");
                }
            }
        }


        // Search registration by ID
        public void SearchbyId()
        {
            Console.WriteLine("Enter Registration ID:");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }
            var reg = Rman.FirstOrDefault(r => r.RId == id);
            if (reg == null)
            {
                Console.WriteLine("Registration not found");
                return;
            }
            Console.WriteLine("Registration id: " + reg.RId);
            Console.WriteLine("Participant id: " + reg.PId);
            Console.WriteLine("Event id: " + reg.EId);
            Console.WriteLine("Registration date: " + reg.RDate);
            Console.WriteLine("Registration fee: " + reg.Paidfee);
            Console.WriteLine("Status: " + reg.PStatus);
        }


        // Cancel registration
        public void Cancel()
        {
            Console.WriteLine("Enter Registration ID:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }
            var reg = Rman.FirstOrDefault(r => r.RId == id && r.PStatus == Status.Registered);
            if (reg == null)
            {
                Console.WriteLine("Active registration not found");
                return;
            }

            reg.PStatus = Status.Cancelled;
            Console.WriteLine("Registration cancelled successfully");
        }


        // Mark registration as attended
        public void MarkAttended()
        {
            Console.WriteLine("Enter Registration ID:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }
            var reg = Rman.FirstOrDefault(r =>
                r.RId == id && r.PStatus == Status.Registered);

            if (reg == null)
            {
                Console.WriteLine("Active registration not found");
                return;
            }

            reg.PStatus = Status.Attended;

            Console.WriteLine("Attendance marked successfully");

        }
    }
}

