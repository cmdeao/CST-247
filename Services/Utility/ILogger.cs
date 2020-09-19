/*Cameron Deao
 * CST-247
 * James Sinevar
 * 9/18/2020 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark___Bible_Verse.Services.Utility
{
    //Established interface for NLog logging.
    interface ILogger
    {
        void Debug(string message);
        void Info(string message);
        void Warning(string message);
        void Error(Exception e, string message);
    }
}
