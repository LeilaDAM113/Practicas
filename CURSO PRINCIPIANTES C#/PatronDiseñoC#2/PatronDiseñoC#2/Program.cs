using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace PatronDiseñoC_2
{
    public class Program
    {
		public static void Main(string[] args)
        {
			// o hacer por ejemplo var punch = new Punch() y cambiandolo donde salga new Punch() y asi
			var ninja = new Warrior("Ninja", fight:new NunchakuStrike());
			var boxer = new Warrior("Boxer", fight:new Punch());
			var zombie = new Warrior("Zombie", fight:new Bite());
			var karateka = new Warrior("Karateka", fight:new Kick());
			var mazingerZ = new Warrior("Mazinger Z" , fight:new Punch());
			var warriors = new List<Warrior> { ninja, boxer, zombie, karateka, mazingerZ };
			Iterate(warriors);
			Console.WriteLine("### ZOMBIE APOCALYPSE ###");
			ninja.ChangeFight(new Bite());
			boxer.ChangeFight(new Bite());
			karateka.ChangeFight(new Bite());
			Iterate(warriors);

		}
		//no hay que tocar este método
		public static void Iterate(IEnumerable<Warrior> allWarriors)
		{
			foreach (var warrior in allWarriors)
			{
				Console.WriteLine($"A warrior {warrior.Name} shows up");
				warrior.Attack();
				Console.WriteLine();
			}
		}
		public interface IFight
		{
			void Fight();
		}

        public class Punch : IFight
        {
            public void Fight()
            {
				Console.WriteLine("Punch!");
			}
        }
		public class Kick : IFight
		{
			public void Fight()
			{
				Console.WriteLine("Kick!");
			}
		}
		public class NunchakuStrike : IFight
		{
			public void Fight()
			{
				Console.WriteLine("Nunchaku strike!");
			}
		}
		public class Bite : IFight
		{
			public void Fight()
			{
				Console.WriteLine("Bite!");
			}
		}
		public class Warrior
		{
			private IFight _fight;
			public  string Name { get; }

			public Warrior(string name, IFight fight)
			{
				Name = name;
				_fight= fight;
			}

			public void Attack()
			{
				_fight.Fight();
			}

			public void ChangeFight(IFight fight)
			{
				_fight = fight;
			}
	}
    }
}
