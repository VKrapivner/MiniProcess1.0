using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<string> items = new List<string>();

	[Header("UI Elements")]
	public GameObject inventoryPanel;

    private bool isOpen = false;

	private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

	// Start is called before the first frame update
	void Start()
    {
        inventoryPanel.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ToggleInventory();
    }


	public void AddItem(string itemName)
	{
		items.Add(itemName);
		Debug.Log("Item added: " + itemName);
	}

    private void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);
        }
    }
}
