using UnityEngine;

public class DisplayPlayerHand : MonoBehaviour
{
    public DeckTester _pDeck;
    Deck<AbilityCard> _pHand;

    private void Awake()
    {
        _pHand = _pDeck._playerHand;
        
    }

    public void ShowCards()
    {
/*        foreach (AbilityCard abilityCard in _pHand)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }*/
    }
}
