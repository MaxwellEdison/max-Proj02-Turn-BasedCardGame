using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    public Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    public Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();
    public Button _drawCardButton;
    public Button _playCardButton;
    [SerializeField] public GameObject _cardPrefabUI;
    [SerializeField] public GameObject _displayHandObj;
    [SerializeField] public DisplayPlayerHand _displayHand;
    [SerializeField] public List<GameObject> _displayedHand = new List<GameObject>();
    [SerializeField] public AbilityCardView _selectedCard;
    int lastSize = 0;


    private void Start()
    {
        SetupAbilityDeck();
        _drawCardButton.onClick.AddListener(Draw);
        _playCardButton.onClick.AddListener(PlayTopCard);
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


        _abilityDeck.Shuffle();
    }

    private void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }*/
/*        if (Input.GetKeyDown(KeyCode.W))
        {

            PrintPlayerHand();
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }
    }

    private void Draw()
    {
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        //Instantiate(newCard, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);

        //newCard._cardPosition = new Vector3();

        //_abilityCardView.Display(newCard);
        PrintPlayerHand();
    }

    private void UpdateHand()
    {
        int minimumX = 0 - (_displayHand._size / 2);
        int x = _displayHand._size / _playerHand.Count;
        for (int i = 0; i < _displayedHand.Count; i++)
        {
            _displayedHand[i].transform.localPosition = new Vector3(minimumX + (x * i), 0, 0);
        }
    }
    private void PrintPlayerHand()
    {
        int x = _displayHand._size / _playerHand.Count;

        for (int i = lastSize; i < _playerHand.Count; i++)
        {
            Vector3 cardPos = new Vector3(75,75,75);

            GameObject _newCard = Instantiate(_cardPrefabUI,cardPos,Quaternion.identity);
            _displayedHand.Add(_newCard);
            _displayedHand[i].transform.SetParent(_displayHandObj.transform, false);
            _displayedHand[i].transform.localScale = new Vector3(1f,1f,1f);
            _displayedHand[i].transform.localPosition = new Vector3(-500 + (x * 2*i), 0, 0);
            AbilityCardView newCardView = _displayedHand[i].GetComponent<AbilityCardView>();
            newCardView.Display(_playerHand.GetCard(i));
            _displayedHand[i].name = i + " " + _playerHand.GetCard(i).Name;
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);

        }
        _displayHand.RenewList();
        lastSize = _displayedHand.Count;
        UpdateHand();
    }


    void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        Destroy(_displayedHand[_playerHand.LastIndex]);
        _displayedHand.RemoveAt(_playerHand.LastIndex);
        _playerHand.Remove(_playerHand.LastIndex);

        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
