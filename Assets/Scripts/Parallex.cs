using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;//sets in the editor

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;//Gives the length of the sprite

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); //How far we move relative to the camera
        float distance = (cam.transform.position.x * parallaxEffect);//How far we have moved in world space

        transform.position = new Vector3 (startpos * distance, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if(temp < startpos - length) startpos -= length;
    }
}
