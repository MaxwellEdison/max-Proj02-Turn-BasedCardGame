using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AbilityCardView : MonoBehaviour, IPointerEnterHandler//, IPointerExitHandler
{
    [SerializeField] TextMeshProUGUI _nameTextUI = null;
    [SerializeField] TextMeshProUGUI _costTextUI = null;
    [SerializeField] Image _graphicUI = null;
    [SerializeField] DeckTester _playerDeck;
    [SerializeField] int _myID;
    public Button _button;
    int _sibIndex;
    Event ChangeOrder;

    private void Awake()
    {
        _sibIndex = transform.GetSiblingIndex();
        _button = GetComponentInChildren<Button>();
    }
    public void Display(AbilityCard abilityCard)
    {

        //_button.onClick.AddListener(SelectCard);


        _nameTextUI.text = abilityCard.Name;
        _costTextUI.text = abilityCard.Cost.ToString();
        _graphicUI.sprite = abilityCard.Graphic;
        
        //_cardPosition.position = abilityCard.UIPosition;

    }

    public void CheckIndex() { }
    //if the mouse hovers over it, bring it to the front
    public void OnPointerEnter(PointerEventData _mouseData)
    {
        gameObject.transform.SetAsLastSibling();
    }
    //if the mouse no longer hovers over it, put it back where it was (commented out due to not working quite right)
/*    public void OnPointerExit(PointerEventData _mouseData)
    {
        gameObject.transform.SetSiblingIndex(_sibIndex);
    }*/


    


}
