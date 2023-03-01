# Exercicio 2: Fantasy Battle Simulator

Neste exercicio vamos criar um battle simulator que opoe 2 exercitos um contra o outro, numa batalha de proporcoes epicas!
Cada exercito e composto por uma variedade de criaturas com abilidades e caracteristicas unicas. 


## Instrucoes:

    1. Create a base class called FantasyCreature with the following properties:
        * Name (string)
        * Health (int)
        * AttackPower (int)
        * Defense (int)

    2. Create several subclasses of the FantasyCreature class, each with unique abilities and attributes. Some examples include:
        * Dragon: Has a high attack power and health, can breathe fire
        * Elf: Has high agility and speed, can shoot arrows
        * Dwarf: Has high defense and health, can use a hammer
        * Orc: Has high attack power, can use a battle axe
        * Wizard: Has low health but high magic power, can cast spells

    3. Create an Army class that contains a list of FantasyCreature objects. The Army class should have a method called Battle that takes another Army object as input and returns the winner based on algorithmic logic that considers the attributes and abilities of each creature in the armies.

    4. Create a program that creates two armies, populates them with various FantasyCreature objects, and then initiates a battle using the Battle method from the Army class. The program should display the winner of the battle and the remaining health of each creature.
