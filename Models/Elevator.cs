using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Elevator
    {


        [Key]
        public long id { get; set; }
        public long column_id { get; set; }
        public int serial_nb { get; set; }
        public string model { get; set; }
        public string elevator_type { get; set; }
        public string? elevator_status { get; set; }
        public DateTime date_commissionning { get; set; }
        public DateTime date_last_inspection { get; set; }
        public string certificate_inspection { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
