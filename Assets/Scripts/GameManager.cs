using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] List<Player> _players;
    public static GameManager Instance;
    void Awake()
    {
	    if(Instance != null)
	    {
		    Destroy(this.gameObject);
	    }

	    Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shoot(int target)
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

    }
}
