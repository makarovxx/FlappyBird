using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Panel : MonoBehaviour
    {
        [FormerlySerializedAs("_canvasGroup")] [SerializeField] private GameObject _panel;
        
        protected void Show() => _panel.SetActive(true);
        
        protected void Hide() => _panel.SetActive(false);
        
    }
}