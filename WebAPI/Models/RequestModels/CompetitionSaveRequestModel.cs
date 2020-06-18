using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class CompetitionSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите id задания")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id соревнования не может быть отрицательным")]
        public int competitionId { get; set; }

        [Required(ErrorMessage = "Укажите название профессии")]
        [MaxLength(30)]
        public string skill { get; set; }

        [Required(ErrorMessage = "Укажите дату начала")]
        public string dateOfBegin { get; set; }

        [Required(ErrorMessage = "Укажите дату конца")]
        public string dateOfEnd { get; set; }
    }
}