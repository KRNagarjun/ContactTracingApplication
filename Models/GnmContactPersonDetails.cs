using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactTrackerApplication.Models
{
    [Table("GNM_ContactPersonDetails")]
    public partial class GnmContactPersonDetails
    {
        [Key]
        [Column("ContactID")]
        public int ContactId { get; set; }
        public string Name { get; set; }
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [Column(TypeName = "decimal(12, 1)")]
        [Range(typeof(decimal),"35.0","40.0")]
        public decimal? CurrentTemperature { get; set; }
        public string Location { get; set; }
        public bool? IsCovidPositive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? EntryDateTime { get; set; }
    }
}
