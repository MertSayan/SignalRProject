using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookingRepository
    {
        Task BookingStatusApproved(int id);
        Task BookingStatusCancelled(int id);
    }
}
