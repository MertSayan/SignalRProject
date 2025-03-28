using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.SocialMedias.Commands
{
    public class DeleteSocialMediaCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteSocialMediaCommand(int id)
        {
            Id = id;
        }
    }
}
