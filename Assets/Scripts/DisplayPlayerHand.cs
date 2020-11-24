using UnityEngine;
using System.Collections.Generic;

public class DisplayPlayerHand : MonoBehaviour
{
/*    public DeckTester _pDeck;
    Deck<AbilityCard> _pHand;
    [SerializeField] public AbilityCardView _showCard;*/
    [SerializeField] public int _size = 10000;
    [SerializeField] public List<AbilityCardView> _childList;
    int lastUpdate = 0;
/*    Camera _camera = null;

    RaycastHit _hitInfo;*/

    void Awake()
    {

        //_renderer.material.color = _initialColor;
    }

    public void RenewList()
    {
        int children = transform.childCount;
        for (int i = lastUpdate; i < children; i++)
        {
            _childList.Add(transform.GetChild(i).GetComponent<AbilityCardView>());
        }

        lastUpdate = _childList.Count;
    }

    /*    private void Update()
        {

        }*/
}
