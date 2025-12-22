using _Project.Scripts.Gameplay.PipeSystem;
using UnityEngine;

namespace _Project.Scripts.InstallerConfigs
{
    [CreateAssetMenu(fileName = "FactoryConfig", menuName = "InstallerConfigs/FactoryConfig")]
    public class PipesFactoryConfig: ScriptableObject
    {
        [SerializeField] private Pipes _prefab;
        public Pipes Prefab => _prefab;
    }
}