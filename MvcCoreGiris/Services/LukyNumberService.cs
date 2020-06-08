using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    public class LukyNumberService
    {
        //Bu servis bize rasgele seçilmiş rakam sağlar.
        static readonly Random rnd = new Random(); 
        public int LukyNumber { get; private set; }
         public LukyNumberService()
        {
            LukyNumber = rnd.Next(10);
        }
    }
}
