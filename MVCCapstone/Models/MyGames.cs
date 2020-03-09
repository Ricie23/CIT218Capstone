using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCapstone.Models
{

    public class MyGames
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ConcurrencyCheck]
        [MinLength(3, ErrorMessage = "The name must be longer than 3 characters")]
        [MaxLength(40, ErrorMessage = "The name must be less than 40 characters")]
        [Display(Name = "Game Title")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The genre must be at least 3 characters")]
        [MaxLength(40, ErrorMessage = "The genre must be less than 40 characters")]
        public string Genre { get; set; }

        [RegularExpression(@"^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$", ErrorMessage = "Please enter in currency format(00.00)]")]
        public double Price { get; set; }

        public virtual ICollection<Stats> Stats { get; set; }
        public virtual ICollection<Trophies> Trophies { get; set; }
        public virtual ICollection<CoverArt> Covers { get; set; }


    }
}