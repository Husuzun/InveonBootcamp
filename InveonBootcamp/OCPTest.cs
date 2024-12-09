using InveonBootcamp.OCP;
using System.Reflection.Emit;

namespace InveonBootcamp
{
    public class OCPTest
    {
        public static void Run()
        {
            Console.WriteLine("\nOCP \n");
            
            OldCharacter player = new OldCharacter { Type = "Human", Strength = 5, Level = 10 };
            OldCharacter enemy = new OldCharacter { Type = "Goblin", Strength = 10, Level = 4 };
            OldDamageCalculator calculator = new OldDamageCalculator();
            Console.WriteLine("Human damage: " + calculator.CalculateDamage(player));
            Console.WriteLine("Goblin damage: " + calculator.CalculateDamage(enemy));

            var human = new Human { Strength = 5, Level = 10 };
            var goblin = new Goblin { Strength = 10, Level = 4 };
            var dragon = new Dragon { Strength = 15, Level = 2 };

            var HumanDamage = DamageCalculator.CalculateDamageDelegate(human.Strength, human.Level, HumanDamageCalculate);
            var GoblinDamage = DamageCalculator.CalculateDamageDelegate(goblin.Strength, goblin.Level, GoblinDamageCalculate);
            var DragonDamage = DamageCalculator.CalculateDamageDelegate(dragon.Strength, dragon.Level, DragonDamageCalculate);

            Console.WriteLine($"Human damage: {HumanDamage}");
            Console.WriteLine($"Goblin damage: {GoblinDamage}");
            Console.WriteLine($"Dragon damage: {DragonDamage}");
        }

        public static decimal HumanDamageCalculate(int strength, int level)
        {
            return strength * level;
        }

        public static decimal GoblinDamageCalculate(int strength, int level)
        {
            return (decimal)(strength * level / 2);
        }

        public static decimal DragonDamageCalculate(int strength, int level)
        {
            return (decimal)(strength * level * 1.5);
        }
    }
} 