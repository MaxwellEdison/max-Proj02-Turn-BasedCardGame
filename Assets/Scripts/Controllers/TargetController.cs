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
    public void TargetPlayer()
    {
        ITargetable possibleTarget = _playerTarget.GetComponent<ITargetable>();
        if(possibleTarget != null)
        {
            Debug.Log("Targeting Player!");
            CurrentTarget = possibleTarget;
            _playerTarget.Target();
        }
    }
    public void TargetEnemy()
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
