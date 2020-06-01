namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    public class JudgeService : IJudgeService
    {
        private readonly ICompetitionUnitOfWork competitionUnitOfWork;
        private readonly IAccountUnitOfWork accountUnitOfWork;

        public JudgeService(string competitionConnection, string accountConnection)
        {
            this.competitionUnitOfWork = new CompetitionUnitOfWork(competitionConnection);
            this.competitionUnitOfWork = new CompetitionUnitOfWork(accountConnection);
        }

        public void RateAnswer(int answerId, float mark, string notes)
        {
            var answer = this.competitionUnitOfWork.AnswerRepository.GetById(answerId);
            answer.ResultEntity.Mark = mark;
            answer.ResultEntity.Notes = notes;
            this.competitionUnitOfWork.AnswerRepository.Update(answer);
            this.competitionUnitOfWork.SaveChanges();

            var account = this.accountUnitOfWork.AccountRepository
                .Get(a => a.Id == answer.AccountEntityId)
                .FirstOrDefault();

            if (account.IsMailNotificationTurnOn)
            {
                MailUtility.SendEmail(
                    new List<string>() { account.PersonalDataIdEntity.Mail },
                    "Обновление оценки",
                    MessageUtility.GetMessageForUpdateAnswer(account.PersonalDataIdEntity.Name, mark));
            }
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
                this.competitionUnitOfWork?.Dispose();
            }
        }
    }
}