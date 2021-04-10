using UnityEngine;

public class Life : MonoBehaviour
{
    public virtual void End()
    {
        Destroy(gameObject);
    }
}