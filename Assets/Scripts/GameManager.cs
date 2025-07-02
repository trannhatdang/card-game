using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //
    //
    public static GameManager instance;
    void Awake()
    {
	    if(instance != null)
	    {
		    Destroy(this.gameObject);
	    }

	    instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
