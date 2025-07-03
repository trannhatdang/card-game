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
}
