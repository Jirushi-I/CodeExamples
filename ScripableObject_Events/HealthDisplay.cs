using UnityEngine;

public class SimpleHealthDisplay : Refreshable
{
    private float maxWidth;
    [SerializeField] private FloatAsset health;
    [SerializeField] private FloatAsset maxHealth;
    
    private void Awake()
    {
        _movement = GetComponent<Health>();
    }

    private void OnEnable()
    {
	health.Register(this);
    }

    private void OnDisable()
    {
	health.Unregister(this);
    }

    private virtual void Refresh()
    {
        transform.DOScaleX(health.Get()*maxWidth/maxHealth.Get(), 0.25f);
    }
}