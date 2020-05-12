namespace BLL
{
    using System.Collections;
    using System.Collections.Generic;

    using AutoMapper;

    using BLL.DTO;

    using DAL.Entities;

    public class ObjectMapper
    {
        private IMapper mapper;

        public ObjectMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
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
                    });

            this.mapper = config.CreateMapper();
        }

        public AddressDTO ToBLO(AddressEntity address)
        {
            return this.mapper.Map<AddressEntity, AddressDTO>(address);
        }

        public AdministratorDTO ToBLO(AdministratorEntity administrator)
        {
            return this.mapper.Map<AdministratorEntity, AdministratorDTO>(administrator);
        }

        public AnswerDTO ToBLO(AnswerEntity answer)
        {
            return this.mapper.Map<AnswerEntity, AnswerDTO>(answer);
        }

        public CompetitionDTO ToBLO(CompetitionEntity competition)
        {
            return this.mapper.Map<CompetitionEntity, CompetitionDTO>(competition);
        }

        public JudgeDTO ToBLO(JudgeEntity judge)
        {
            return this.mapper.Map<JudgeEntity, JudgeDTO>(judge);
        }

        public ParticipantDTO ToBLO(ParticipantEntity participant)
        {
            return this.mapper.Map<ParticipantEntity, ParticipantDTO>(participant);
        }

        public ResultDTO ToBLO(ResultEntity result)
        {
            return this.mapper.Map<ResultEntity, ResultDTO>(result);
        }

        public SkillDTO ToBLO(SkillEntity skill)
        {
            return this.mapper.Map<SkillEntity, SkillDTO>(skill);
        }

        public StageDTO ToBLO(StageEntity stage)
        {
            return this.mapper.Map<StageEntity, StageDTO>(stage);
        }

        public TaskDTO ToBLO(TaskEntity task)
        {
            return this.mapper.Map<TaskEntity, TaskDTO>(task);
        }

        public TrainerDTO ToBLO(TrainerEntity trainer)
        {
            return this.mapper.Map<TrainerEntity, TrainerDTO>(trainer);
        }

        public UserDTO ToBLO(UserEntity user)
        {
            return this.mapper.Map<UserEntity, UserDTO>(user);
        }

        public ICollection<AddressDTO> ToBLOList(IEnumerable<AddressEntity> collection)
        {
            var items = new List<AddressDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<AdministratorDTO> ToBLOList(IEnumerable<AdministratorEntity> collection)
        {
            var items = new List<AdministratorDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<AnswerDTO> ToBLOList(IEnumerable<AnswerEntity> collection)
        {
            var items = new List<AnswerDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<CompetitionDTO> ToBLOList(IEnumerable<CompetitionEntity> collection)
        {
            var items = new List<CompetitionDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<JudgeDTO> ToBLOList(IEnumerable<JudgeEntity> collection)
        {
            var items = new List<JudgeDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<ParticipantDTO> ToBLOList(IEnumerable<ParticipantEntity> collection)
        {
            var items = new List<ParticipantDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<ResultDTO> ToBLOList(IEnumerable<ResultEntity> collection)
        {
            var items = new List<ResultDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<SkillDTO> ToBLOList(IEnumerable<SkillEntity> collection)
        {
            var items = new List<SkillDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }


        public ICollection<StageDTO> ToBLOList(IEnumerable<StageEntity> collection)
        {
            var items = new List<StageDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<TaskDTO> ToBLOList(IEnumerable<TaskEntity> collection)
        {
            var items = new List<TaskDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<TrainerDTO> ToBLOList(IEnumerable<TrainerEntity> collection)
        {
            var items = new List<TrainerDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public ICollection<UserDTO> ToBLOList(IEnumerable<UserEntity> collection)
        {
            var items = new List<UserDTO>();
            foreach (var item in collection)
            {
                items.Add(this.ToBLO(item));
            }

            return items;
        }

        public AddressEntity ToDLO(AddressDTO address)
        {
            return this.mapper.Map<AddressDTO, AddressEntity>(address);
        }

        public AdministratorEntity ToDLO(AdministratorDTO administrator)
        {
            return this.mapper.Map<AdministratorDTO, AdministratorEntity>(administrator);
        }

        public AnswerEntity ToDLO(AnswerDTO answer)
        {
            return this.mapper.Map<AnswerDTO, AnswerEntity>(answer);
        }

        public CompetitionEntity ToDLO(CompetitionDTO competition)
        {
            return this.mapper.Map<CompetitionDTO, CompetitionEntity>(competition);
        }

        public JudgeEntity ToDLO(JudgeDTO judge)
        {
            return this.mapper.Map<JudgeDTO, JudgeEntity>(judge);
        }

        public ParticipantEntity ToDLO(ParticipantDTO participant)
        {
            return this.mapper.Map<ParticipantDTO, ParticipantEntity>(participant);
        }

        public ResultEntity ToDLO(ResultDTO result)
        {
            return this.mapper.Map<ResultDTO, ResultEntity>(result);
        }

        public SkillEntity ToDLO(SkillDTO skill)
        {
            return this.mapper.Map<SkillDTO, SkillEntity>(skill);
        }

        public StageEntity ToDLO(StageDTO stage)
        {
            return this.mapper.Map<StageDTO, StageEntity>(stage);
        }

        public TaskEntity ToDLO(TaskDTO task)
        {
            return this.mapper.Map<TaskDTO, TaskEntity>(task);
        }

        public TrainerEntity ToDLO(TrainerDTO trainer)
        {
            return this.mapper.Map<TrainerDTO, TrainerEntity>(trainer);
        }

        public UserEntity ToDLO(UserDTO user)
        {
            return this.mapper.Map<UserDTO, UserEntity>(user);
        }
    }
}