// Define the fantasy creature class
public abstract class FantasyCreature {
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public abstract int SpecialAttributePower { get; }
    public abstract int SpecialAttributeChance { get; }
    public virtual int CalculateDamage(FantasyCreature defender, bool useSpecialAttribute) => 
        AttackPower + (useSpecialAttribute ? SpecialAttributePower : 0) - defender.Defense;
}

// Define a subclass for a dragon
public class Dragon : FantasyCreature {
    public int FireBreathPower { get; set; }
    public override int SpecialAttributePower => FireBreathPower;
    public override int SpecialAttributeChance => 20;
}

// Define a subclass for an elf
public class Elf : FantasyCreature {
    public int Agility { get; set; }
    public int Speed { get; set; }
    public int ArrowPower { get; set; }
    public override int SpecialAttributePower => ArrowPower;
    public override int SpecialAttributeChance => 25;
}

// Define a subclass for a dwarf
public class Dwarf : FantasyCreature {
    public int HammerPower { get; set; }
    public override int SpecialAttributePower => HammerPower;
    public override int SpecialAttributeChance => 30;
}

// Define a subclass for an orc
public class Orc : FantasyCreature {
    public int AxePower { get; set; }
    public override int SpecialAttributePower => AxePower;
    public override int SpecialAttributeChance => 35;
}

// Define a subclass for a wizard
public class Wizard : FantasyCreature {
    public int MagicPower { get; set; }
    public override int SpecialAttributePower => MagicPower;
    public override int SpecialAttributeChance => 40;
}

// Define the army class
public class Army {
    public List<FantasyCreature> Creatures { get; set; }
    public string ArmyName { get; set; }

    // Define a method for resolving a battle between two armies
    public Army Battle(Army other) {
        // Calculate the total score for each army
        int thisArmyScore = Creatures.Sum(c => c.Health + c.AttackPower + c.Defense);
        int otherArmyScore = other.Creatures.Sum(c => c.Health + c.AttackPower + c.Defense);

        // Determine which army goes first (the army with the higher score goes first)
        bool thisArmyFirst = thisArmyScore >= otherArmyScore;

        // Initialize variables for tracking which army is currently attacking and defending
        Army attackingArmy = thisArmyFirst ? this : other;
        Army defendingArmy = thisArmyFirst ? other : this;

        int turnCount = 1;
        // While there are creatures still alive in both armies, continue the battle
        while (attackingArmy.Creatures.Count > 0 && defendingArmy.Creatures.Count > 0) {
            // Select a random creature from the attacking army and a random creature from the defending army
            int attackingCreatureIndex = new Random().Next(attackingArmy.Creatures.Count);
            int defendingCreatureIndex = new Random().Next(defendingArmy.Creatures.Count);
            FantasyCreature attackingCreature = attackingArmy.Creatures[attackingCreatureIndex];
            FantasyCreature defendingCreature = defendingArmy.Creatures[defendingCreatureIndex];

            // Determine if the attacking creature will use its unique attribute
            bool useSpecialAttribute = new Random().Next(101) <= attackingCreature.SpecialAttributeChance;

            // Calculate the damage dealt by the attacking creature
            int damage = attackingCreature.CalculateDamage(defendingCreature, useSpecialAttribute);

            // Reduce the defending creature's health by the damage dealt
            defendingCreature.Health -= damage;

            // If the defending creature's health falls below zero, remove it from the defending army's list of creatures
            if (defendingCreature.Health <= 0) {
                defendingArmy.Creatures.RemoveAt(defendingCreatureIndex);
            }

            //Print the turn to the console
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Turn {turnCount++}");
            Console.WriteLine($"{attackingArmy.ArmyName} attacks {defendingArmy.ArmyName}!");
            Console.WriteLine($"{attackingCreature.Name} uses {(useSpecialAttribute ? $"Special attack" : "Normal attack")} and deals {damage} damage to {defendingCreature.Name}!");
            Console.WriteLine($"{attackingArmy.ArmyName} has {attackingArmy.Creatures.Count} creatures left.");
            Console.WriteLine($"{defendingArmy.ArmyName} has {defendingArmy.Creatures.Count} creatures left.");

            // Switch the attacking and defending armies for the next round of combat
            Army temp = attackingArmy;
            attackingArmy = defendingArmy;
            defendingArmy = temp;
        }

        // Return the winner of the battle based on which army has creatures remaining
        return attackingArmy.Creatures.Count > 0 ? attackingArmy : defendingArmy;
    }
}
class Program {
    static void Main(string[] args) {
        // Create two armies of fantasy creatures
        Army army1 = new Army {
            ArmyName = "Army 1",
            Creatures = new List<FantasyCreature> {
                new Dragon { Name = "Smaug", Health = 500, AttackPower = 150, Defense = 50, FireBreathPower = 500 },
                new Elf { Name = "Legolas", Health = 200, AttackPower = 100, Defense = 20, Agility = 200, Speed = 150, ArrowPower = 150 },
                new Dwarf { Name = "Gimli", Health = 300, AttackPower = 120, Defense = 40, HammerPower = 180 },
                new Orc { Name = "Grommash", Health = 250, AttackPower = 110, Defense = 30, AxePower = 170 },
                new Wizard { Name = "Gandalf", Health = 350, AttackPower = 130, Defense = 50, MagicPower = 220 }
            }
        };

        Army army2 = new Army {
            ArmyName = "Army 2",
            Creatures = new List<FantasyCreature> {
                new Dragon { Name = "Drogon", Health = 500, AttackPower = 150, Defense = 50, FireBreathPower = 500 },
                new Elf { Name = "Arwen", Health = 200, AttackPower = 100, Defense = 20, Agility = 200, Speed = 150, ArrowPower = 150 },
                new Dwarf { Name = "Thorin", Health = 300, AttackPower = 120, Defense = 40, HammerPower = 180 },
                new Orc { Name = "Gul'dan", Health = 250, AttackPower = 110, Defense = 30, AxePower = 170 },
                new Wizard { Name = "Saruman", Health = 350, AttackPower = 130, Defense = 50, MagicPower = 220 }
            }
        };

        // Simulate a battle between the two armies
        Army winner = army1.Battle(army2);

        // Print the winner of the battle to the console
        Console.WriteLine($"The winner of the battle is {winner.ArmyName}!");
        foreach (var creature in winner.Creatures) {
        Console.WriteLine($"{creature.Name} has {creature.Health} health remaining.");
        }
        Console.ReadLine();
    }
}
