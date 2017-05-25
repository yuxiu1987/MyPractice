using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerSpaceShip player = new PlayerSpaceShip();
            EnemySpaceShip enemy = new EnemySpaceShip() { HP = 80 };
            Random r = new Random();

            while(enemy.HP >0)
            {
                player.PlayerAttack(player.cannon, r.Next(0, 100), enemy);
                player.PlayerAttack(player.laser, r.Next(0, 100), enemy);
                player.PlayerAttack(player.missile, r.Next(0, 100), enemy);
            }
            Console.ReadKey();
        }
    }



    public class EnemySpaceShip
    {
        public int HP { get; set; }
        public bool Isdestroyed { get; set; } = false;
        public void UnderAttack(int damage)
        {
            this.HP -= damage;
            if (HP <= 0) Isdestroyed = true;
        }
    }

    public class PlayerSpaceShip 
    {
        public IAttack laser = new Laser();
        public IAttack cannon = new Cannon();
        public IAttack missile = new Missile();

        public IAttack weapon = new Weapon();

        public void PlayerAttack(IAttack iattack , int rand , EnemySpaceShip target)
        {
            iattack.WeaponAttack(target, rand);
        }
        
    }

    public interface IAttack
    {
        void WeaponAttack(EnemySpaceShip target ,int rand);
    }

    public class Weapon:IAttack
    {
        private int BaseDamage { get; set; } 

        public int Damage { get; set; }
        public virtual void WeaponAttack(EnemySpaceShip target, int rand)
        {

        }
    }

    public class Laser : Weapon
    {
        private int BaseDamage { get; set; } = 5;
        public override void WeaponAttack(EnemySpaceShip target , int rand)
        {
            Console.WriteLine("Use laser attack!");
            if (rand <= 90)
            {
                Console.WriteLine("Hit!");
                Damage = BaseDamage;
            }
            else
            {
                Console.WriteLine("Miss!");
                Damage = 0;
            }   
            Console.WriteLine("Random is :" + rand);
            Console.WriteLine("Enemy get damage : HP" + Damage);
            target.UnderAttack(Damage);
            if(target.Isdestroyed)
            {
                Console.WriteLine("Enemy is destoryed");
            }   
            Console.WriteLine("\n");
        }

    }

    public class Cannon :Weapon
    {
        private int BaseDamage { get; set; } = 6;
        public override void WeaponAttack(EnemySpaceShip target, int rand)
        {
            Console.WriteLine("Use cannon attack!");
            if (rand <= 30)
            {
                Console.WriteLine("Critical Hit!");
                Damage = 2 * BaseDamage;
            }
            else if (rand > 30 && rand <= 60)
            {
                Console.WriteLine("Hit!");
                Damage = BaseDamage;
            }
            else
            {
                Console.WriteLine("Miss!");
                Damage = 0;
            }
            
            
            Console.WriteLine("Random is :" + rand);

            Console.WriteLine("Enemy get damage : HP" + Damage);
            target.UnderAttack(Damage);
            if (target.Isdestroyed)
            {
                Console.WriteLine("Enemy is destoryed");
            }
            Console.WriteLine("\n");
        }
    }

    public class Missile : Weapon
    {
        private int BaseDamage { get; set; } = 4;
        public override void WeaponAttack(EnemySpaceShip target , int rand)
        {
            Console.WriteLine("Use missile attack!");
            if (rand <= 100)
            {
                Console.WriteLine("Hit!");
                Damage = BaseDamage;
            }
            else
            {
                Console.WriteLine("Miss!");
                Damage = 0;
            }
            Console.WriteLine("Enemy get damage : HP" + Damage);
            target.UnderAttack(Damage);
            if (target.Isdestroyed)
            {
                Console.WriteLine("Enemy is destoryed");
            }
            Console.WriteLine("\n");
        }
    }
}
