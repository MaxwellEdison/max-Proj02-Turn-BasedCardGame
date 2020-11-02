using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDamagePlayEffect", menuName ="CardData/PlayEffects/Damage")]

public class DamagePlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 1;

    public override void Activate(ITargetable targetable)
    {
        IDamageable objectToDamage = targetable as IDamageable;
        if(objectToDamage != null)
        {
            objectToDamage.TakeDamage(_damageAmount);
            Debug.Log("Add damage to the target");
        }
          else
        {
            Debug.Log("Target is not damageable");
        }
    }


}
