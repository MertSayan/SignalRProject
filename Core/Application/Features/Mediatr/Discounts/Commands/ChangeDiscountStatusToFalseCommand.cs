using MediatR;

namespace Application.Features.Mediatr.Discounts.Commands
{
    public class ChangeDiscountStatusToFalseCommand:IRequest
    {
        public int Id { get; set; }

        public ChangeDiscountStatusToFalseCommand(int id)
        {
            Id = id;
        }
    }
}
