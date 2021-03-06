﻿using UnityEngine;

[CreateAssetMenu(fileName = "NewAbilityCard",menuName = "CardData/AbilityCard")]
public class AbilityCardData : ScriptableObject
{
    [SerializeField] string _name = "...";
    public string Name => _name;

    [SerializeField] int _cost = 1;
    public int Cost => _cost;

    [SerializeField] Sprite _graphic = null;
    public Sprite Graphic => _graphic;

    [SerializeField] CardPlayEffect _playEffect = null;
    public CardPlayEffect PlayEffect => _playEffect;

/*    [SerializeField] Vector3 _uiPosition = null;
    public Vector3 UIPosition => _uiPosition;*/
}
