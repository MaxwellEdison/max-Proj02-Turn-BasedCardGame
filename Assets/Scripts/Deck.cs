using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 'Deck&lt;T&gt;'
/// </summary>
/// <typeparam name="T"></typeparam>
public class Deck<T> where T : Card
{
    List<T> _cards = new List<T>();
/// <summary>
/// <paramref name="Emptied"/> is an Action event for when the deck is empty.
/// </summary>
    public event Action Emptied = delegate { };
/// <summary>
/// <paramref name="CardAdded"/> is an Action&lt;T&gt; event for when a card is added.
/// </summary>
    public event Action<T> CardAdded = delegate { };
/// <summary>
/// <paramref name="CardRemoved"/> is an Action&lt;T&gt; event for when a card is removed.
/// </summary>
    public event Action<T> CardRemoved = delegate { };

    public int Count => _cards.Count;
    public T TopItem => _cards[_cards.Count - 1];
    public T BottomItem => _cards[0];
    public bool IsEmpty => _cards.Count == 0;

    public int LastIndex
    {
        get
        {
            if (_cards.Count == 0)
            {
                return 0;
            } 
              else
            {
                return _cards.Count - 1;
            }
        }
    }
/// <summary>
/// <para>This converts a 'DeckPosition' into a valid index.  </para>
/// <para>It allows us to be vague and say things like,</para>
/// <para>'Put it on top,'</para>
/// <para>and the system will figure it out on its own.</para>
/// <para><paramref name="position"/> is where we want to get the index from.</para>
/// </summary>
/// <param name="position"><paramref name="position"/> is where we want to get the index from.</param>
    private int GetIndexFromPosition(DeckPosition position)
    {
        int newPositionIndex = 0;
        //empty deck means index = 0
        if(_cards.Count == 0)
        {
            newPositionIndex = 0;
        }
        //get end index if it's on 'from the top'
        if (position == DeckPosition.Top)
        {
            newPositionIndex = LastIndex;
        } 
        // randomize if drawing from the middle
          else if (position == DeckPosition.Middle)
        {
            newPositionIndex = UnityEngine.Random.Range(0, LastIndex);
        }
        //get 0 index if it's 'from the bottom'
          else if (position == DeckPosition.Bottom)
        {
            newPositionIndex = 0;
        }
        return newPositionIndex;
    }


/// <summary>
/// "Add" allows us to add a card to the deck.
/// <para><paramref name="card"/> is the type of card we want to add.</para>
/// <para><paramref name="position"/> is an optional parameter which allows us to specify where we add the card.
/// If empty, <paramref name="position"/> will default to Top.</para>
/// </summary>
/// <param name="card"><paramref name="card"/> is the type of card we want to add.</param>
/// <param name="position"><paramref name="position"/> is an optional parameter which allows us to specify where we add the card.
/// If empty, <paramref name="position"/> will default to Top.</param>
    public void Add(T card, DeckPosition position = DeckPosition.Top)
    {
        //bodyguard
        if (card == null) { return; }

        int targetIndex = GetIndexFromPosition(position);
        // to add it to 'Top' we actually want to add it at the end,
        // by default Insert() moves the current index upwards.
        if(targetIndex == LastIndex)
        {
            _cards.Add(card);
        } 
          else
        {
            _cards.Insert(targetIndex, card);
        }
        CardAdded?.Invoke(card);
    }
/// <summary>
/// "Add" allows us to add a card to the deck.
/// <para><paramref name="cards"/> is the type&lt;T&gt; of card we want to add.</para>
/// <para><paramref name="position"/> is an optional parameter which allows us to specify where we add the card.
/// If empty, <paramref name="position"/> will default to Top.</para>
/// </summary>
/// <param name="cards">
/// <para><paramref name="cards"/> is a 'List&lt;T&gt;' containing type of cards we want to add.</para>
/// <para>This allows us to add multiple cards at once.</para>
/// </param>
/// <param name="position"><paramref name="position"/> is an optional parameter which allows us to specify where we add the card.
/// If empty, <paramref name="position"/> will default to Top.</param>
    public void Add(List<T> cards, DeckPosition position = DeckPosition.Top)
    {
        int itemCount = cards.Count;
        for (int i = 0; i<itemCount; i++)
        {
            Add(cards[i], position);
        }
    }

/// <summary>
/// <para>'Draw' allows us to draw a new card from the deck</para>
/// <para><paramref name="position"/> is an optional parameter which lets us dictate where the card is drawn from.</para>
/// <para><paramref name="position"/> defaults to Top if left undefined.</para>
/// </summary>
/// <param name="position">
/// <para><paramref name="position"/> is an optional parameter which lets us dictate where the card is drawn from.</para>
/// <para><paramref name="position"/> defaults to Top if left undefined.</para>
/// </param>
/// <returns>cardToRemove</returns>

    public T Draw(DeckPosition position = DeckPosition.Top)
    {
        if(IsEmpty)
        {
            Debug.LogWarning("Deck: Cannot draw new item - deck is empty!");
            return default;
        }

        int targetIndex = GetIndexFromPosition(position);

        T cardToRemove = _cards[targetIndex];
        Remove(targetIndex);

        return cardToRemove;
    }

/// <summary>
/// <para>'Remove' is similar to Draw, except it does not return an item.</para>
/// <para><paramref name="index"/> specifies the index to remove</para>
/// </summary>
/// <param name="index"><paramref name="index"/> specifies the index to remove</param>

    public void Remove(int index)
    {
        if (IsEmpty)
        {
            Debug.LogWarning("Deck: Nothing to remove; deck is already empty!");
            return;
        }
          else if (!IsIndexWithinListRange(index))
        {
            Debug.LogWarning("Deck: Nothing to remove; index out of range");
            return;
        }

        T removedItem = _cards[index];
        _cards.RemoveAt(index);

        CardRemoved?.Invoke(removedItem);

        if (_cards.Count == 0)
        {
            Emptied?.Invoke();
        }
    }



    bool IsIndexWithinListRange(int index)
    {
        if (index >= 0 && index <= _cards.Count - 1)
        {
            return true;
        }

        Debug.LogWarning("Deck: index outside of range;" + " index: " + index);
        return false;
    }

/// <summary>
/// <para>'GetCard' allows us to view a card without actually drawing it.</para>
/// <para>This could be used for peeking at the deck, or allowing a player to view the cards in their hand.</para>
/// <para><paramref name="index"/> is the index of the card being operated on.</para>
/// </summary>
/// <param name="index"><paramref name="index"/> is the index of the card being operated on.</param>
/// <returns>default</returns>

    public T GetCard(int index)
    {
        if(_cards[index] != null)
        {
            return _cards[index];
        }
          else
        {
            return default;
        }
    }


/// <summary>
/// Randomly shuffles cards, from the bottom up
/// </summary>
    public void Shuffle()
    {
        //start at the top, randomly swapping cards as we move down
        for(int currentIndex = Count - 1; currentIndex >0; --currentIndex)
        {
            //choose a raandom card, but not already placed cards
            int randomIndex = UnityEngine.Random.Range(0, currentIndex + 1);
            T randomCard = _cards[randomIndex];
            //random card swaps places with current index card
            _cards[randomIndex] = _cards[currentIndex];
            _cards[currentIndex] = randomCard;
            //move down index

        }
    }
}
