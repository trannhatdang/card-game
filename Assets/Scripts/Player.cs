using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] List<Cards> _cardsInHand;
	[SerializeField] List<EquippableCards> _cardsEquipped;
	[SerializeField] int _hp = 4;
	[SerializeField] int _bullets = 1;
	[SerializeField] bool _barrel = false;
	[SerializeField] bool _jail = false;
	public bool Barrel
	{
		get {return _barrel;}
		set {_barrel = value;}
	}
	public bool Jail
	{
		get{return _jail;}
		set{_jail = value;}
	}
	public int HitPoints
	{
		get{return _hp;}
		set{_hp = value;}
	}

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void _playCard(int target)
    {
	    Cards card = _cardsInHand[target];
	    _cardsInHand.RemoveAt(target);
	    GameManager.Instance.PlayCard(card);
	    card.OnUse(this, GameManager.Instance.GetPlayer(target));
    }

    public void AddCard(Cards card)
    {
	    _cardsInHand.Add(card);
    }

}
