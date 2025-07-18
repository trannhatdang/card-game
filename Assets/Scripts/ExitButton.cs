using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
	Button _button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    _button = GetComponent<Button>();

	    _button.onClick.AddListener(GameManager.Instance.ExitGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
