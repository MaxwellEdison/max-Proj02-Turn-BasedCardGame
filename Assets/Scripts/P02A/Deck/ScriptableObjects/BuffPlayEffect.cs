using UnityEngine;

[CreateAssetMenu(fileName = "NewBuffPlayEffect", menuName = "CardData/PlayEffects/Buff")]

public class BuffPlayEffect : CardPlayEffect
{
    [SerializeField] int _buffAmount = 1;

    public override void Activate(ITargetable targetable)
    {
        Debug.Log("ChangeState to double damage(?)");
        Debug.Log("buff next card damage by _buffAmount: " + _buffAmount);
    }
}
