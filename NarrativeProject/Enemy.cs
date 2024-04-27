using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NarrativeProject.Enemy;

namespace NarrativeProject
{
    public class Enemy
    {
        public abstract class Alien
        {
            public abstract void Defeat(Weapon weapon);
        }
    }
    public class RedAlien : Alien
    {
        public override void Defeat(Weapon weapon)
        {
            if (weapon is Grenade)
            {
                Console.WriteLine("Red Alien defeated with a Grenade!");
            }
            else
            {
                Console.WriteLine("Red Alien is not weak against this weapon.");
            }
        }
    }

    public class BlueAlien : Alien
    {
        public override void Defeat(Weapon weapon)
        {
            if (weapon is Sword)
            {
                Console.WriteLine("Blue Alien defeated with a Sword!");
            }
            else
            {
                Console.WriteLine("Blue Alien is not weak against this weapon.");
            }
        }
    }

    public class GreenAlien : Alien
    {
        public override void Defeat(Weapon weapon)
        {
            if (weapon is Flamethrower)
            {
                Console.WriteLine("Green Alien defeated with a Flamethrower!");
            }
            else
            {
                Console.WriteLine("Green Alien is not weak against this weapon.");
            }
        }
    }
}
