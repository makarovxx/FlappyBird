using UnityEngine;

namespace _Project.Scripts.UI
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        
        protected void Show() => _panel.SetActive(true);
        
        protected void Hide() => _panel.SetActive(false);
        
    }
}