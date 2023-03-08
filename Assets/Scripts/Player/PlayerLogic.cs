using UnityEngine;
using UnityEngine.Events;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _maxHealth = 5;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

	private void Start()
	{
		HealthChanged?.Invoke(_health);
	}

	public void ApplyDamage(int damage)
    {
        if (damage < 0)
        {
            if (_health >= _maxHealth)
            {
                return;
            }
        }
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
