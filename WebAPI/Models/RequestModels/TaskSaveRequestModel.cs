using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class TaskSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите id соревнования")]
        [Range(1, Int32.MaxValue, ErrorMessage = "id соревнования не может быть отрицательным")]
        public int competitionId { get; set; }

        [Required(ErrorMessage = "Укажите id этапа")]
        [Range(1, Int32.MaxValue, ErrorMessage = "id этапа не может быть отрицательным")]
        public int stageId { get; set; }

        [Required(ErrorMessage = "Укажите id задания")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id задания не может быть отрицательным")]
        public int id { get; set; }

        [Required(ErrorMessage = "Укажите дату начала")]
        public string taskDateOfBegin { get; set; }

        [Required(ErrorMessage = "Укажите дату конца")]
        public string taskDateOfEnd { get; set; }

        [Required(ErrorMessage = "Укажите описание")]
        public string description { get; set; }

        [Required(ErrorMessage = "Укажите адреса")]
        public string addresses { get; set; }
    }
}