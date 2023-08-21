using AutoMapper;

using ModernisationChallengeApi.Dtos.TaskDtos;

using Task = ModernisationChallengeApi.Models.Task;

namespace ModernisationChallengeApi.MappingProfiles;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<Task, TaskResponse>();
    }
}
