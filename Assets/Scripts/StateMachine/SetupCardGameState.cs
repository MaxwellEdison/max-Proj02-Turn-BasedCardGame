using UnityEngine;

public class SetupCardGameState : CardGameState
{
    [SerializeField] int _startingCardNumber = 10;
    [SerializeField] int _numberOfPlayers = 2;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: Entering");
        Debug.Log("Creating " + _numberOfPlayers + " players.");
        Debug.Log("creating deck with " + _startingCardNumber + " cards.");
        //Can't change state while still in Enter()/Exit()
        //Don't put ChangeState<> here

        _activated = false;



    }

    public override void Tick()
    {
        if(_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting....");
    }
}
