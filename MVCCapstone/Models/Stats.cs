using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCapstone.Models
{
    public class Stats
    {
        public int ID { get; set; }

        [Display(Name = "Game ID")]
        [Index]
        public int MyGamesID { get; set; }
        [Required]
        [Display(Name = "Hours Played")]
        [Range(0, 500, ErrorMessage = "Please enter only a number between 0 and 500")]
        public int HoursPlayed { get; set; }
        [Required]
        [Display(Name = "Have you beaten the game?")]
        public bool IsBeaten { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = "Please enter a number only between 0 and 50")]
        [Display(Name = "# of Trophies Earned")]
        public int TrophiesEarned { get; set; }
        public virtual MyGames Games { get; set; }



    }
}