using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierKonsole
{
    public class NameSchonVorhandenException : Exception
    {
        public override string Message {  get; }

        public NameSchonVorhandenException(string name)
        {
            this.Message = $"Ritter '{name}' ist schon vorhanden!";
        }


    }
}
