using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitterturnierWPF
{
    public class UngueltigesInputException : Exception
    {
        public override string Message { get; }

        public UngueltigesInputException(string feldName)
        {
            this.Message = $"Ungültiges Input im Feld: {feldName}!";
        }

    }
}
