using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableCard")]
public class ScriptableCard : ScriptableObject
{
	public string Name;
	public Image Icon;
	public int Number;
}
