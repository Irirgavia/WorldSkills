namespace BLL.Utilities
{
    public static class MessageUtility
    {
        public static string GetMessageForUpdateObject(string mailTo, string subject)
        {
            return
                $"Уважаемый(-ая) {mailTo}, объект {subject} был обновлён. Проверьте данные об указанном соревновании.";
        }

        public static string GetMessageForUpdateAnswer(string mailTo, float mark)
        {
            return
                $"Уважаемый(-ая) {mailTo}, была выставлена оценка {mark}. Проверьте данные об связанном соревновании.";
        }
    }
}