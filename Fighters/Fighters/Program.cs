using Fighters.Manager;
using Fighters.Services;

namespace Fighters;

internal class Program
{
    static void Main()
    {
        IGameManager gameManager = new GameManager( new FighterService() );
        gameManager.Play();
    }
}