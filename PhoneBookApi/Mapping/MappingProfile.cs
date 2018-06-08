using AutoMapper;
using PhoneBookApi.Controllers.Resources;
using PhoneBookApi.Core.Models;

namespace PhoneBookApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resources
            CreateMap<Record, RecordResource>()
                .ForMember(re => re.Title, opt => opt.MapFrom(t => t.Title.Text));
            CreateMap<Title, TitleResource>();


            //API Resource to Domain
            CreateMap<SaveRecordResource, Record>()
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForMember(r => r.TitleId, opt => opt.MapFrom(rr => rr.TitleId));
                
        }
    }
}
