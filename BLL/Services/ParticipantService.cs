namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;

    using TypeStage = DAL.Entities.TypeStage;

    public class ParticipantService : IDisposable
    {
        private readonly UnitOfWork unitOfWork;

        public ParticipantService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public ParticipantDTO RegistrationNewParticipantOnActualCompetition(string skill, UserDTO user, AddressDTO address)
        {
            try
            {
                var competiton =
                    this.unitOfWork.CompetitionRepository.GetList(
                        c => c.DateTimeEnd >= DateTime.Now && c.Skill.Name.Equals(skill)).FirstOrDefault();

                var townStage = this.unitOfWork.StageRepository
                    .GetList(s => competiton != null && s.Competition.Id == competiton.Id).FirstOrDefault(s => s.TypeStage == TypeStage.Town);

                this.unitOfWork.AddressRepository.CreateOrUpdate(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
                var addressEntity = this.unitOfWork.AddressRepository.GetAddressesByPlace(
                    address.Country,
                    address.City,
                    address.Street,
                    address.House).FirstOrDefault();

                this.unitOfWork.UserRepository.Create(ObjectMapper<UserDTO, UserEntity>.Map(user));
                var userEntity = this.unitOfWork.UserRepository.Get(u => u.Login.Equals(user.Login));
                this.unitOfWork.ParticipantRepository.Create(
                    new ParticipantEntity(
                        userEntity,
                        new TrainerEntity(),
                        addressEntity,
                        new List<AnswerEntity>(),
                        new List<StageEntity>() { townStage }));

                var participant = this.unitOfWork.ParticipantRepository.Get(p => p.User.Login.Equals(user.Login));

                townStage.Participants.Add(participant);
            }
            catch (Exception e)
            {
                return null;
            }

            this.unitOfWork.SaveChanges();
            return ObjectMapper<ParticipantEntity, ParticipantDTO>.Map(
                this.unitOfWork.ParticipantRepository.Get(p => p.User.Login.Equals(user.Login)));
        }

        public ParticipantDTO GetParticipant(UserDTO user)
        {
            return ObjectMapper<ParticipantEntity, ParticipantDTO>.Map(
                this.unitOfWork.ParticipantRepository.Get(p => p.User.Id == user.Id));
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
                this.unitOfWork.StageRepository.GetList(
                    s => s.Participants.Contains(ObjectMapper<ParticipantDTO, ParticipantEntity>.Map(participant))));
        }

        public AnswerDTO GetParticipantAnswer(ParticipantDTO participant)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.Map(
                this.unitOfWork.AnswerRepository.Get(a => a.Participant.Id == participant.Id));
        }

        public void CreateOrUpdateAnswer(AnswerDTO answer)
        {
            this.unitOfWork.AnswerRepository.CreateOrUpdate(ObjectMapper<AnswerDTO, AnswerEntity>.Map(answer));
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