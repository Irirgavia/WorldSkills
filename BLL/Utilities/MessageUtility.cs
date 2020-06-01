namespace BLL.Utilities
{
    public static class MessageUtility
    {
        public static string GetMessageForUpdateObject(string nameTo, string subject)
        {
            return
                $"Уважаемый(-ая) {nameTo}, объект {subject} был обновлён. Проверьте данные об указанном соревновании.";
        }

        public static string GetMessageForUpdateAnswer(string nameTo, float mark)
        {
            return
                $"Уважаемый(-ая) {nameTo}, была выставлена оценка {mark}. Проверьте данные об связанном соревновании.";
        }
    }
}