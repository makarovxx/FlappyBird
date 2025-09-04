using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer))]
public class BirdMover : MonoBehaviour
{
   [SerializeField] private Vector3 _startPosition;
   [SerializeField] private float _speed;
   [SerializeField] private float _tapForce;
   [SerializeField] private float _rotationSpeed;
   [SerializeField] private float _maxRotationZ;
   [SerializeField] private float _minRotationZ;
   
   private Rigidbody2D _rb;
   private Quaternion _maxRotation;
   private Quaternion _minRotation;

   private void Start()
   {
      transform.position = _startPosition;
      _rb = GetComponent<Rigidbody2D>();
      _rb.velocity = Vector2.zero;
      
      _maxRotation = Quaternion.Euler(0f, 0f, _maxRotationZ);
      _minRotation = Quaternion.Euler(0f, 0f, _minRotationZ);
      
      ResetBird();
   }
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         _rb.velocity = new Vector2(_speed, 0);
         transform.rotation = _maxRotation;
         _rb.AddForce(_tapForce * Vector3.up, ForceMode2D.Force);
      }
      
      transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
   }

   public void ResetBird()
   {
      transform.position = _startPosition;
      transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      _rb.velocity = Vector2.zero;
   }
}
