namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;

    public interface IParticipantService : IDisposable
    {
        void RegistrationNewParticipantOnActualCompetition(int competitionId, int participantId);

        void CreateParticipant(UserDTO user, AddressDTO address);

        ParticipantDTO GetParticipant(UserDTO user);

        void UpdateParticipant(ParticipantDTO participant);

        IEnumerable<StageDTO> GetStages(ParticipantDTO participant);

        AnswerDTO GetParticipantAnswer(ParticipantDTO participant);

        void CreateAnswer(int participant, int taskId, string projectLink, string notes);
    }
}