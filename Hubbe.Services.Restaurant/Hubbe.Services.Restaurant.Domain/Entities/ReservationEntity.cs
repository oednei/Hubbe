using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubbe.Services.Restaurant.Domain.Entities
{
    public class ReservationEntity
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfClients { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationTime { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }


    }
}
