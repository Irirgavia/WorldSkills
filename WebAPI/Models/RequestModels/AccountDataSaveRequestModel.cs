namespace WebAPI.Models.RequestModels
{
    public class AccountDataSaveRequestModel
    {
        public string oldLogin { get; set; }

        public string oldPassword { get; set; }

        public string newLogin { get; set; }

        public string newPassword { get; set; }
    }
}