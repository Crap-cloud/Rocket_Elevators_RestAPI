using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Customer
    {

        
        [Key]
        public int id { get; set; }
        public string? EmailCompanyContact { get; set; }

    }
}
