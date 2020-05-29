using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TaskForPatricipantModel
    {
        public string Skill { get; set; }

        public string DateOfBegin { get; set; }

        public string DateOfEnd { get; set; }

        public ICollection<CompetitionStage> Stages { get; set; }

        public TaskForPatricipantModel()
        {
            Stages = new List<CompetitionStage>();
        }

        public class CompetitionStage
        {
            public string Type { get; set; }
            public ICollection<StageTask> Tasks { get; set; }

            public CompetitionStage()
            {
                Tasks = new List<StageTask>();
            }

            public class StageTask
            {
                public int Id { get; set; }

                public string TaskDateOfBegin { get; set; }

                public string TaskDateOfEnd { get; set; }

                public bool IsActual { get; set; }

                public string Description { get; set; }
            }
        }
    }
}