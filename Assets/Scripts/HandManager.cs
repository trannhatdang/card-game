using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static HandManager Instance;
    [SerializeField] List<Hand> _hands;
    void Awake()
    {
	    if(Instance != null)
	    {
		    Destroy(this.gameObject);
	    }
	    Instance = this;

	    DontDestroyOnLoad(this.gameObject);
    }



}
