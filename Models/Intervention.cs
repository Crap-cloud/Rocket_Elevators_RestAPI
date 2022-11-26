using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Intervention
    {

        
        [Key]
        public int id { get; set; }
        public DateTime? intervention_begin { get; set; }
        public DateTime? intervention_end { get; set; }
        public string? status { get; set; }


    }
}
