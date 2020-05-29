namespace BLL.Services
{
    using BLL.DTO;
    using DAL.Entities;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.Services.Interfaces;
    using BLL.Utilities;

    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork unitOfWork;

        public ParticipantService(string connection)
        {
            this.unitOfWork = new UnitOfWork(connection);
        }


        public void RegistrationNewParticipantOnActualCompetition(int competitionId, int participantId)
        {
            var competition = this.unitOfWork.CompetitionRepository.Get(c => c.Id == competitionId).FirstOrDefault();
            var townStage = competition.Stages.FirstOrDefault();
            var participantEF = this.unitOfWork.ParticipantRepository.Get(x => x.Id == participantId).FirstOrDefault();
            townStage.Participants.Add(participantEF);
            this.unitOfWork.SaveChanges();
        }

        public void CreateParticipant(UserDTO user, AddressDTO address)
        {
            var userEF = this.unitOfWork.UserRepository.GetUserByLogin(user.Login);
            userEF.Role = Role.Participant;

            this.unitOfWork.ParticipantRepository.Create(
                new ParticipantEntity(
                    userEF.Id,
                    null,
                    ObjectMapper<AddressDTO, AddressEntity>.Map(address)));
            this.unitOfWork.SaveChanges();
        }

        public ParticipantDTO GetParticipant(UserDTO user)
        {
            return ObjectMapper<ParticipantEntity, ParticipantDTO>.Map(
                this.unitOfWork.ParticipantRepository.Get(p => p.User.Id == user.Id).FirstOrDefault());
        }

        public void UpdateParticipant(ParticipantDTO participant)
        {
            this.unitOfWork.UserRepository.Update(ObjectMapper<UserDTO, UserEntity>.Map(participant.User));
            this.unitOfWork.ParticipantRepository.Update(
                ObjectMapper<ParticipantDTO, ParticipantEntity>.Map(participant));
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<StageDTO> GetStages(ParticipantDTO participant)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.unitOfWork.StageRepository.Get(
                    s => s.Participants.Contains(ObjectMapper<ParticipantDTO, ParticipantEntity>.Map(participant))));
        }

        public AnswerDTO GetParticipantAnswer(ParticipantDTO participant)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.Map(
                this.unitOfWork.AnswerRepository.Get(a => a.Participant.Id == participant.Id).FirstOrDefault());
        }

        public void CreateAnswer(
            int participant,
            int taskId,
            string projectLink,
            string notes)
        {
            var answer = new AnswerEntity(participant, new ResultEntity(), taskId, projectLink, notes);

            this.unitOfWork.AnswerRepository.Create(answer);
            this.unitOfWork.SaveChanges();
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