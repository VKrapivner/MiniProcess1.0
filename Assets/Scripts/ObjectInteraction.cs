using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject speechBubble;
	public TextMeshProUGUI speechText;
	public string[] interactionTexts;
	public Button speechBubbleButton;

	public int currentTextIndex = 0;

	// Start is called before the first frame update
	void Start()
    {
        speechBubble.SetActive(false); //Hides initially

		speechBubbleButton.onClick.AddListener(OnSpeechBubbleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			currentTextIndex = 0;

			speechText.text = interactionTexts[currentTextIndex]; //Update interaction text

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

	private void OnSpeechBubbleClick()
	{
		// Increment to the next text
		currentTextIndex++;

		// Check if there are more texts to show
		if (currentTextIndex < interactionTexts.Length)
		{
			speechText.text = interactionTexts[currentTextIndex]; // Update the speech text
		}
		else
		{
			// Optionally, hide the bubble if no more texts to display
			speechBubble.SetActive(false);
		}
	}

}
