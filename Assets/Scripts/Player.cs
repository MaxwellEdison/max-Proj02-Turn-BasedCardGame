using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour, ITargetable, IDamageable
{
    public int _maxHealth;
    public int _health;
    public int _startingDefense;
    public int _defense;
    public TextMeshProUGUI _hp;
    public TextMeshProUGUI _def;


    private void Awake()
    {
        _health = _maxHealth;
        _defense = _startingDefense;
    }
    public void Target()
    {
        Debug.Log("Player has been targeted.");
    }

    public void Update()
    {
        _hp.text = "Player HP: " + _health + "/" + _maxHealth;
        _def.text = "Player Defense: " + _defense;
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
