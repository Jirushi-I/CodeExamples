using UnityEngine;

public class StrafeMover : MonoBehaviour
{
    private Transform playerTransform;
    private Movement _movement;

    private bool dir;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        InvokeRepeating("Loop", 1, 1);
    }

    void Loop()
    {
        playerTransform = PlayerLife.main.transform;


        dir = Random.Range(0, 2) == 1;

    }

    private void Update()
    {
        _movement.Move(Vector2.Perpendicular(new Vector2(playerTransform.position.x, playerTransform.position.z))*(dir?-1:1));
    }
}