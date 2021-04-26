public enum SlotType
{
    None= 0,
    Stars, // give triple esper
    Cats, // give double esper
    Hearts, // Give life to player
    Dice, // Give 50/50 to double esper and give life or half esper and remove a life
    Bombs, // Take a life, lose 25% of esper
    Skulls, // Drop your lives to 1
    Swords, // 50/50 to lose a life or double esper
    Armors, // Add 2 Armor Points
    Bugs, // Minigame will end, machine dies temporarily
    Even, // break even returning cost of the spin
    Jackpot, // Pretty self explanitory, give 10x Esper
    MegaJackpot, // Give 100x Esper
    BloodySwords
}