using System;

namespace WebAPI.Models.RequestModels
{
    using System.ComponentModel.DataAnnotations;

    public class AnswerSaveRequestModel
    {
        [Required(ErrorMessage = "Укажите id задания")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id задания не может быть отрицательным")]
        public int taskId { get; set; }

        [Required(ErrorMessage = "Укажите id участника")]
        [Range(-1, Int32.MaxValue, ErrorMessage = "id участника не может быть отрицательным")]
        public int participantId { get; set; }

        [Required(ErrorMessage = "Укажите ссылку на ответ")]
        public string projectLink { get; set; }
    }
}