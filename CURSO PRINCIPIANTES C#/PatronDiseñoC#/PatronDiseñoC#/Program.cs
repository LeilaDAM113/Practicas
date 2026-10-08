using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static PatronDiseñoC_.Program.Zombie;

namespace PatronDiseñoC_
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var ninja = new Ninja();
			var boxer = new Boxer();
			var zombie = new Zombie();
			var karateka = new Karateka();
			var mazingerZ = new MazingerZ();
			var warriors = new List<Warrior> { ninja, boxer, zombie, karateka, mazingerZ };
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
		public abstract class Warrior
		{
			public abstract string Name { get; }

			public abstract void Attack();
		}

		public class Ninja : Warrior
		{
			public override string Name => "Ninja";

			public override void Attack()
			{
				Console.WriteLine("Nunchaku strike!");
			}
		}
		public class Boxer : Warrior
		{
			public override string Name => "Boxer";

			public override void Attack()
			{
				Console.WriteLine("Punch!");

			}
		}
		public class Zombie : Warrior
		{
			public override string Name => "Zombie";

			public override void Attack()
			{
				Console.WriteLine("Bite!");

			}

			public class Karateka : Warrior
			{
				public override string Name => "Karateka";

				public override void Attack()
				{
					Console.WriteLine("Kick!");

				}
			}

            public class MazingerZ : Warrior
            {
                public override string Name => "Mazinger Z";

                public override void Attack()
                {
					Console.WriteLine("Punch!");
				}
            }


        }
	}
}
