using System;
using System.Collections;
using UnityEngine;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;
    public int _turnsToSkip = 0;
    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("enemy turn: enter");
        EnemyTurnBegan?.Invoke();
        if(_turnsToSkip >= 1)
        {
            EnemyTurnEnded?.Invoke();
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
          else
        {
            StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
        }

    }

    public override void Exit()
    {
        Debug.Log("Enemy turn: exit");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("enemy performs action");
        EnemyTurnEnded?.Invoke();
        //turn over, go back to player.
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }
}
