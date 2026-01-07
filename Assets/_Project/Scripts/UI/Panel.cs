using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Panel : MonoBehaviour
    {
        // private const int OffValue = 0;
        // private const int OnValue = 1;
        //
        // [SerializeField] private CanvasGroup _canvasGroup;
        //
        // protected void Show() => _canvasGroup.alpha = OffValue;
        //
        // protected void Hide() => _canvasGroup.alpha = OnValue;
        
        // private const int OffValue = 0;
        // private const int OnValue = 1;
        //
        [FormerlySerializedAs("_canvasGroup")] [SerializeField] private GameObject _panel;
        
        protected void Show() => _panel.SetActive(true);
        
        protected void Hide() => _panel.SetActive(false);
        
    }
}