using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Bullet))]
public class BouncingBulletLife : Life
{
    [SerializeField] private int lives;
    private Bullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void Start()
    {
        lives = (int)(lives*_bullet.Multiplier);
    }

    public override void End(ControllerColliderHit hit)
    {
        if (lives == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            _bullet.ChangeDirection( new Vector2(Vector3.Reflect(_bullet.Direction, hit.normal).x, -Vector3.Reflect(_bullet.Direction, hit.normal).y));
            lives--;
        }
    }
}

