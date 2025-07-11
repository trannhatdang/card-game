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
}
