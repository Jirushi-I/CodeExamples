using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Life))]
public class Bullet : MonoBehaviour
{
    private Movement _movement;
    private Vector2 _direction;
    [SerializeField] private float velocity;
    [SerializeField] private float damage;
    private Life _bulletLife;
    private float _delay; 

    public Vector2 Direction  => _direction;
    public float Multiplier { get; set; }

    private void Awake()
    {
        _bulletLife = GetComponent<Life>();
        _movement = GetComponent<Movement>();
        _movement.Jump(velocity);
    }

    public void ChangeDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    void FixedUpdate()
    {
        _delay += Time.fixedDeltaTime;
        _movement.Move(_direction);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(_delay < 0.1f)
            return;
        _delay = 0;

        Health health;
        if (hit.gameObject.TryGetComponent<Health>(out health))
        {
            health.Damage(damage*Multiplier);
        }
        
        _bulletLife.End(hit);
    }
}