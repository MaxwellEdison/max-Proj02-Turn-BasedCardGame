using UnityEngine;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    public int _currentHealth;
    public int _idealHealth;
    public int _startingHealth = 100;
    public int _currentDefense = 0;
    public int _idealDefense = 5;

    private void Awake()
    {
        _currentHealth = _startingHealth;
        _idealHealth = (2 * _startingHealth) / 3;
    }
    public void Kill()
    {
        Debug.Log("Kill the creature");
        gameObject.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Took damage. remaining health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Target()
    {
        Debug.Log("Creature has been targeted.");
    }
}
