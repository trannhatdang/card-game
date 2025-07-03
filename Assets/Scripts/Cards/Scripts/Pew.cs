using UnityEngine;

public class Pew : Cards
{
	public override void OnUse(Player user, Player target)
	{

		GameManager.Instance.Shoot(target);
	}

	public override bool CheckRequirements(Player user, Player target)
	{
		return true;
	}
}
