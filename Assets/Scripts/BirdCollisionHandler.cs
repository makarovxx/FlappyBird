using BirdComponents;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CircleCollider2D), typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ScoreZone _))
            _bird.IncreaseScore();
        else
            _bird.Die();
    }
}