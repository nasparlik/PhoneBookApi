using AutoMapper;
using PhoneBookApi.Controllers.Resources;
using PhoneBookApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resources
            CreateMap<Record, RecordResource>();


            //API Resource to Domain
            CreateMap<SaveRecordResource, Record>()
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForMember(r => r.TitleId, opt => opt.MapFrom(rr => rr.TitleId));
                
        }
    }
}
