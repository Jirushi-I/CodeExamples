using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] [FMODUnity.EventRef]
    private string _event;


    public void Play()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_event);
    }
}