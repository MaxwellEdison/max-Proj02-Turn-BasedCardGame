using UnityEngine;

public class AbilityCard : Card
{
    public int Cost { get; private set; }
    public Sprite Graphic { get; private set; }
    public CardPlayEffect PlayEffect { get; private set; }


/// <summary>
/// <para>--- please don't forget to update me! ---</para>
/// 'AbilityCard' is a type of card.
/// <para><paramref name="Data"/> can carry the cards name, cost and graphic.</para>
/// <para>--- please don't forget to update me! ---</para>
/// </summary>
/// <param name="Data"> <paramref name="Data"/>carries card data.
/// <para>Data.Name = card name.</para>
/// <para>Data.Cost = card cost.</para>
/// <para>Data.Graphics = card graphics/sprite.</para>
/// 
/// </param>
    public AbilityCard(AbilityCardData Data)
    {
        Name = Data.Name;
        Cost = Data.Cost;
        Graphic = Data.Graphic;
        PlayEffect = Data.PlayEffect;
    }


/// <summary>
/// 'Play' allows us to play the currently selected card (???)
/// </summary>

    public override void Play()
    {
        ITargetable target = TargetController.CurrentTarget;
        Debug.Log("Playing " + Name + " on target.");
        PlayEffect.Activate(target);
    }
}
