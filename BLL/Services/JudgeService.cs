namespace BLL.Services
{
    using System;
    using System.Collections.Generic;

    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class JudgeService : IJudgeService
    {
        private readonly IUnitOfWork unitOfWork;

        public JudgeService(string connection)
        {
            this.unitOfWork = new UnitOfWork(connection);
        }

        public void RateAnswer(int answerId, float mark, string notes)
        {
            var answer = this.unitOfWork.AnswerRepository.GetById(answerId);
            answer.Result.Mark = mark;
            answer.Result.Notes = notes;
            this.unitOfWork.AnswerRepository.Update(answer);
            this.unitOfWork.SaveChanges();

            MailUtility.SendEmail(
                new List<string>() { answer.Participant.User.Mail },
                "Обновление оценки",
                MessageUtility.GetMessageForUpdateAnswer(answer.Participant.User.Mail, mark));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork?.Dispose();
            }
        }
    }
}