using System;
using System.Collections.Generic;
using System.Text;
using Event_Management_Mod.Models;
using Participant_Management_mod.Models;
using Registration_Management_mod.Models;
using Event_Management_Serv.Services;
using Participant_Registration_Management_Serv.Services;
using Registration_Management_Serv.Services;
namespace Records.Services
{
    public class Reports
    {
        public EventManagement em;
        public Participants pm;
        public RegistrationManagement rm;



        // 1. List participants registered for an event
        public void ParticipantsByEvent()
        {
            Console.Write("Enter Event ID: ");
            int eid = int.Parse(Console.ReadLine());
            var registrations = rm.Rman.Where(r => r.EId == eid && r.PStatus != Status.Cancelled).ToList();
            if (registrations.Count == 0)
            {
                Console.WriteLine("No participants registered");
                return;
            }

            foreach (var r in registrations)
            {
                var participant = pm.Pman.FirstOrDefault(p => p.PId == r.PId);

                if (participant != null)
                {
                    Console.WriteLine($"Participant ID: {participant.PId}, Name: {participant.PName}");
                }

            }
        }


        // 2. List events for a participant
        public void EventsByParticipant()
        {
            Console.Write("Enter Participant ID: ");
            int pid = int.Parse(Console.ReadLine());

            var registrations = rm.Rman.Where(r => r.PId == pid && r.PStatus != Status.Cancelled).ToList();
            if (registrations.Count == 0)
            {
                Console.WriteLine("No events found");
                return;
            }
            foreach (var r in registrations)
            {
                var ev = em.Eman.FirstOrDefault(e => e.EventId == r.EId);

                if (ev != null)
                {
                    Console.WriteLine(
                        $"Event ID: {ev.EventId}, Name: {ev.EventName}");
                }
            }
        }
        // 3. Remaining capacity per event
        public void RemainingCapacity()
        {
            foreach (var ev in em.Eman)
            {
                int count = rm.Rman.Count(r =>
                    r.EId == ev.EventId &&
                    r.PStatus != Status.Cancelled);

                Console.WriteLine(
                    $"Event: {ev.EventName}, Remaining Capacity: {ev.Capacity - count}");

            }
        }
        // 4. Show full events
        public void FullEvents()
        {
            foreach (var ev in em.Eman)
            {
                int count = rm.Rman.Count(r =>
                    r.EId == ev.EventId &&
                    r.PStatus != Status.Cancelled);

                if (count >= ev.Capacity)
                {
                    Console.WriteLine(
                        $"Event ID: {ev.EventId}, Name: {ev.EventName}");
                }
            }
        }

        // 5. Group registrations by event
        public void GroupRegistrationsByEvent()
        {
            var groups = rm.Rman.GroupBy(r => r.EId);

            foreach (var group in groups)
            {
                Console.WriteLine($"Event ID: {group.Key}");

                foreach (var r in group)
                {
                    Console.WriteLine(
                        $"Registration ID: {r.RId}, Participant ID: {r.PId}, Status: {r.PStatus}");
                }
            }
        }

        // 6. Active registration count per event
        public void ActiveRegistrationCount()
        {
            foreach (var ev in em.Eman)
            {
                int count = rm.Rman.Count(r => r.EId == ev.EventId && r.PStatus != Status.Cancelled);

                Console.WriteLine(
                    $"Event: {ev.EventName}, Active Registrations: {count}");
            }
        }

        // 7. Payments collected by event
        public void PaymentsByEvent()
        {
            foreach (var ev in em.Eman)
            {
                decimal total = rm.Rman.Where(r => r.EId == ev.EventId && r.PStatus != Status.Cancelled).Sum(r => r.Paidfee);

                Console.WriteLine($"Event: {ev.EventName}, Payments Collected: {total}");
            }
        }
        // 8. Overall payments collected
        public void OverallPayments()
        {
            decimal total = rm.Rman
                .Where(r => r.PStatus != Status.Cancelled)
                .Sum(r => r.Paidfee);

            Console.WriteLine($"Overall Payments Collected: {total}");
        }
        // 9. Attendance count per event
        public void AttendanceCount()
        {
            foreach (var ev in em.Eman)
            {
                int count = rm.Rman.Count(r =>
                    r.EId == ev.EventId &&
                    r.PStatus == Status.Attended);

                Console.WriteLine(
                    $"Event: {ev.EventName}, Attendance Count: {count}");
            }
        }

        // 10. Attendance percentage
        public void AttendancePercentage()
        {
            foreach (var ev in em.Eman)
            {
                int total = rm.Rman.Count(r => r.EId == ev.EventId && r.PStatus != Status.Cancelled);

                int attended = rm.Rman.Count(r => r.EId == ev.EventId && r.PStatus == Status.Attended);

                decimal percentage = 0;

                if (total > 0)
                {
                    percentage = (decimal)attended / total * 100;
                }

                Console.WriteLine(
                    $"Event: {ev.EventName}, Attendance: {attended}/{total}, Percentage: {percentage}%");
            }
        }
    }
}


