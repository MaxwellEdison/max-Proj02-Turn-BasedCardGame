using UnityEngine;
using TMPro;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    public int _currentHealth;
    public int _idealHealth;
    public int _maxHealth = 100;
    public int _currentDefense = 0;
    public int _idealDefense = 5;
    public TextMeshProUGUI _hp;
    public TextMeshProUGUI _def;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _idealHealth = (2 * _maxHealth) / 3;
    }

    private void Update()
    {
        _hp.text = "Enemy HP: " + _currentHealth + "/" + _maxHealth;
        _def.text = "Enemy Defense: " + _currentDefense;
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
