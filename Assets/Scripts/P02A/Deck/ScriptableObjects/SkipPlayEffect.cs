using UnityEngine;

[CreateAssetMenu(fileName = "NewSkipPlayEffect", menuName = "CardData/PlayEffects/Skip")]
public class SkipPlayEffect : CardPlayEffect
{
    [SerializeField] int _turnSkip = 1;

    public override void Activate(ITargetable targetable)
    {
/*        Debug.Log("Skipping enemy state");
        Debug.Log("pretending to skip this many enemy states: " + _turnSkip);*/
        EnemyTurnCardGameState _enemyTurnSM = GameObject.Find("StateController").GetComponent<EnemyTurnCardGameState>();
        _enemyTurnSM._turnsToSkip = _turnSkip;
    }
}
