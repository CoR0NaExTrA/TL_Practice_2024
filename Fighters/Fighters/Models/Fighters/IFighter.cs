using Fighters.Models.Armors;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public interface IFighter
{
    IFighterClass FighterClass { get; }
    IRace Race { get; }
    IWeapon Weapon { get; }
    IArmor Armor { get; }
    string Name { get; }
    int CurrentHealth { get; }
    int MaxHealth { get; }
    bool IsAlive { get; }
    int Strength { get; }
    int TakeDamage( int damage );
    int CalculateDamage();
    void Revive();
}
