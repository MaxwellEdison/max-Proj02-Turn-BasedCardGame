using UnityEngine;

public class Player : MonoBehaviour
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

}
