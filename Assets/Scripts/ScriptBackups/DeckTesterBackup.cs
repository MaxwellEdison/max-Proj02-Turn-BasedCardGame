/*using UnityEngine;

public class DeckTester : MonoBehaviour
{
    Deck<Card> _testDeck = new Deck<Card>();

    private void Start()
    {
        //create some cards for the deck.
        Debug.Log("Creating cards...");
        Card cardA = new Card("Sword");
        _testDeck.Add(cardA);
        Card cardB = new Card("Fireball");
        _testDeck.Add(cardB);
        Card cardC = new Card("Elixir");
        _testDeck.Add(cardC);

        // shuffling deck to get new card each test.
        _testDeck.Shuffle();
        //draw a new card from the deck.
        Card testCard = _testDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + testCard);



        //play the new card.
        testCard.Play();

        // shuffling deck to get new card each test.
        _testDeck.Shuffle();
        //draw a new card from the deck.
        testCard = _testDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + testCard);
        //play the new card.
        testCard.Play();

        // shuffling deck to get new card each test.
        _testDeck.Shuffle();
        //draw a new card from the deck.
        testCard = _testDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + testCard);
        //play the new card.
        testCard.Play();

    }
}*/
