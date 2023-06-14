using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubbe.Services.Restaurant.Domain.Entities
{
    public class TablesEntity
    {
        public int Id { get; set; }
        public string? Sector { get; set; }
        public int Number { get; set; }
    }
}
