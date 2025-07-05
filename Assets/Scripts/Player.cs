using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] List<GameObject> _cardsInHand;
	[SerializeField] List<EquippableCards> _cardsEquipped;
	[SerializeField] int _hp = 4;
	[SerializeField] int _bullets = 1;
	[SerializeField] bool _barrel = false;
	[SerializeField] bool _jail = false;
	[SerializeField] bool _isInTurn = false;
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
	    if(!_isInTurn) return; 

	    if(Input.GetKeyDown(KeyCode.Q))
	    {
		    PlayCard(1);
	    }
	    else if(Input.GetKeyDown(KeyCode.W))
	    {
		    PlayCard(2);
	    }
	    else if(Input.GetKeyDown(KeyCode.E))
	    {
		    PlayCard(3);
	    }
	    else if(Input.GetKeyDown(KeyCode.R))
	    {
		    PlayCard(4);
	    }
	    else if(Input.GetKeyDown(KeyCode.T))
	    {
		    PlayCard(5);
	    }
	    else if(Input.GetKeyDown(KeyCode.Space))
	    {
		    GameManager.Instance.NextTurn();
	    }
    }

    public void PlayCard(int target)
    {
	    GameObject card = _cardsInHand[target];
	    _cardsInHand.RemoveAt(target);
	    GameManager.Instance.PlayCard(card);

	    card.GetComponent<Cards>().OnUse(this, GameManager.Instance.GetPlayer(target));
    }

    public void AddCard(GameObject card)
    {
	    _cardsInHand.Add(card);
    }

    public void OutTurn()
    {
	    _isInTurn = false;
    }

    public void InTurn()
    {
	    _isInTurn = true;
    }
}
