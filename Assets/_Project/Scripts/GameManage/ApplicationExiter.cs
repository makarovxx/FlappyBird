using System;
using Zenject;

namespace _Project.Scripts.GameManage
{
    public class ApplicationExiter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public ApplicationExiter(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Exit()
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}