using UnityEngine;

public class Player : MonoBehaviour, ITargetable, IDamageable
{
    public int _startingHealth;
    public int _health;
    public int _startingDefense;
    public int _defense;

    private void Awake()
    {
        _health = _startingHealth;
        _defense = _startingDefense;
    }
    public void Target()
    {
        Debug.Log("Player has been targeted.");
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log("Player took damage. remaining health: " + _health);
        if (_health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Debug.Log("Player Lost");
    }
}
