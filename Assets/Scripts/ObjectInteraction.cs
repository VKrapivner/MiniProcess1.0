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

	public Collider2D npcCollider;

	// Start is called before the first frame update
	void Start()
    {
		speechBubble.SetActive(false); //Hides initially

		speechBubbleButton.onClick.AddListener(OnSpeechBubbleClick);

		//if (speechBubbleButton != null)
		//{
		//	speechBubbleButton.onClick.RemoveAllListeners();
		//	speechBubbleButton.onClick.AddListener(OnSpeechBubbleClick);
		//}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//Debug.Log("Interaction triggered with: " + gameObject.name);

			currentTextIndex = 0;

			speechText.text = interactionTexts[currentTextIndex]; //Update interaction text

			speechBubble.SetActive(true); // Show speech bubble
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			DisplaySpeechBubble();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			speechBubble.SetActive(false); // Hide speech bubble
		}
	}

	public void OnSpeechBubbleClick()
	{
		Debug.Log($"Arrow clicked. Current Index: {currentTextIndex}");

		currentTextIndex++;

		// Check if there are more texts to show
		if (currentTextIndex < interactionTexts.Length)
		{
			speechText.text = interactionTexts[currentTextIndex]; // Update the speech text
			Debug.Log($"Updated text to: {speechText.text}");

		}
		else
		{
			Debug.Log("No more text to display.");
		
		}
	}

	private void DisplaySpeechBubble()
	{
		Debug.Log($"Displaying speech bubble for: {gameObject.name}");

		currentTextIndex = 0;
		speechText.text = interactionTexts[currentTextIndex];
		speechBubble.SetActive(true);
		npcCollider.isTrigger = true;


	}


}
