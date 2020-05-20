namespace WebAPI.Models
{
    using System;
    
    public class ScheduleElement
    {
        public string Skill { get; set; }

        public string Stage { get; set; }

        public DateTime DateOfBegin { get; set; }

        public DateTime DateOfEnd { get; set; }

        public string Address { get; set; }

    }
}