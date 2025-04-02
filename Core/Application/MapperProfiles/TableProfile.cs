using Application.Features.Mediatr.Tables.Commands;
using Application.Features.Mediatr.Tables.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
	public class TableProfile:Profile
	{
        public TableProfile()
        {
			CreateMap<Table, CreateTableCommand>().ReverseMap();
			CreateMap<Table, UpdateTableCommand>().ReverseMap();
			CreateMap<Table, GetTableQueryResult>().ReverseMap();
			CreateMap<Table, GetByIdTableQueryResult>().ReverseMap();
		}
    }
}
