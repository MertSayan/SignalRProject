using Application.Features.Mediatr.Messages.Commands;
using Application.Features.Mediatr.Messages.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
	public class MessageProfile:Profile
	{
		public MessageProfile()
		{
			CreateMap<Message, CreateMessageCommand>().ReverseMap();
			CreateMap<Message, UpdateMessageCommand>().ReverseMap();
			CreateMap<Message, GetMessageQueryResult>().ReverseMap();
			CreateMap<Message, GetByIdMessageQueryResult>().ReverseMap();
		}
	}
}
