using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[SerializeField] Hand _hand;
	[SerializeField] List<EquippableCard> _cardsEquipped;
	[SerializeField] int _hp = 4;
	[SerializeField] int _bullets = 1;
	[SerializeField] bool _barrel = false;
	[SerializeField] bool _jail = false;
	[SerializeField] bool _isInTurn = false;
	[SerializeField] InputActionReference _playFirstCard;
	[SerializeField] InputActionReference _playSecondCard;
	[SerializeField] InputActionReference _playThirdCard;
	[SerializeField] InputActionReference _playFourthCard;
	[SerializeField] InputActionReference _playFifthCard;
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

	    if(UserInput.Instance.Card1IsPressed)
	    {
		    PlayCard(1, 0);
	    }
	    else if(UserInput.Instance.Card2IsPressed)
	    {
		    PlayCard(2, 0);
	    }
	    else if(UserInput.Instance.Card3IsPressed)
	    {
		    PlayCard(3, 0);
	    }
	    else if(UserInput.Instance.Card4IsPressed)
	    {
		    PlayCard(4, 0);
	    }
	    else if(UserInput.Instance.Card5IsPressed)
	    {
		    PlayCard(5, 0);
	    }
	    else if(UserInput.Instance.NextTurnIsPressed)
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
