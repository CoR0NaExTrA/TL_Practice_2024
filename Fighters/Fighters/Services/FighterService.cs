using Fighters.Models.Armors;
using Fighters.Models.FighterClass;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;


namespace Fighters.Services;
public class FighterService : IFighterService
{
    private readonly List<IFighter> _fighters = new List<IFighter>();

    public IFighter CreateFighter()
    {
        string name = NotAnEmptyString( "Введите имя бойца: " );
        IFighterClass fighterClass = GetFighterClass();
        IRace race = GetRace();
        IWeapon weapon = GetWeapon();
        IArmor armor = GetArmor();
        IFighter fighter = new Fighter( name, fighterClass, race, weapon, armor );

        _fighters.Add( fighter );

        return fighter;
    }

    public List<IFighter> GetFighters() => _fighters.ToList();

    private IFighterClass GetFighterClass()
    {
        bool ValidChoice = false;
        IFighterClass fighterClass = null;
        while ( !ValidChoice )
        {
            ValidChoice = true;
            string message = "Выберите класс бойца(номер): \n" +
                                "Рыцарь; \n" +
                                "Паладин; \n" +
                                "Воин; \n" +
                                "Варвар; \n" +
                                "Ввод: ";
            switch ( NotAnEmptyString( message ) )
            {
                case "Рыцарь":
                    fighterClass = new Knight();
                    break;
                case "Паладин":
                    fighterClass = new Paladin();
                    break;
                case "Воин":
                    fighterClass = new Warrior();
                    break;
                case "Варвар":
                    fighterClass = new Barbarian();
                    break;
                default:
                    Console.WriteLine("Такого класса нет. Попробуйте снова.");
                    ValidChoice = false;
                    break;
            }
        }

        return fighterClass;
    }

    private IRace GetRace()
    {
        bool ValidChoice = false;
        IRace race = null;
        while ( !ValidChoice )
        {
            ValidChoice = true;
            string message = "Выберите расу бойца(номер): \n" +
                                "Человек; \n" +
                                "Эльф; \n" +
                                "Гном; \n" +
                                "Драконорожденный; \n" +
                                "Ввод: ";
            switch ( NotAnEmptyString( message ) )
            {
                case "Человек":
                    race = new Human();
                    break;
                case "Эльф":
                    race = new Elf();
                    break;
                case "Гном":
                    race = new Dwarf();
                    break;
                case "Драконорожденный":
                    race = new Dragonborn();
                    break;
                default:
                    Console.WriteLine( "Такой расы нет. Попробуйте снова." );
                    ValidChoice = false;
                    break;
            }
        }

        return race;
    }


    private IWeapon GetWeapon()
    {
        bool ValidChoice = false;
        IWeapon weapon = null;
        while ( !ValidChoice )
        {
            ValidChoice = true;
            string message = "Выберите оружие бойца(номер): \n" +
                                "Кулаки; \n" +
                                "Меч; \n" +
                                "Кинжал; \n" +
                                "Топор; \n" +
                                "Арбалет; \n" +
                                "Ввод: ";
            switch ( NotAnEmptyString( message ) )
            {
                case "Кулаки":
                    weapon = new NoWeapon();
                    break;
                case "Меч":
                    weapon = new Sword();
                    break;
                case "Кинжал":
                    weapon = new Dagger();
                    break;
                case "Топор":
                    weapon = new Axe();
                    break;
                case "Арбалет":
                    weapon = new Crossbow();
                    break;
                default:
                    Console.WriteLine( "Такого оружия нет. Попробуйте снова." );
                    ValidChoice = false;
                    break;
            }
        }

        return weapon;
    }

    private IArmor GetArmor()
    {
        bool ValidChoice = false;
        IArmor armor = null;
        while ( !ValidChoice )
        {
            ValidChoice = true;
            string message = "Выберите броню бойца(номер): \n" +
                                "Без брони; \n" +
                                "Легкая броня; \n" +
                                "Обычная броня; \n" +
                                "Тяжелая броня; \n" +
                                "Ввод: ";
            switch ( NotAnEmptyString( message ) )
            {
                case "Без брони":
                    armor = new NoArmor();
                    break;
                case "Легкая броня":
                    armor = new LightArmor();
                    break;
                case "Обычная броня":
                    armor = new OrdinaryArmor();
                    break;
                case "Тяжелая броня":
                    armor = new HeavyArmor();
                    break;
                default:
                    Console.WriteLine( "Такой брони нет. Попробуйте снова." );
                    ValidChoice = false;
                    break;
            }
        }

        return armor;
    }

    private string NotAnEmptyString( string message, string error = "Неверный ввод. Эта строка не может быть пустой. Попробуйте еще раз.")
    {
        string input = string.Empty;

        while (true)
        {
            Console.Write( message );
            input = Console.ReadLine();
            if ( !string.IsNullOrEmpty( input ) )
            {
                break;
            }

            Console.WriteLine( error );
        }

        return input;
    }

    public void ReviveFighters()
    {
        foreach (IFighter fighter in _fighters)
        {
            fighter.Revive();
        }
    }
}
