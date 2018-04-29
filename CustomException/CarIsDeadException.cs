using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException() { }
        //  Передача  сообщения  конструктору  родительского  класса.
        public CarIsDeadException(string message, string cause, DateTime time)
        : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
