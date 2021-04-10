using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;

    public UnityEvent<float> HealthChangeValue;
    public UnityEvent HealthChange;
    public UnityEvent Death;
    private float _health;
    private double _delay;

    void Awake()
    {
        _health = startHealth;
    }

    private void Update()
    {
        
        _delay += Time.deltaTime;
    }

    public void Damage(float amount)
    {
        if(_delay < 0.1f)
            return;
        _delay = 0;
        
        _health -= amount;
        HealthChangeValue?.Invoke(_health/startHealth);
        HealthChange?.Invoke();

        if (!(_health <= 0)) return;

        _health = startHealth;
        Death?.Invoke();
        GetComponent<Life>().End(null);
    }
}