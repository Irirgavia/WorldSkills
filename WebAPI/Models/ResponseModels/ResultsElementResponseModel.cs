namespace WebAPI.Models.ResponseModels
{
    using System.Collections.Generic;

    public class ResultsElementResponseModel
    {
        public string Skill { get; set; }

        public string DateOfBegin { get; set; }

        public string DateOfEnd { get; set; }

        public ICollection<ResultsStage> Stages { get; set; }

        public ResultsElementResponseModel()
        {
            Stages = new List<ResultsStage>();
        }
    }
}