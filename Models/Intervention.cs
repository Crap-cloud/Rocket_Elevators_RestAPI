using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Intervention
    {


        [Key]
        public int? id { get; set; }
        public int? Author { get; set; }
        public int CustomerID { get; set; }
        public int BuildingID { get; set; }
        public int BatteryID { get; set; }
        public int ColumnID { get; set; }
        public int ElevatorID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Result { get; set; }
        public string? Report { get; set; }
        public string? Status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }



    }
}
