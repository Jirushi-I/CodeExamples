using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void InitiateAttack(Combat combat);

    public abstract void ReleaseAttack(Combat combat);
} 