using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static UIManager Instance;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _playerSelectionMenu;
    void Awake()
    {
	    if(Instance && Instance != this)
	    {
		    Destroy(this.gameObject);
	    }
	    else
	    {
		    Instance = this;
	    }

	    DontDestroyOnLoad(this.gameObject);
    }
}
