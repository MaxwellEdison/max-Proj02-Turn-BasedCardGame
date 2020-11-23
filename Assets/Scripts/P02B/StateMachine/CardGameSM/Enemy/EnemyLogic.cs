using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int _currentHealth;
    public int _idealHealth;
    public int _playerHealth;
    public int _pHealthPrio;
    public int _currentDefense;
    public int _idealDefense;
    public EnemyDeck _eDeck;
    int _d10;
    //public static EnemyLogic _enemyThink;

    public void StartThinking()
    {

        Player _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Creature _creature = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Creature>();
        _eDeck = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyDeck>();

        _playerHealth = _player._health;
        _currentHealth = _creature._currentHealth;
        _idealHealth = _creature._idealHealth;
        _currentDefense = _creature._currentDefense;
        Choose();
    }
    public void Choose()
    {

        Debug.Log("Enemy Choosing");
        Random.InitState(Mathf.RoundToInt((Time.deltaTime)*1000)+GameObject.Find("StateController").GetComponent<PlayerTurnCardGameState>()._playerTurnCount);
        _d10 = Random.Range(1, 10);
        Debug.Log("rolled a " + _d10);
        if (_currentHealth < _idealHealth)
        {
            Debug.Log("Enemy Might Heal...");
            if (_d10 >= 9)
            {
                Debug.Log("Decided not to heal...");
                NoHPChoice();
            } else
            {
                Heal();
            }

        } 
        else if(_currentDefense < _idealDefense)
        {
            Debug.Log("Enemy Might Defend...");
            if (_d10 >= 9)
            {
                Debug.Log("Decided not to defend...");
                NoDefChoice();
            } else
            {
                Defend();
            }

        } 
        else if (_currentHealth >= _idealHealth && _currentDefense >= _idealDefense)
        {
            Debug.Log("Enemy Might Attack...");
            if (_d10 >= 9)
            {
                Debug.Log("Decided not to attack...");
                NoAtkChoice();
            } else
            {
                Attack();
            }

        }
    }
    public void NoHPChoice()
    {
        int _coinFlip = Random.Range(1, 2);
        if (_coinFlip == 1)
        {
            Attack();
        }
        else
        {
            Defend();
        }
    }
    public void NoDefChoice()
    {
        int _coinFlip = Random.Range(1, 2);
        if(_coinFlip == 1)
        {
            Attack();
        } else
        {
            Heal();
        }
    }
    public void NoAtkChoice()
    {
        int _coinFlip = Random.Range(1, 2);
        if (_coinFlip == 1)
        {
            Defend();
        }
        else
        {
            Heal();
        }
    }
    public void Heal()
    {
        Debug.Log("I healed!");
        EndLogic();
    }

    public void Defend()
    {
        Debug.Log("I defended!");
        EndLogic();
    }

    public void Attack()
    {
        Debug.Log("I attacked!");
        EndLogic();
    }

    public void EndLogic()
    {
        if(_eDeck._enemyHand.Count < _eDeck._maxCards)
        {
            _eDeck.Draw();
        } else
        {
            return;
        }
    }

}
