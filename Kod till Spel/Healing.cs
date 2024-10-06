using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel
{
    class Healing
    {
        Hero hero = GameState.CurrentHero;
        public void _Healing()
        {
            if (hero.hp == hero.maxHp)
            {
                Console.WriteLine("Din hjälte har redan fullt HP");
            }
            else
            {
                Console.WriteLine("Din hjälte börjar Meditera för att återställa HP");
                while (hero.hp < hero.maxHp)
                {
                    if (hero.hp < hero.maxHp * 0.25)    // När hjälten har mindre än 25% av maxHP
                    {
                        hero.hp += 1;
                        Console.WriteLine($"Nuvarande hp: {hero.hp}");
                        Thread.Sleep(300);
                    }else if (hero.hp < hero.maxHp * 0.50)      // När hjälten har mindre än 50% av maxHP
                    {
                        hero.hp += 1;
                        Console.WriteLine($"Nuvarande hp: {hero.hp}");
                        Thread.Sleep(450);  
                    }else if (hero.hp < hero.maxHp * 0.75)      // När hjälten har mindre än 75% av maxHP
                    {
                        hero.hp += 1;
                        Console.WriteLine($"Nuvarande hp: {hero.hp}");
                        Thread.Sleep(700);
                    }
                    else    // När hjälten har mindre än 100% av maxHP
                    {
                        hero.hp += 1;
                        Console.WriteLine($"Nuvarande hp: {hero.hp}");
                        Thread.Sleep(850);
                    }
                }

                Console.WriteLine($"Din hjälte har {hero.hp}hp av {hero.hp}hp");
            }
        }
    }
}
