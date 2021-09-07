using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextPopup : MonoBehaviour
{
	[SerializeField] private TextMeshPro damageText;
	[SerializeField] private Animator animator;

	public void ShowDamage(int damageNumber)
	{
		damageText.text = damageNumber.ToString();
		animator.SetBool("ShowDamage", true);
	}

	public void ClearNumber()
	{
		animator.SetBool("ShowDamage", false);
		damageText.text = "";
	}
}
