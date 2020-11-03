using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnCardGameState : CardGameState
{
    [SerializeField] TextMeshProUGUI _playerTurnTextUI = null;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        Debug.Log("Player turn: Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
        // unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        Debug.Log("Player Turn: exiting");
    }
    void OnPressedConfirm()
    {
        Debug.Log("Attempt to enter enemy state!");
        //change the enemy turn state
        StateMachine.ChangeState<EnemyTurnCardGameState>();
    }
}
