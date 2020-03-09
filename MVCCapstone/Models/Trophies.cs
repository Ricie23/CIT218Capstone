using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCCapstone.Models
{
    public class Trophies
    {


        public int ID { get; set; }

        [Index]
        [Display(Name = "Game ID")]

        public int MyGamesID { get; set; }
        [MinLength(3, ErrorMessage = "Please enter more than 3 characters")]
        [MaxLength(30, ErrorMessage = "Please enter less than 30 characters")]
        [Required]
        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "Please enter more than 3 characters")]
        [MaxLength(100, ErrorMessage = "Please enter less than 100 characters")]
        public string Description { get; set; }

        [Display(Name = "Type (Bronze, Silver, Gold, or Platinum)")]
        [Required]
        [MinLength(4, ErrorMessage = "Please enter one of the four options: (Bronze, Silver, Gold, Platinum)")]
        [MaxLength(8, ErrorMessage = "Please enter one of the four options: (Bronze, Silver, Gold, Platinum)")]
        public string Type { get; set; }

        public virtual MyGames Games { get; set; }


    }
}