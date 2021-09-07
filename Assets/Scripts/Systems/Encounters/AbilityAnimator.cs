using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private Animator animator;	// Animator to use that will be attached on the object
	[SerializeField] private GameObject selector;
	[SerializeField] public DamageTextPopup damageTextPopup;
	private bool showSelector = true;

	/// <summary>
	/// Method call to run the animation of the ability that is on the current object.
	/// Will need to update the ability parameter with which ever ability needs to be used
	/// </summary>
	public void TriggerAnimation(Ability ability, int damage)
	{
		showSelector = false;
		animator.SetBool("RunAnimation", false);
		animator.Play(ability.animationName.ToString());
		animator.SetBool("RunAnimation", true);
		showSelector = true;
	}

	/// <summary>
	/// This method will call end turn when the animation finishes
	/// </summary>
	public void EndAnimation()
	{
		GameManager.instance.combat.actionsPanel.SetActive(true);
		return;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		selector.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		selector.SetActive(false);
	}
}
