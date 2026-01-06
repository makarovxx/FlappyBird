// using _Project.Scripts.Signals;
// using Zenject;
// using Zenject.Asteroids;
//
// namespace _Project.Scripts.GameManage
// {
//     public sealed class GameManager
//     {
//         private readonly SignalBus _signalBus;
//
//         public GameManager(SignalBus signalBus)
//         {
//             _signalBus = signalBus;
//         }
//
//         public GameState State { get; private set; }
//
//          public void StartGame()
//          {
//              if(State != GameState.Off)
//                  return;
//              
//              _signalBus.Fire<GameStartSignal>();
//          }
//
//          public void PauseGame()
//          {
//              if(State != GameState.Playing)
//                  return;
//              
//              _signalBus.Fire<>();
//          }
//     }
//     
//      
// }