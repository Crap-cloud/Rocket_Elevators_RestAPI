using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Battery
    {


        [Key]
        public long id { get; set; }
        public long building_id { get; set; }
        public string battery_type { get; set; }
        public string? status { get; set; }
        public long employee_id { get; set; }
        public DateTime date_commissioning { get; set; }
        public DateTime date_last_inspection { get; set; }
        public string certificate_operations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


    }
}
