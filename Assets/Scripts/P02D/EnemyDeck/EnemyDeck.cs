using System.Collections.Generic;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    public Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    public Deck<AbilityCard> _enemyHand = new Deck<AbilityCard>();
    public int _maxCards = 10;


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

        foreach (AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }


        _abilityDeck.Shuffle();
    }

/*    private void Update()
    {
        //replace me with enemy AI events
        int i = 0;
        if (i == 0)
        {
            Draw();
        }
        if (i == 0)
        {
            PrintEnemyHand();
        }
        if (i == 0)
        {
            PlayTopCard();
        }
    }*/

    public void Draw()
    {
        if (_enemyHand.Count < _maxCards)
        {
            for (int i = _maxCards - _enemyHand.Count; i < _maxCards; i++)
            {
               Draw();
            }
        }
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        //Instantiate(newCard, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Debug.Log("Enemy drew card: " + newCard.Name);
        Debug.Log("Enemy has " + _enemyHand.Count + " cards.");
        _enemyHand.Add(newCard, DeckPosition.Top);

        //newCard._cardPosition = new Vector3();

        _abilityCardView.Display(newCard);
    }
    private void PrintEnemyHand()
    {
        for (int i = 0; i < _enemyHand.Count; i++)
        {
            Debug.Log("Enemy Hand Card: " + _enemyHand.GetCard(i).Name);
        }
    }

    public void PlayTopCard()
    {
        AbilityCard targetCard = _enemyHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        _enemyHand.Remove(_enemyHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
