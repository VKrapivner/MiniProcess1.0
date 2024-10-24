using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public string itemName;

    private bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.P))
        {
            PickUp();
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
			ShowSpeechBubble(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
        {
            isPlayerInRange = false ;

            ShowSpeechBubble(false);
		}
	}

	private void PickUp()
    {
        Inventory.Instance.AddItem(itemName);
        Destroy(gameObject);//Remove object from the scene
    }

    private void ShowSpeechBubble(bool show)
    {
		Debug.Log("Show speech bubble: " + show);
	}
}
