namespace BLL.Utilities
{
    using System.Collections.Generic;

    using AutoMapper;

    using BLL.DTO;
    using BLL.DTO.Account;
    using BLL.DTO.Competition;
    using BLL.DTO.NotificationSystem;

    using DAL.Entities;
    using DAL.Entities.Account;
    using DAL.Entities.Competition;
    using DAL.Entities.NotificationSystem;

    public static class ObjectMapper<TFrom, TTo>
    {
        private static IMapper mapper;

        static ObjectMapper()
        {
            mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccountDTO, AccountEntity>();
                    cfg.CreateMap<AccountEntity, AccountDTO>();

                    cfg.CreateMap<AddressDTO, AddressEntity>();
                    cfg.CreateMap<AddressEntity, AddressDTO>();

                    cfg.CreateMap<CredentialsDTO, CredentialsEntity>();
                    cfg.CreateMap<CredentialsEntity, CredentialsDTO>();

                    cfg.CreateMap<PersonalDataDTO, PersonalDataEntity>();
                    cfg.CreateMap<PersonalDataEntity, PersonalDataDTO>();

                    cfg.CreateMap<RoleDTO, RoleEntity>();
                    cfg.CreateMap<RoleEntity, RoleDTO>();

                    cfg.CreateMap<AnswerDTO, AnswerEntity>();
                    cfg.CreateMap<AnswerEntity, AnswerDTO>();

                    cfg.CreateMap<CompetitionDTO, CompetitionEntity>();
                    cfg.CreateMap<CompetitionEntity, CompetitionDTO>();

                    cfg.CreateMap<PrizeDTO, PrizeEntity>();
                    cfg.CreateMap<PrizeEntity, PrizeDTO>();

                    cfg.CreateMap<ResultDTO, ResultEntity>();
                    cfg.CreateMap<ResultEntity, ResultDTO>();

                    cfg.CreateMap<SkillDTO, SkillEntity>();
                    cfg.CreateMap<SkillEntity, SkillDTO>();

                    cfg.CreateMap<StageDTO, StageEntity>();
                    cfg.CreateMap<StageEntity, StageDTO>();

                    cfg.CreateMap<StageTypeDTO, StageTypeEntity>();
                    cfg.CreateMap<StageTypeEntity, StageTypeDTO>();

                    cfg.CreateMap<TaskDTO, TaskEntity>();
                    cfg.CreateMap<TaskEntity, TaskDTO>();

                    cfg.CreateMap<MailDTO, MailEntity>();
                    cfg.CreateMap<MailEntity, MailDTO>();

                    cfg.CreateMap<NewsDTO, NewsEntity>();
                    cfg.CreateMap<NewsEntity, NewsDTO>();

                    cfg.CreateMap<NotificationDTO, NotificationEntity>();
                    cfg.CreateMap<NotificationEntity, NotificationDTO>();
                }).CreateMapper();
        }

        public static TTo Map(TFrom fromModel)
        {
            return mapper.Map<TFrom, TTo>(fromModel);
        }

        public static IEnumerable<TTo> MapList(IEnumerable<TFrom> fromModel)
        {
            return mapper.Map<IEnumerable<TFrom>, IEnumerable<TTo>>(fromModel);
        }
    }
}