using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Exception_handling.View
{
    internal class View
    {
        /// <summary>
        /// Outputs a custom message based on the parameter.
        /// </summary>
        /// <param name="message"></param>
        internal void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
