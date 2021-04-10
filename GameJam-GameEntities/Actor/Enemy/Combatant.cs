using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class Combatant : MonoBehaviour
{
    private Transform playerTransform;
    private Combat _movement;

    private bool dir;

    private void Awake()
    {
        _movement = GetComponent<Combat>();
        InvokeRepeating("Loop", 0.5f, 0.5f);
        _movement.RandomWeapon();
    }

    void Loop()
    {
        playerTransform = PlayerLife.main.transform;
        
        dir = Random.Range(0, 2) == 1;
        
    }

    private void Update()
    {
        transform.LookAt(playerTransform);
        _movement.ChangeDirection(new Vector2(transform.position.x, transform.position.z));
        if(dir)
            _movement.Initiate();
        else _movement.Release();
        
    }
}