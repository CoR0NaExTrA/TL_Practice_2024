namespace Fighters.Models.Armors;
public class HeavyArmor : IArmor
{
    private int _armorCondition = 100;
    public string Name => "Тяжелая броня";
    public int Armor => 30;
    public int ArmorCondition
    {
        get => _armorCondition;
        private set
        {
            if ( value < 0 )
            {
                _armorCondition = 0;
            }
            else
            {
                _armorCondition = value;
            }
        }
    }

    public void ReduceCondition( int amount )
    {
        ArmorCondition -= amount;
    }

    public void Repair()
    {
        ArmorCondition = 100;
    }
}
