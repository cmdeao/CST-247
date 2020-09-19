/*Cameron Deao
 * CST-247
 * James Sinevar
 * 9/18/2020 */

using Benchmark___Bible_Verse.Models;
using Benchmark___Bible_Verse.Services;
using Benchmark___Bible_Verse.Services.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Benchmark___Bible_Verse.Services.Business
{
    public class VerseService
    {
        VerseDAO dao = new VerseDAO();

        public bool InsertVerse(BibleVerse verse)
        {
            return dao.InsertVerse(verse);
        }

        public BibleVerse FindVerse(BibleVerse verse)
        {
            verse = dao.FindVerse(verse);
            return verse;
        }
    }
}