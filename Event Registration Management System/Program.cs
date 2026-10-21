using Event_Management_Mod;
using Event_Management_Mod.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Event_Management_Serv.Services;
using Participant_Registration_Management_Serv.Services;
using Registration_Management_Serv.Services;


namespace Program_main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EventManagement obj = new EventManagement();
            Participants pm = new Participants();
            RegistrationManagement rm = new RegistrationManagement();
            obj.RegEvent();
            obj.SearchbyId();
            obj.Searchbyname();
            obj.Update();

        }
    }
}

