using MediatR;

namespace Application.Features.Mediatr.Contacts.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
