using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ResponseModels
{
    public class ResultsStage
    {
        public string Type { get; set; }

        public ICollection<ResultsResultRecords> ResultRecords { get; set; }

        public ResultsStage()
        {
            ResultRecords = new List<ResultsResultRecords>();
        }
    }
}