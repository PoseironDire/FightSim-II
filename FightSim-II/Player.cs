using System;

namespace FightSim_II
{
    public class Player
    {
        public string name;
        private int hp = 100;

        //Healh Points
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
                hp = Math.Max(0, hp);
            }
        }
    }
}