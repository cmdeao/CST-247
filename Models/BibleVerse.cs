/*Cameron Deao
 * CST-247
 * James Sinevar
 * 9/18/2020 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Benchmark___Bible_Verse.Models
{
    //Enum utilized for Testament selection.
    public enum Testament
    {
        Old,
        New
    }

    public class BibleVerse
    {
        //Established variables for BibleVerse object.
        //All fields are required and utilize getters and setters.

        [Required]
        public Testament Testament { get; set; }

        [Required(ErrorMessage = "Enter a book")]
        public string Book { get; set; }

        [Required(ErrorMessage = "Enter a chapter")]
        public int Chapter { get; set; }

        [Required(ErrorMessage = "Enter a Verse")]
        public int VerseNum { get; set; }

        [Required(ErrorMessage = "Enter text")]
        public string VerseText { get; set; }
    }
}