using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Buildings
    {


        [Key]
        public long id { get; set; }
        public long customer_id { get; set; }
        public long address_id { get; set; }
        public string? addressBuilding { get; set; }
        public string? FullNameBuildingAdmin { get; set; }
        public string? EmailAdminBuilding { get; set; }
        public string? PhoneNumberBuildingAdmin { get; set; }
        public string? FullNameTechContact { get; set; }
        public string? TechContactEmail { get; set; }
        public string? TechContactPhone { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
