using Application.Features.Mediatr.Sliders.Commands;
using Application.Features.Mediatr.Sliders.Results;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MapperProfiles
{
    public class SliderProfile:Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider, CreateSliderCommand>().ReverseMap();
            CreateMap<Slider, UpdateSliderCommand>().ReverseMap();
            CreateMap<Slider, GetSliderQueryResult>().ReverseMap();
            CreateMap<Slider, GetByIdSliderQueryResult>().ReverseMap();
        }
    }
}
