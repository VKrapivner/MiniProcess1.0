using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform player;
	//public Transform playerTwo;
	public Vector3 offset;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);	
		//transform.position = new Vector3(player.position.x + offset.x, offset.y, transform.position.z);	

	}
}
