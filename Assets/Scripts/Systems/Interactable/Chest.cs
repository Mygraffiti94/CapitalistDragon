using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] bool openedChest	= false;
	[SerializeField] Sprite[] chestSprites;
	[SerializeField] public float openTime = 0.5f;
	[SerializeField] public List<Item> containedItems;
	[SerializeField] public Dialogue dialogue;

	private float frameTime = 0.25f;

	private Inventory inventory;
	private SpriteRenderer spriteRenderer;

	public void OpenChest(GameObject actor)
	{
		Dialogue chestDialogue;

		// We only need to execute any part of the method if we haven't opened the chest yet
		if (openedChest == true)
			return;

		if(chestSprites.Length < 1)
		{
			Debug.Log("No chest animation sprites added to " + gameObject.name);
			return;
		}

		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer == null)
		{
			Debug.Log("No sprites added to the chest. How did this even get here.");
			return;
		}

		// Get how many seconds that each frame of the chest needs to open for
		frameTime = openTime / chestSprites.Length;
		StartCoroutine(FrameWait());
		inventory = actor.GetComponent<Inventory>();
		chestDialogue = Instantiate(dialogue);
		foreach(Item item in containedItems)
		{
			chestDialogue.text[0] += "\n 1x " + item.itemName;
			inventory.AddItem(item);
		}

		GameManager.instance.dialogueManager.StartDialogue(chestDialogue);
		openedChest = true;
	}

	/// <summary>
	/// Method that will make sure that the chest opens to the length it was configured for
	/// </summary>
	/// <returns></returns>
	IEnumerator FrameWait()
	{
		for(int i = 0; i < chestSprites.Length; i++)
		{
			yield return new WaitForSeconds(frameTime);
			spriteRenderer.sprite = chestSprites[i];
		}
	}
}
