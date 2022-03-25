using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot
{
    static internal class Input
    {
        /// <summary>
        /// Метод для получения данных из консоли
        /// </summary>
        /// <returns></returns>
        static internal string ConsoleInput()
        {
            return Console.ReadLine().ToLower();
        }
    }
}
