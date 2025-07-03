using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] List<ICards> _cardsInHand;
	[SerializeField] List<IEquippableCards> _cardsEquipped;
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
	    Card card = _cardsInHand[target];
	    cardsInHand.RemoveAt(target);
	    GameManager.Instance.PlayCard(card);
	    card.OnUse(this);
    }
}
