using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel
{
    class Healing
    {
        public void _Healing(Hero hero01)
        {
            if (hero01.hp == hero01.maxHp)
            {
                Console.WriteLine("Din hjälte har redan fullt HP");
            }
            else
            {
                Console.WriteLine("Din hjälte börjar Meditera för att återställa HP");
                while (hero01.hp < hero01.maxHp)
                {
                    hero01.hp += 1;
                    Console.WriteLine($"Nuvarande hp: {hero01.hp}");
                    Thread.Sleep(1000);
                }


                Console.WriteLine($"Din hjälte har {hero01.hp}hp av {hero01.hp}hp");
            }
        }
    }
}
