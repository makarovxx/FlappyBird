using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ScoreZone _))
            _bird.IncreaseScore();
        else
            _bird.Die();
    }
}