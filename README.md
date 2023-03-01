# Exercicio 2: Fantasy Battle Simulator

Neste exercicio vamos criar um battle simulator que opoe 2 exercitos um contra o outro, numa batalha de proporcoes epicas!
Cada exercito e composto por uma variedade de criaturas com abilidades e caracteristicas unicas. 


## Instrucoes:

1. Cria uma class chamada FantasyCreature com as seguintes propriedades:
    * Name (string)
    * Health (int)
    * AttackPower (int)
    * Defense (int)
2. Cria varias subclasses de FantasyCreature, cada uma com atributos unicos. Alguns exemplos:
    * Dragon: Has a high attack power and health, can breathe fire
    * Elf: Has high agility and speed, can shoot arrows
    * Dwarf: Has high defense and health, can use a hammer
    * Orc: Has high attack power, can use a battle axe
    * Wizard: Has low health but high magic power, can cast spells

3. Cria uma class Army que contem uma `list<FantasyCreature>`. Esta class tem de implementar um metodo `Battle(Army A)`, que recebe como argumento outro obj do tipo `Army`, e calcula o vencedor da batalha utilizando logica algoritmica que tenha em conta as propriedades de cada criatura que compoe cada exercito.

4. Cria um programa que gere 2 exercitos, inicie uma batalha utilizando o metodo `Battle()`. Este programa deve de imprimir quem foi o vencedor. 

