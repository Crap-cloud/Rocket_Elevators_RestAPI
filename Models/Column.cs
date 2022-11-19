using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Column
    {

        
        [Key]
        public int id { get; set; }
        public string? status { get; set; }
        public int battery_id { get; set; }


    }
}
