namespace BLL
{
    using System.Collections.Generic;

    using AutoMapper;

    using BLL.DTO;

    using DAL.Entities;

    public static class ObjectMapper<TFrom, TTo>
    {
        private static IMapper mapper;

        static ObjectMapper()
        {
            mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AddressDTO, AddressEntity>();
                    cfg.CreateMap<AddressEntity, AddressDTO>();

                    cfg.CreateMap<AdministratorDTO, AdministratorEntity>();
                    cfg.CreateMap<AdministratorEntity, AdministratorDTO>();

                    cfg.CreateMap<AnswerDTO, AnswerEntity>();
                    cfg.CreateMap<AnswerEntity, AnswerDTO>();

                    cfg.CreateMap<CompetitionDTO, CompetitionEntity>();
                    cfg.CreateMap<CompetitionEntity, CompetitionDTO>();

                    cfg.CreateMap<JudgeDTO, JudgeEntity>();
                    cfg.CreateMap<JudgeEntity, JudgeDTO>();

                    cfg.CreateMap<ParticipantDTO, ParticipantEntity>();
                    cfg.CreateMap<ParticipantEntity, ParticipantDTO>();

                    cfg.CreateMap<ResultDTO, ResultEntity>();
                    cfg.CreateMap<ResultEntity, ResultDTO>();

                    cfg.CreateMap<SkillDTO, SkillEntity>();
                    cfg.CreateMap<SkillEntity, SkillDTO>();

                    cfg.CreateMap<StageDTO, StageEntity>();
                    cfg.CreateMap<StageEntity, StageDTO>();

                    cfg.CreateMap<TaskDTO, TaskEntity>();
                    cfg.CreateMap<TaskEntity, TaskDTO>();

                    cfg.CreateMap<TrainerDTO, TrainerEntity>();
                    cfg.CreateMap<TrainerEntity, TrainerDTO>();

                    cfg.CreateMap<UserDTO, UserEntity>();
                    cfg.CreateMap<UserEntity, UserDTO>();

                    cfg.CreateMap<TFrom, TTo>();
                }).CreateMapper();
        }

        public static TTo Map(TFrom fromModel)
        {
           //mapper = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>()).CreateMapper();
            return mapper.Map<TFrom, TTo>(fromModel);
        }

        public static IEnumerable<TTo> MapList(IEnumerable<TFrom> fromModel)
        {
            //mapper = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>()).CreateMapper();
            return mapper.Map<IEnumerable<TFrom>, IEnumerable<TTo>>(fromModel);
        }
    }
}