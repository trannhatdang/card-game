using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
	[SerializeField] Hand _hand;
	[SerializeField] List<EquippableCard> _equippedCards;
	[SerializeField] PassiveCard _passiveCard;
	[SerializeField] int _hp = 4;
	[SerializeField] int _id = -1;
	bool _initialized = false;
	public int ID
	{
		get{return _id;}
		set
		{
			if(!_initialized)
			{
				_id = value;
				_initialized = true;
			}
		}
	}

	public int HitPoints
	{
		get{return _hp;}
		set{_hp = value;}
	}
    void Update()
    {
	    if(!IsOwner) return;
	    if(GameManager.Instance.CurrentTurn != _id) return;

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

    public void DestroyEquippable(GameObject card)
    {
	    int target = 0;

	    for(int i = 0; i < _equippedCards.Count; ++i)
	    {
		    if(_equippedCards[i] == card)
		    {
			    target = i;
			    break;
		    }
	    }

	    _equippedCards.RemoveAt(target);
    }

    public bool GetBarrel()
    {
	    for(int i = 0; i < _equippedCards.Count; ++i)
	    {
		    if(_equippedCards[i].GetBarrel())
		    {
			    return true;
		    }
	    }
	    return false;
    }

    public bool GetJail()
    {
	    for(int i = 0; i < _equippedCards.Count; ++i)
	    {
		    if(_equippedCards[i].GetJail())
		    {
			    return true;
		    }
	    }
	    return false;
    }

    public int GetRange()
    {
	    for(int i = 0; i < _equippedCards.Count; ++i)
	    {
		    if(_equippedCards[i].GetRange() > 0)
		    {
			    return _equippedCards[i].GetRange();
		    }
	    }
	    return 0;
    }
}
