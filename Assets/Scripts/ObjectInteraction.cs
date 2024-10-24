using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject speechBubble;
	public TextMeshProUGUI speechText;
	public string interactionText;

    // Start is called before the first frame update
    void Start()
    {
        speechBubble.SetActive(false); //Hides initially
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			speechText.text = interactionText; //Update interaction text
			speechBubble.SetActive(true); // Show speech bubble
		}
	}

	// Trigger when the player leaves the interaction zone
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			speechBubble.SetActive(false); // Hide speech bubble
		}
	}

}
