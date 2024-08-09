using Fighters.GameManager;
using Fighters.Services;

IGameManager gameManager = new GameManager( new FighterService() );
gameManager.Play();
