using Application.Features.Mediatr.Contacts.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Contacts.Queries
{
    public class GetByIdContactQuery:IRequest<GetByIdContactQueryResult>
    {
        public int Id { get; set; }

        public GetByIdContactQuery(int id)
        {
            Id = id;
        }
    }
}
