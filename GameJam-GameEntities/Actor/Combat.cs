using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Combat : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Weapon[] weapons;
    private Vector2 _direction;

    public Vector2 Direction => _direction;

    public void Initiate()
    {
        weapon.InitiateAttack(this);
        
    }
    
    public void Toggle(InputAction.CallbackContext c)
    {
        if(c.ReadValueAsButton())
            Initiate();
            

        else
        {
            Release();
        }
    }
    
    public void Release()
    {
        weapon.ReleaseAttack(this);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    
    public void RandomWeapon()
    {
        this.weapon = weapons[Random.Range(0,weapons.Length)];
    }

    public void ChangeDirection(Vector2 direction)
    {

        _direction = direction;
        transform.DOLookAt(transform.position + new Vector3(_direction.x, 0, _direction.y), 0.3f);
    }
    
    public void ChangeDirection(InputAction.CallbackContext c)
    {
        if(Math.Abs(c.ReadValue<Vector2>().x) <= 5f && Math.Abs(c.ReadValue<Vector2>().y) <= 5f)
            return;
        ChangeDirection(c.ReadValue<Vector2>());
    }
}