namespace BLL.Services
{
    using BLL.DTO;
    using DAL.Entities;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TypeStage = DAL.Entities.TypeStage;

    public class ParticipantService : IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        public ParticipantService(string connection)
        {
            this.unitOfWork = new UnitOfWork(connection);
        }

        public ParticipantDTO RegistrationNewParticipantOnActualCompetition(int idCompetition, UserDTO user, AddressDTO address)
        {
            try
            {
                var townStage = this.unitOfWork.StageRepository
                            .GetList(s => s.CompetitionId == idCompetition && s.TypeStage == TypeStage.Town)
                            .FirstOrDefault();

                this.unitOfWork.AddressRepository.Create(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
                var addressEntity = this.unitOfWork.AddressRepository.GetAddressesByPlace(
                    address.Country,
                    address.City,
                    address.Street,
                    address.House).FirstOrDefault();

                this.unitOfWork.SaveChanges();

                this.unitOfWork.UserRepository.Create(ObjectMapper<UserDTO, UserEntity>.Map(user));
                this.unitOfWork.SaveChanges();
                var userEntity = this.unitOfWork.UserRepository.Get(u => u.Login.Equals(user.Login));

                this.unitOfWork.ParticipantRepository.Create(
                    new ParticipantEntity(
                        userEntity,
                        null,
                        addressEntity,
                        new List<AnswerEntity>(),
                        new List<StageEntity>() { townStage }));

                this.unitOfWork.SaveChanges();
                var participant = this.unitOfWork.ParticipantRepository.Get(p => p.UserEntity.Login.Equals(user.Login));
            }
            catch (Exception e)
            {
                return null;
            }

            return ObjectMapper<ParticipantEntity, ParticipantDTO>.Map(
                this.unitOfWork.ParticipantRepository.Get(p => p.UserEntity.Login.Equals(user.Login)));
        }

        public void CreateParticipant(UserDTO user, AddressDTO address)
        {
            this.unitOfWork.UserRepository.Create(ObjectMapper<UserDTO, UserEntity>.Map(user));
            var userEF = this.unitOfWork.UserRepository.Get(u => u.Login.Equals(user.Login));
            this.unitOfWork.SaveChanges();
            this.unitOfWork.AddressRepository.Create(ObjectMapper<AddressDTO, AddressEntity>.Map(address));

            var addressEntity = this.unitOfWork.AddressRepository.GetAddressesByPlace(
                address.Country,
                address.City,
                address.Street,
                address.House).FirstOrDefault();

            this.unitOfWork.ParticipantRepository.Create(
                new ParticipantEntity(userEF, null, addressEntity, new List<AnswerEntity>(), new List<StageEntity>()));
            this.unitOfWork.SaveChanges();
        }

        public ParticipantDTO GetParticipant(UserDTO user)
        {
            return ObjectMapper<ParticipantEntity, ParticipantDTO>.Map(
                this.unitOfWork.ParticipantRepository.Get(p => p.UserEntity.Id == user.Id));
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

        public void CreateAnswer(AnswerDTO answer)
        {
            this.unitOfWork.AnswerRepository.Create(ObjectMapper<AnswerDTO, AnswerEntity>.Map(answer));
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