using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Armors;
public class LightArmor : IArmor
{
    private int _armorCondition = 100;
    public string Name => "Легкая броня";
    public int Armor => 10;
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
