using MediatR;

namespace Application.Features.Mediatr.Discounts.Commands
{
    public class ChangeDiscountStatusToTrueCommand:IRequest
    {
        public int Id { get; set; }

        public ChangeDiscountStatusToTrueCommand(int id)
        {
            Id = id;
        }
    }
}
