using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCapstone.Models
{
    public class CoverArt
    {
        public int ID { get; set; }

        [Index]
        [Display(Name = "Game ID")]
        public int MyGamesID { get; set; }
        [Display(Name = "Photo Path")]
        public string PhotoPath { get; set; }

        [Display(Name = "Alternative Text")]
        public string AltText { get; set; }
        public virtual MyGames MyGames { get; set; }
    }
}