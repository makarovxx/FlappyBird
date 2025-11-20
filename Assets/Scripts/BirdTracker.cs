using BirdComponents;
using UnityEngine;
using Zenject;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private float _offsetX;
    private Bird _bird;

    [Inject]
    public void Construct(Bird bird) => _bird = bird;

    private void Update() => transform.position = new Vector3(_bird.transform.position.x - _offsetX, transform.position.y, transform.position.z);
}