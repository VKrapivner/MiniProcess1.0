using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTorch : MonoBehaviour
{
    public Sprite unlitTorch;
    public Sprite litTorch;
    public Animator torchAnimator;
    public GameObject torchLight;
    private bool isLit = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = unlitTorch;

        if(torchAnimator != null )
            torchAnimator.enabled = false;

        if(torchLight != null )
            torchLight.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLit)
        {
            isLit = true;
            GetComponent<SpriteRenderer>().sprite = litTorch;        

            if(torchAnimator != null )
            {
                torchAnimator.enabled = true;
                torchAnimator.Play("TorchFlameAnimation");
            }

            if(torchLight != null )
                torchLight.SetActive(true);
        }

    }
}
