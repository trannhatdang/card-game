using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class Card : MonoBehaviour
{
	[SerializeField] ScriptableCard _scriptableCard;
	[SerializeField] TMP_Text _name;
	[SerializeField] TMP_Text _suitText;
	[SerializeField] Image _img;
	[SerializeField] Suit _suit;
	[SerializeField] Image _outsideSprite;
	void Start()
	{
		if(_scriptableCard)
		{
			_name.text = _scriptableCard.Name;
			_img = _scriptableCard.Icon;
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
		Debug.Log("lmao");
		Color32 col = _outsideSprite.color;
		col.b = 0;
		_outsideSprite.color = col;
	}
	void OnMouseExit()
	{
		Debug.Log("lmao");
		Color32 col = _outsideSprite.color;
		col.b = 255;
		_outsideSprite.color = col;
	}
}
