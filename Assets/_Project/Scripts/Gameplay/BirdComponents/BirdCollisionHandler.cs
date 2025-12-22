// using UnityEngine;
// using Zenject;
//
// namespace _Project.Scripts.Gameplay.BirdComponents
// {
//     public class BirdCollisionHandler : MonoBehaviour
//     {
//         private void OnTriggerEnter2D(Collider2D other)
//         {
//             if (other.TryGetComponent(out ScoreZone _))
//                 _bird.IncreaseScore();
//             else
//                 _bird.Die();
//         }
//     }
// }