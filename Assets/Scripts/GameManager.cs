using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] List<Player> _players;
	[SerializeField] List<GameObject> _deck;
	[SerializeField] List<GameObject> _discardPile;
	[SerializeField] List<Hand> _hands;
	[SerializeField] UIManager _uiManager;
	[SerializeField] int _currentTurn = -1;
	public int CurrentTurn
	{
		get {return _currentTurn;}
		private set {;}
	}
    public static GameManager Instance;

    void Awake()
    {
	    if(Instance != null)
	    {
		    Destroy(this.gameObject);
	    }

	    Instance = this;

	    DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {


    }

    //GameFunctions
    public void PlayCard(GameObject card)
    {

    }

    public void NextTurn()
    {
	    //maybe add ui transition?
	    Debug.Log("lmao");
	    _currentTurn = (_currentTurn + 1) % 4;
    }

    public void Shoot(Player target)
    {


    }

    public void DestroyEquippable(int target, GameObject card)
    {


    }

    public List<int> GetRange(int target)
    {
	    List<int> ans = new List<int>();

	    for(int i = 0; i < _players.Count(); ++i)
	    {
		    ans[i] = _players[i].GetRange();
	    }

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
	    for(int i = 0; i < targets.Count(); ++i)
	    {
		    _players[targets[i]].HitPoints = _players[i].HitPoints + 1;
	    }
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

    public Player GetPlayer(int target)
    {
	    return _players[target];
    }

    public void StartNewGame()
    {
	    for(int i = 0; i < _players.Count(); ++i)
	    {
		    _players.RemoveAt(i);
	    }
	    GameObject[] list = GameObject.FindGameObjectsWithTag("Player");

	    for(int i = 0; i < list.Count(); ++i)
	    {
		    _players.Add(list[i].GetComponent<Player>());
		    _players[i].ID = i;
	    }
    }


    //Application

    public void ExitGame()
    {
	    Application.Quit();
    }
    
    //UnityFunctions
    void OnGUI()
    {
	    if(GUILayout.Button("StartNewGame"))
	    {
		    StartNewGame();
	    }
    }
}
