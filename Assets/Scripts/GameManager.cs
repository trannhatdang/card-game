using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] List<Player> _players;
	[SerializeField] List<GameObject> _deck;
	[SerializeField] List<GameObject> _discardPile;
	[SerializeField] int _currentTurn = 0;
    public static GameManager Instance;

    void Awake()
    {
	    if(Instance != null)
	    {
		    Destroy(this.gameObject);
	    }

	    Instance = this;
    }

    void Update()
    {



    }

    public void NextTurn()
    {
	    //maybe add ui transition?
	    _currentTurn = (_currentTurn + 1) % 4;
	    for(int i = 0; i < 4; ++i)
	    {
		    _players[i].OutTurn();
	    }

	    _players[_currentTurn].InTurn();
    }

    public void Shoot(Player target)
    {


    }

    public void DestroyEquippable(int target, GameObject card)
    {

    }

    public void AddRange(int target, int value)
    {

    }

    public List<int> GetRange(int target, int value)
    {
	    List<int> ans = new List<int>();
	    return ans;

    }

    public void EnterDuel(int target1, int target2)
    {

    }

    public void EnterDynamite(int target)
    {

    }

    public void EnterStore()
    {

    }

    public void Heal(List<int> targets)
    {

    }

    public void Draw(List<int> targets)
    {
	    foreach(Player player in _players)
	    {
		    if(_deck.Count <= 0) 
		    {
			    _deck = _discardPile.OrderBy( x => UnityEngine.Random.value).ToList();
			    _discardPile.Clear();
		    }

		    player.AddCard(_deck[0]);
		    _deck.RemoveAt(0);
	    }
    }

    public void ShuffleDeck()
    {
	    _deck = _deck.OrderBy( x => UnityEngine.Random.value).ToList();
    }

    public void ShuffleDiscard()
    {
	    _discardPile = _discardPile.OrderBy( x => UnityEngine.Random.value).ToList();
    }

    public void Discard(GameObject card)
    {
	    _discardPile.Add(card);
    }

    public void PlayCard(GameObject card)
    {

    }

    public Player GetPlayer(int target)
    {
	    return _players[target];
    }
}
