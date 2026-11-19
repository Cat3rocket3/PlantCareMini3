using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCareMini.Data.Data.Models
{
    public class CareNote
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public int PlantId { get; set; }
        public Plant Plant { get; set; } = null!;
    }
}
