using Fighters.Models.Armors;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Fighter : IFighter
{
    public IFighterClass FighterClass { get; }

    public IRace Race { get; }

    public IWeapon Weapon { get; }

    public IArmor Armor { get; }

    public string Name { get; }

    public int CurrentHealth { get; private set; }

    public int ArmorPoints { get; private set; }

    public int MaxHealth { get; }

    public int Strength => Race.Strength + FighterClass.Strength + Weapon.Damage;

    public bool IsAlive => CurrentHealth > 0;

    public Fighter(
        string name,
        IFighterClass fighterClass,
        IRace race,
        IWeapon weapon,
        IArmor armor )
    {
        Name = name;
        FighterClass = fighterClass;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        MaxHealth = Race.Health + FighterClass.Health;
        CurrentHealth = MaxHealth;
        ArmorPoints = Race.Armor + Armor.Armor;
    }

    public int CalculateDamage()
    {
        const double MinMultiplierDamage = 0.75;
        const double MaxMultiplierDamage = 1.25;
        const int CritPercentChance = 20;

        double attackMultiplier = ( double )Random.Shared.Next( ( int )( MinMultiplierDamage * 100 ), ( int )( MaxMultiplierDamage * 100 + 1 ) ) / 100;
        int fighterDamage = ( int )( Strength * attackMultiplier );

        bool isCritAttack = CritPercentChance > 100 || Random.Shared.Next( 1, 101 ) < CritPercentChance;

        if ( isCritAttack )
        {
            fighterDamage *= 2;
        }

        return fighterDamage;
    }

    public int TakeDamage( int opponentDamage )
    {
        const double ArmorReduction = 0.5;
        const int MinArmorConditionLoss = 5;

        int startHealth = CurrentHealth;
        double armorConditionPercent = ( double )Armor.ArmorCondition / 100;
        int newHealth = CurrentHealth - ( int )Math.Max( opponentDamage - ArmorPoints * armorConditionPercent, 0 );

        Armor.ReduceCondition( ( int )Math.Max( opponentDamage * armorConditionPercent, MinArmorConditionLoss ) );

        if (newHealth < 0)
        {
            newHealth = 0;
        }

        CurrentHealth = newHealth;
        int damageDealt = startHealth - CurrentHealth;

        return damageDealt;
    }

    public void Revive()
    {
        CurrentHealth = MaxHealth;
        Armor.Repair();
    }

    public override string ToString()
    {
        return $"Боец {Name}: \n" +
            $"Класс: {FighterClass.Name} \n" +
            $"Раса: {Race.Name} \n" +
            $"Оружие: {Weapon.Name} \n" +
            $"Броня: {Armor.Name} \n" +
            $"Максимальное здоровье: {MaxHealth} \n" +
            $"Текущее здоровье: {CurrentHealth} \n" +
            $"Количество брони: {ArmorPoints} \n" +
            $"Состояние брони: {Armor.ArmorCondition} \n" +
            $"Сила: {Strength} \n" +
            $"Состояние здоровья: {( IsAlive ? "Жив" : "Мертв" )}";
    }
}
