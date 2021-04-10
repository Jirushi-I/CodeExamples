using FMOD.Studio;
using UnityEngine;

public class PlayerLife : Life
{
    public static PlayerLife main; // Bad
    public LevelLoader _levelLoader;
    public EventInstance instance;


    void Awake() => main = this;
    public override void End()
    {
        _levelLoader.Load();
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Interactable interactable;
        if (hit.gameObject.TryGetComponent(out interactable))
        {
            interactable.Interact();
        }
    }

    public void SetRTPC(float value)  => instance.setParameterByName("Pitch", value);
}