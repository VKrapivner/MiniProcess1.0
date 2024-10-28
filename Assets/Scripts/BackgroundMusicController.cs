using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
	private AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
    {
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();  // Start the music
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
