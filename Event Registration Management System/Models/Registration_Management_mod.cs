using System;
using System.Collections.Generic;
using System.Text;

namespace Registration_Management_mod.Models
{
    public enum Status
    {
        Registered, 
        Cancelled, 
        Attended
    }
    public class Reg
    {
        public int EId { get; set; }
        public int PId { get; set; }
        public int RId { get; set; }
        
        public DateTime RDate { get; set; }
        
        public decimal Paidfee { get; set; }
        public Status PStatus { get; set; }

        public Reg(int pid, int eid,int rid,DateTime rdate, decimal paidfee,Status status )
        {
            RId = rid;
            RDate = rdate;
            Paidfee= paidfee;
            PStatus= status;
        }
    }
}
