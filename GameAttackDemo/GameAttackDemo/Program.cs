﻿using System;
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
            if (rand <= 90)
            {
                Damage = BaseDamage;
            }
            else Damage = 0;

            Console.WriteLine("Use laser attack!");
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
            if (rand <= 30)
            {
                Damage = 2 * BaseDamage;
            }
            else if (rand > 30 && rand <= 60)
            {
                Damage = BaseDamage;
            }
            else Damage = 0;
            Console.WriteLine("Use cannon attack!");
            Console.WriteLine("Random is :" + rand);
            if(rand<=30)
            {
                Console.WriteLine("Critical Hit!");
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

    public class Missile : Weapon
    {
        private int BaseDamage { get; set; } = 4;
        public override void WeaponAttack(EnemySpaceShip target , int rand)
        {
            if (rand <= 100)
            {
                Damage = BaseDamage;
            }
            else Damage = 0;
            Console.WriteLine("Use missile attack!");
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