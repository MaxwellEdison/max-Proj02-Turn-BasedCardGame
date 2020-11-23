using UnityEngine;
using UnityEngine.Events;
using System;

public class TargetController : MonoBehaviour
{
    //TODO build a more structured connection
    public static ITargetable CurrentTarget;
    //interfaces don't serialize, so we need a class reference
    [SerializeField] Creature _enemyTarget = null;
    [SerializeField] Player _playerTarget = null;
    public EnemyTurnCardGameState _enemyState = null;
    public PlayerTurnCardGameState _playerState = null;
    UnityEvent e_targetPlayer = new UnityEvent();
    UnityEvent e_targetEnemy = new UnityEvent();

    private void Awake()
    {
        e_targetPlayer.AddListener(TargetPlayer);
        e_targetEnemy.AddListener(TargetEnemy);
        //_playerTurn..AddListener(TargetEnemy);
        //EnemyTurnEnded?.Invoke();
    }

/*    private void Update()
    {
        //target the object when '1' is pressed
        if (_statM.CurrentState == State.)
        {
            //target the object, if it is targetable
            ITargetable possibleTarget = _enemyTarget.GetComponent<ITargetable>();
            if(possibleTarget!= null)
            {
                Debug.Log("new target aquired!");
                CurrentTarget = possibleTarget;
                _enemyTarget.Target();
            }
        }
    }*/
    private void TargetPlayer()
    {
        ITargetable possibleTarget = _playerTarget.GetComponent<ITargetable>();
        if(possibleTarget != null)
        {
            Debug.Log("Targeting Player!");
            CurrentTarget = possibleTarget;
            _playerTarget.Target();
        }
    }
    private void TargetEnemy()
    {
        ITargetable possibleTarget = _enemyTarget.GetComponent<ITargetable>();
        if (possibleTarget != null)
        {
            Debug.Log("Targeting Player!");
            CurrentTarget = possibleTarget;
            _enemyTarget.Target();
        }
    }
}
