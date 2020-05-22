using AutoMapper;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, Entities.User>();
            CreateMap<TodoTaskModel, Entities.TodoTask>();
            CreateMap<Entities.TodoTask, TodoTaskResourceModel>();
            CreateMap<FilterModel, Entities.Filter>();
        }
    }
}