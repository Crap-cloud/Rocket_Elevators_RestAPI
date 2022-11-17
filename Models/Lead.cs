﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;


namespace Rocket_Elevators_Rest_API.Models
{
    public class Lead
    {


        [Key]
        public long id { get; set; }
        public string? contactName { get; set; }
        public string? contactBusinessName { get; set; }
        public string? contactEmail { get; set; }
        public string? contactPhone { get; set; }
        public string? projectName { get; set; }
        public string? projectDescription { get; set; }
        public string? contactDepartement { get; set; }
        public string? message { get; set; }
        public DateOnly contactDate { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string? status { get; set; }

    }
}
