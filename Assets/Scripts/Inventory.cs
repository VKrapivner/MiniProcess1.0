using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<string> items = new List<string>();

    [Header("UI Elements")]
    //public GameObject inventoryShower;
    public GameObject inventoryPanel;
    public Transform[] itemContainers;
    public GameObject itemPrefab;

    private bool isOpen = false;

    private Vector2[] slotPositions = new Vector2[]
    {
        new Vector2(-227, 129) //Slot 1.1

    };

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
		//inventoryShower.SetActive(false);

	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update in Inventory acceced");
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Pressed I");
			ToggleInventory();
		}
           
    }


	//public void AddItem(string itemName)
	//{
	//	items.Add(itemName);
	//	Debug.Log("Item added: " + itemName);
	//}

	public void AddItem(string itemName, Sprite itemSprite)
	{
		if(items.Count >= slotPositions.Length)
        {
            Debug.LogWarning("Inventory is full!");
            return;
        }

        items.Add(itemName);
        Debug.Log("Item added: " + itemName);

        AddItemToUI(itemSprite);
	}

    private void AddItemToUI(Sprite itemSprite)
    {
        foreach (Transform container in itemContainers)
        {
            if (container.childCount > 0)//stack items not implemented yet 
            {
                continue;
            }

			// Create a new item icon from the prefab
			GameObject newItem = Instantiate(itemPrefab, container);
			newItem.GetComponent<Image>().sprite = itemSprite;

			// Position the item at the next available slot
			RectTransform itemRect = newItem.GetComponent<RectTransform>();

		}


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
