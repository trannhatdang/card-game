using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableCard")]
public class ScriptableCard : ScriptableObject
{
	public string Name;
	public string Effect;
	public Sprite Icon;
	public int Number;
}
