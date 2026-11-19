using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCareMini.Data.Data.Models
{
    public class Watering
    {
        public int Id { get; set; }
        public DateTime WateredAt { get; set; }
        public int Milliliters { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; } = null!;
    }
}
