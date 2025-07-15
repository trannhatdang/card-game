using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
public class Card : MonoBehaviour
{
	[SerializeField] ScriptableCard _scriptableCard;
	[SerializeField] TMP_Text _name;
	[SerializeField] TMP_Text _suitText;
	[SerializeField] Image _img;
	[SerializeField] Suit _suit;
	[SerializeField] Image _outsideSprite;
	[SerializeField] Hand _currentHand;
	public Hand CurrentHand
	{
		get {return _currentHand;}
		set {_currentHand = value;}
	}
	void Start()
	{
		if(_scriptableCard)
		{
			_name.text = _scriptableCard.Name;
			_img.sprite = _scriptableCard.Icon;
			_suit = new Suit(_scriptableCard.Number);
			_suitText.text = _suit.GetSuit();
		}
	}
	public virtual void OnUse(Player user, Player target)
	{

	}

	public virtual bool CheckRequirements(Player user, Player target)
	{
		return false;
	}

	void OnMouseEnter()
	{
		Color32 col = _outsideSprite.color;
		col.b = 0;
		_outsideSprite.color = col;
	}

	void OnMouseDrag()
	{
		Vector3 mos_pos = Mouse.current.position.ReadValue();
		mos_pos = Camera.main.ScreenToWorldPoint(mos_pos);
		mos_pos.z = 0; 
		this.gameObject.transform.position = mos_pos; 
	}

	void OnMouseExit()
	{
		Color32 col = _outsideSprite.color;
		col.b = 255;
		_outsideSprite.color = col;
	}
	
	void OnMouseUpAsButton()
	{
		_currentHand?.ResetPosition();
	}
}
