using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static UserInput Instance;

    [SerializeField] PlayerInput _playerInput;

    public bool Card1IsPressed {get; private set;}
    public bool Card2IsPressed {get; private set;}
    public bool Card3IsPressed {get; private set;}
    public bool Card4IsPressed {get; private set;}
    public bool Card5IsPressed {get; private set;}
    public bool NextTurnIsPressed {get; private set;}

    InputAction _playCard1;
    InputAction _playCard2;
    InputAction _playCard3;
    InputAction _playCard4;
    InputAction _playCard5;
    InputAction _nextTurn;
    void Awake()
    {
        if(Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        _playCard1 = _playerInput.actions["PlayCard1"];
        _playCard2 = _playerInput.actions["PlayCard2"];
        _playCard3 = _playerInput.actions["PlayCard3"];
        _playCard4 = _playerInput.actions["PlayCard4"];
        _playCard5 = _playerInput.actions["PlayCard5"];
        _nextTurn = _playerInput.actions["NextTurn"];
    }

    // Update is called once per frame
    void Update()
    {
        Card1IsPressed = _playCard1.IsPressed();
        Card2IsPressed = _playCard2.IsPressed();
        Card3IsPressed = _playCard3.IsPressed();
        Card4IsPressed = _playCard4.IsPressed();
        Card5IsPressed = _playCard5.IsPressed();
        NextTurnIsPressed = _nextTurn.IsPressed();
    }

}
