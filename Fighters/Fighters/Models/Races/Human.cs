﻿namespace Fighters.Models.Races;
public class Human : IRace
{
    public string Name => "Человек";
    public int Health => 30;
    public int Strength => 10;
    public int Armor => 1;
}
