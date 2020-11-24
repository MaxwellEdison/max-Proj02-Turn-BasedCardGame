using System.Collections.Generic;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _enemyAbilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _enemyAbilityCardView = null;
    Deck<AbilityCard> _enemyAbilityDeck = new Deck<AbilityCard>();
    public Deck<AbilityCard> _enemyAbilityDiscard = new Deck<AbilityCard>();
    public Deck<AbilityCard> _enemyHand = new Deck<AbilityCard>();
    public int _maxCards = 10;
    [SerializeField] public GameObject _eCardPrefabUI;
    [SerializeField] public GameObject _eDisplayHandObj;
    [SerializeField] public DisplayEnemyHand _eDisplayHand;
    [SerializeField] public List<GameObject> _eDisplayedHand = new List<GameObject>();

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

        foreach (AbilityCardData abilityData in _enemyAbilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _enemyAbilityDeck.Add(newAbilityCard);
        }


        _enemyAbilityDeck.Shuffle();
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
        AbilityCard newCard = _enemyAbilityDeck.Draw(DeckPosition.Top);
        //Instantiate(newCard, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Debug.Log("Enemy drew card: " + newCard.Name);
        Debug.Log("Enemy has " + _enemyHand.Count + " cards.");
        _enemyHand.Add(newCard, DeckPosition.Top);
        
        //newCard._cardPosition = new Vector3();
        PrintEnemyHand();
        _enemyAbilityCardView.Display(newCard);
    }
    private void PrintEnemyHand()
    {
        int x = _eDisplayHand._size / _enemyHand.Count;

        for (int i = 0; i < _enemyHand.Count; i++)
        {
            Vector3 cardPos = new Vector3(75, 75, 75);

            GameObject eNewCard = Instantiate(_eCardPrefabUI, cardPos, Quaternion.identity);
            _eDisplayedHand.Add(eNewCard);
            _eDisplayedHand[i].transform.SetParent(_eDisplayHandObj.transform, false);
            _eDisplayedHand[i].transform.localScale = new Vector3(1f, 1f, 1f);
            _eDisplayedHand[i].transform.localPosition = new Vector3(-500 + (x * 2 * i), 0, 0);
            AbilityCardView newCardView = _eDisplayedHand[i].GetComponent<AbilityCardView>();
            newCardView.Display(_enemyHand.GetCard(i));
            Debug.Log("Player Hand Card: " + _enemyHand.GetCard(i).Name);

        }
    }

    public void PlayTopCard()
    {
        AbilityCard targetCard = _enemyHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        _enemyHand.Remove(_enemyHand.LastIndex);
        _enemyAbilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
