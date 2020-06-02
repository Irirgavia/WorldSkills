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
                    cfg.CreateMap<AccountDTO, AccountEntity>()
                       .ForMember(a => a.CredentialsIdEntity, p => p.MapFrom(b => b.Credentials))
                       .ForMember(a => a.PersonalDataIdEntity, p => p.MapFrom(b => b.PersonalData));

                    cfg.CreateMap<AccountEntity, AccountDTO>()
                       .ForMember(a => a.Credentials, p => p.MapFrom(b => b.CredentialsIdEntity))
                       .ForMember(a => a.PersonalData, p => p.MapFrom(b => b.PersonalDataIdEntity));

                    cfg.CreateMap<AddressDTO, AddressEntity>();
                    cfg.CreateMap<AddressEntity, AddressDTO>();

                    cfg.CreateMap<CredentialsDTO, CredentialsEntity>()
                       .ForMember(a => a.RoleEntity, p => p.MapFrom(b => b.Role));
                    cfg.CreateMap<CredentialsEntity, CredentialsDTO>()
                       .ForMember(a => a.Role, p => p.MapFrom(b => b.RoleEntity));

                    cfg.CreateMap<PersonalDataDTO, PersonalDataEntity>()
                       .ForMember(a => a.AddressEntity, p => p.MapFrom(b => b.Address));

                    cfg.CreateMap<PersonalDataEntity, PersonalDataDTO>()
                       .ForMember(a => a.Address, p => p.MapFrom(b => b.AddressEntity));

                    cfg.CreateMap<RoleDTO, RoleEntity>();
                    cfg.CreateMap<RoleEntity, RoleDTO>();

                    cfg.CreateMap<AnswerDTO, AnswerEntity>()
                       .ForMember(a => a.ResultEntity, p => p.MapFrom(b => b.Result));
                    cfg.CreateMap<AnswerEntity, AnswerDTO>()
                       .ForMember(a => a.Result, p => p.MapFrom(b => b.ResultEntity));

                    cfg.CreateMap<CompetitionDTO, CompetitionEntity>()
                       .ForMember(a => a.SkillEntity, p => p.MapFrom(b => b.Skill))
                       .ForMember(a => a.StageEntities, p => p.MapFrom(b => b.Stages));
                    cfg.CreateMap<CompetitionEntity, CompetitionDTO>()
                       .ForMember(a => a.Skill, p => p.MapFrom(b => b.SkillEntity))
                       .ForMember(a => a.Stages, p => p.MapFrom(b => b.StageEntities));

                    cfg.CreateMap<PrizeDTO, PrizeEntity>();
                    cfg.CreateMap<PrizeEntity, PrizeDTO>();

                    cfg.CreateMap<ResultDTO, ResultEntity>()
                       .ForMember(a => a.PrizeEntity, p => p.MapFrom(b => b.Prize));
                    cfg.CreateMap<ResultEntity, ResultDTO>()
                       .ForMember(a => a.Prize, p => p.MapFrom(b => b.PrizeEntity));

                    cfg.CreateMap<SkillDTO, SkillEntity>();
                    cfg.CreateMap<SkillEntity, SkillDTO>();

                    cfg.CreateMap<StageDTO, StageEntity>()
                       .ForMember(a => a.StageTypeEntity, p => p.MapFrom(b => b.StageType))
                       .ForMember(a => a.TaskEntities, p => p.MapFrom(b => b.Tasks));
                    cfg.CreateMap<StageEntity, StageDTO>()
                       .ForMember(a => a.StageType, p => p.MapFrom(b => b.StageTypeEntity))
                       .ForMember(a => a.Tasks, p => p.MapFrom(b => b.TaskEntities));

                    cfg.CreateMap<StageTypeDTO, StageTypeEntity>();
                    cfg.CreateMap<StageTypeEntity, StageTypeDTO>();

                    cfg.CreateMap<TaskDTO, TaskEntity>()
                       .ForMember(a => a.AnswerEntities, p => p.MapFrom(b => b.Answers))
                       .ForMember(a => a.AddressEntities, p => p.MapFrom(b => b.Addresses));

                    cfg.CreateMap<TaskEntity, TaskDTO>()
                       .ForMember(a => a.Answers, p => p.MapFrom(b => b.AnswerEntities))
                       .ForMember(a => a.Addresses, p => p.MapFrom(b => b.AddressEntities));

                    cfg.CreateMap<MailDTO, MailEntity>();
                    cfg.CreateMap<MailEntity, MailDTO>();

                    cfg.CreateMap<NewsDTO, NewsEntity>();
                    cfg.CreateMap<NewsEntity, NewsDTO>();

                    cfg.CreateMap<NotificationDTO, NotificationEntity>()
                       .ForMember(a => a.MailEntity, p => p.MapFrom(b => b.Mail));
                    cfg.CreateMap<NotificationEntity, NotificationDTO>()
                       .ForMember(a => a.Mail, p => p.MapFrom(b => b.MailEntity));
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