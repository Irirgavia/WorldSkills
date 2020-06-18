using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class MarkSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите id ответа")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id ответа не может быть отрицательным")]
        public int answerId { get; set; }

        [Required(ErrorMessage = "Укажите оценку")]
        public float mark { get; set; }
    }
}