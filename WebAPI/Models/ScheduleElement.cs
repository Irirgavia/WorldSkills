﻿namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;

    public class ScheduleElement
    {
        public string Skill { get; set; }

        public string DateOfBegin { get; set; }

        public string DateOfEnd { get; set; }

        public ICollection<CompetitionStage> Stages { get; set; }

        public class CompetitionStage
        {
            public string Type { get; set; }
            public ICollection<StageTask> Tasks { get; set; }

            public class StageTask
            {
                public string TaskDateOfBegin { get; set; }

                public string TaskDateOfEnd { get; set; }

                public bool IsActual { get; set; }

                public ICollection<string> Addresses { get; set; }
            }
        }
    }
}