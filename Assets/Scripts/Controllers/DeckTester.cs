using System.Collections.Generic;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();
    

    private void Start()
    {
        SetupAbilityDeck();
    }


    /// <summary>
    /// 'SetupAbilityDeck' creates a test deck filled with AbilityCard(s).
    /// <list type="bullet">
    /// <listheader>
    ///     <term>Currently composed of</term>
    /// </listheader>
    /// <item>
    ///     <term>cardA</term>
    ///     <description>Slash</description>
    /// </item>
    /// <item>
    ///     <term>cardB</term>
    ///     <description>Kick</description>
    /// </item>
    /// <item>
    ///     <term>cardC</term>
    ///     <description>Charge</description>
    /// </item>
    /// <item>
    ///     <term>cardD</term>
    ///     <description>Shout</description>
    /// </item></list>
    /// </summary>
    private void SetupAbilityDeck()
    {

        foreach(AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }
/*        Debug.Log("Creating Ability Cards...");
        //creates test cards A through D
        AbilityCard cardA = new AbilityCard("Slash");
        AbilityCard cardB = new AbilityCard("Kick");
        AbilityCard cardC = new AbilityCard("Charge");
        AbilityCard cardD = new AbilityCard("Shout");

        _abilityDeck.Add(cardA);
        _abilityDeck.Add(cardB);
        _abilityDeck.Add(cardC);
        _abilityDeck.Add(cardD);*/

        _abilityDeck.Shuffle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }
    }

    private void Draw()
    {
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);

        _abilityCardView.Display(newCard);
    }
    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
