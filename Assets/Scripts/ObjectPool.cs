using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    
    private Camera _camera;

    private List<GameObject> _pool = new();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            
            _pool.Add(spawned);
        }
    }

    protected void DisableObjectsAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f));
        foreach (var item in _pool)
        {
            if (item.activeSelf)
            {
                if(item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
            }
        }
    }
    
    protected bool TryGetObject(out GameObject obj)
    {
        obj = _pool.FirstOrDefault(p => p.activeSelf == false);
        
        return obj;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
