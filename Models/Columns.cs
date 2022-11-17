using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Columns
    {
        [Key]
        public long id { get; set; }
        public long battery_id { get; set; }
        public string? column_type { get; set; }
        public int served_floors_nb { get; set; }
        public string? status { get; set; }
        public string? information { get; set; }
        public string? notes { get; set; }


    }
}
