using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MobileAheresisAPI.Models;
using CRM.Core.Domain.TreatmentRecords;
using MobileAheresisAPI.Models.TreatmentRecords;

namespace MobileAheresisAPI.Utils
{
    public class MarketPlaceApiMapperConfiguration : Profile
    {
        public MarketPlaceApiMapperConfiguration()
        {


            CreateMap<LabValuesModel, LabValues>()

            .ForMember(dest => dest.TreatmentRecord, mo => mo.Ignore());
            CreateMap<OtherLabValuesModel,OtherLabValues>()

           .ForMember(dest => dest.LabValues, mo => mo.Ignore());


        }
    }
}
