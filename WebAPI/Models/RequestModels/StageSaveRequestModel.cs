using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class StageSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите id соревнования")]
        [Range(1, Int32.MaxValue, ErrorMessage = "id соревнования не может быть отрицательным")]
        public int competitionId { get; set; }

        [Required(ErrorMessage = "Укажите id этапа")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id этапа не может быть отрицательным")]
        public int id { get; set; }

        [Required(ErrorMessage = "Укажите тип этапа")]
        [MaxLength(30)]
        public string stagetype { get; set; }

    }
}