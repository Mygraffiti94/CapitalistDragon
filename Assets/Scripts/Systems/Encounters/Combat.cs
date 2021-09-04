using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Will handle the main combat system during an encounter
/// </summary>
public class Combat : MonoBehaviour
{
	[SerializeField] public AbilityDetailPanel abilityDetailPanel;
	[SerializeField] public TextMeshProUGUI text;
	private List<CombatActor> actorList;		// List of actors in combat in their turn order
	public List<CombatActor> activeParty;		// Party list in its spawn order to keep track of targetted abilities.
	public List<CombatActor> enemies;			// Enemy list in its spawn order to keep track of targetted abilites.
	private int turnIndex;
	[HideInInspector] public CombatActor currentActor;
	[HideInInspector] public List<CombatActor> targets;
	[HideInInspector] public Ability usedAbility;
	[HideInInspector] private bool startedTurn;

	private void Awake()
	{
		targets = new List<CombatActor>();
	}

	private void Update()
	{
		// Exit checks to break if combat is not ready to go through
		if(startedTurn == false || usedAbility == null || targets == null)
			return;

		if(targets.Count < 1)
			return;
		else
		{
			text.text = currentActor.actorName + " uses " + usedAbility.abilityName + " on " + targets[0].actorName;
			EndTurn();
		}
	}

	public void InitiateCombat(Party party, List<CombatActor> encounter)
	{
		actorList = new List<CombatActor>();
		foreach (CombatActor member in party.members)
		{
			member.enemy = false;
			actorList.Add(member);
			activeParty = party.members;
		}
		foreach (CombatActor enemy in encounter)
		{
			enemy.enemy = true;
			actorList.Add(enemy);
			enemies = encounter;
		}

		// TODO: Add in a fun way to do static turn orders with speed/abilty CD etc. For right now we just go in load order
		turnIndex = 0;
		BeginTurn(actorList[turnIndex]);
	}

	/// <summary>
	/// This method will start the turn of the player or enemy based off the actorList
	/// </summary>
	public void BeginTurn(CombatActor actor)
	{
		currentActor = actor;
		if(actor.enemy == false)
		{
			abilityDetailPanel.Set(actor.abilities);
			startedTurn = true;
		}
		else
			EndTurn();
	}

	public CombatActor GetCurrentActor()
	{
		return actorList[turnIndex];
	}

	public void EndTurn()
	{
		// Remove current actors abilities and close the panel
		foreach(Transform child in abilityDetailPanel.transform)
		{
			Destroy(child.gameObject);
		}
		abilityDetailPanel.gameObject.SetActive(false);

		if(turnIndex >= actorList.Count - 1)
			turnIndex = 0;
		else
			turnIndex++;

		// Null these out after we are done using them
		targets = null;
		usedAbility = null;
		startedTurn = false;

		BeginTurn(actorList[turnIndex]);
	}
}
