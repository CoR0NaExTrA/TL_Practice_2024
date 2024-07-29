using Fighters.Models.Fighters;
using Fighters.Services;

namespace Fighters.Manager;
public class GameManager : IGameManager
{
    private readonly IFighterService _fighterService;

    public GameManager( IFighterService fighterService )
    {
        _fighterService = fighterService;
    }

    public void Play()
    {
        Console.WriteLine( "Игра 'Fighters'" );

        bool exit = false;

        while ( !exit )
        {
            Menu();
            string command = Console.ReadLine();
            switch ( command )
            {
                case "add fighter":
                    AddFighter();
                    break;
                case "fight":
                    Fight();
                    break;
                case "fighters":
                    AllFighters();
                    break;
                case "revive all":
                    ReviveFighters();
                    break;
                case "exit":
                    Console.WriteLine( "Спасибо за игру" );
                    exit = true;
                    break;
                default:
                    Console.WriteLine( $"Команды '{command}' нет в списке." );
                    break;
            }
        }
    }

    private void Menu()
    {
        Console.Write( " \n Команды: \n" +
                         "add fighter - Добавление бойца в игру; \n" +
                         "fight - Сражение; \n" +
                         "fighters - Список бойцов; \n" +
                         "revive all - Оживить всех бойцов; \n" +
                         "exit - Выход из игры; \n" +
                         "Введите команду: " );
    }

    private void AddFighter()
    {
        IFighter fighter = _fighterService.CreateFighter();
        Console.WriteLine( $"Боец {fighter.Name} создан." );
    }

    private void Fight()
    {
        int round = 0;
        List<IFighter> fighters = _fighterService.GetFighters();
        int fightersSum = fighters.Count;
        if ( fightersSum < 2 )
        {
            CountError(fightersSum);
            return;
        }

        Console.WriteLine( "Бой!" );

        while ( fighters.Count( f => f.IsAlive ) > 1 )
        {
            Console.WriteLine( $"Раунд {++round}" );

            fighters = fighters.OrderBy( f => Random.Shared.Next() ).ToList();

            foreach ( IFighter fighter in fighters )
            {
                if ( !fighter.IsAlive )
                {
                    continue;
                }

                IFighter opponent = fighters.Where( f => f != fighter && f.IsAlive ).OrderBy( f => Random.Shared.Next() ).First();
                Attack( fighter, opponent );
            }

            ContinueKeyPress();

            AllFighters( "Текущее состояние бойцов:" );

            ContinueKeyPress();

        }

        IFighter winner = fighters.FirstOrDefault( f => f.IsAlive );

        Console.WriteLine( $"Победитель - {winner.Name}" );
    }

    private void AllFighters( string message = "Список бойцов:" )
    {
        List<IFighter> fighters = _fighterService.GetFighters();

        if ( fighters.Count == 0 )
        {
            Console.WriteLine( "Список пуст." );
            return;
        }

        Console.WriteLine( message + "\n" );
        foreach ( IFighter fighter in fighters )
        {
            Console.WriteLine( fighter + "\n" );
        }
    }

    private void ReviveFighters()
    {
        _fighterService.ReviveFighters();
        Console.WriteLine( "Все бойцы снова готовы к бою." );
    }

    private void Attack( IFighter fighter, IFighter opponent )
    {
        int damage = fighter.CalculateDamage();
        int damageTaken = opponent.TakeDamage( damage );
        Console.WriteLine( $"{fighter.Name} атакует {opponent.Name} с силой {damage}" );
        if ( damageTaken < damage )
        {
            Console.WriteLine( $"{opponent.Name} блокирует атаку и {( opponent.IsAlive ? "выживает" : "погибает" )}, получая {damageTaken}" );
        }
        else
        {
            Console.WriteLine( $"{opponent.Name} получает {damageTaken} урона и {( opponent.IsAlive ? "выживает" : "погибает" )}" );
        }
    }

    private void ContinueKeyPress()
    {
        Console.WriteLine( "Нажмите Enter, чтобы продолжить \n" );
        Console.ReadKey();
    }

    private void CountError( int fighterSum )
    {
        Console.WriteLine("Невозможно начать сражение \n" +
                          "Минимальное количество бойцов для начала сражения: 2 \n" +
                          $"Текущее кол-во бойцов: {fighterSum} \n" +
                          $"Добавьте ещё {2 - fighterSum} бойца/бойцов");

    }
}
