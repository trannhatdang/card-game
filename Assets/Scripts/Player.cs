using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] Hand _hand;
	[SerializeField] List<EquippableCard> _cardsEquipped;
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
		    PlayCard(1, 0);
	    }
	    else if(Input.GetKeyDown(KeyCode.W))
	    {
		    PlayCard(2, 0);
	    }
	    else if(Input.GetKeyDown(KeyCode.E))
	    {
		    PlayCard(3, 0);
	    }
	    else if(Input.GetKeyDown(KeyCode.R))
	    {
		    PlayCard(4, 0);
	    }
	    else if(Input.GetKeyDown(KeyCode.T))
	    {
		    PlayCard(5, 0);
	    }
	    else if(Input.GetKeyDown(KeyCode.Space))
	    {
		    GameManager.Instance.NextTurn();
	    }
    }

    public void PlayCard(int CardToPlay, int PlayerToTarget)
    {
	    GameObject card = _hand.GetCard(CardToPlay);
	    _hand.RemoveAt(CardToPlay);
	    GameManager.Instance.PlayCard(card);

	    card.GetComponent<Card>().OnUse(this, GameManager.Instance.GetPlayer(PlayerToTarget));
    }

    public void AddCard(GameObject Card)
    {
	    _hand.AddCard(Card);
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
