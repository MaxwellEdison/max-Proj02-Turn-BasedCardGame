﻿using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;
    public static event Action e_targetPlayer;
    public int _turnsToSkip = 0;
    [SerializeField] float _pauseDuration = 5f;
    public EnemyLogic _enemyThink;



    public override void Enter()
    {
        Debug.Log("enemy turn: enter");
        EnemyTurnBegan?.Invoke();
        e_targetPlayer?.Invoke();
        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
        /*        if (_turnsToSkip >= 1)
                {
        Debug.Log("Skipping enemy state");
                Debug.Log("pretending to skip this many enemy states: " + _turnSkip);
        EnemyTurnEnded?.Invoke();
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
          else
        {
            
        }*/

    }

    public override void Exit()
    {
        Debug.Log("Enemy turn: exit");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking");

        _enemyThink.StartThinking();
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("enemy performs action");
        EnemyTurnEnded?.Invoke();
        //turn over, go back to player.
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }
}
