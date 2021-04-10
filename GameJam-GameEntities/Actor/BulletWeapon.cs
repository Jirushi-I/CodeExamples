using UnityEngine;
using UnityEngine.Events;

public class BulletWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float delay; 
    private float _currentDelay;
    [SerializeField] private float _maxMultiply;
    private float _multipier;
    public UnityEvent OnAttack;
    public UnityEvent OnCharge;

    public override void InitiateAttack(Combat combat)
    {
        _multipier = 1f;
    }

    public override void ReleaseAttack(Combat combat)
    {
        if(_currentDelay < delay)
            return;
        _currentDelay = 0;
        
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.ChangeDirection(combat.Direction);
        bullet.Multiplier = _multipier;
        OnAttack?.Invoke();
        if(_maxMultiply <= _multipier)
    OnCharge?.Invoke();
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if(_multipier < _maxMultiply)
            _multipier += Time.deltaTime/delay*1.1f;
    }
}