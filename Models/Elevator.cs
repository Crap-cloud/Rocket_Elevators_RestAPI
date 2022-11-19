using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Elevator
    {

        
        [Key]
        public int id { get; set; }
        public string? elevator_status { get; set; }
        public int column_id { get; set; }


    }
}
