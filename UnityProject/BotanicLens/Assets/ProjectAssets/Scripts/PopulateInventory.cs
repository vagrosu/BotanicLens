using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateInventory : MonoBehaviour
{
    List<string> plants = new List<string>
    {
        "Cactus",
        "Orchid"
    };

    void Start()
    { 
        for (int i = 0; i < plants.Count; i++)
        {
            GameObject menuItem = new GameObject("MenuItem");
            menuItem.transform.SetParent(this.transform);
            Image panelImage = menuItem.AddComponent<Image>();
            panelImage.color = Color.white; // Set the panel color

            // Set the panel's properties
            RectTransform menuItemRectTransform = menuItem.GetComponent<RectTransform>();
            menuItemRectTransform.sizeDelta = new Vector2(400, 300); // Set the panel size
            menuItemRectTransform.anchoredPosition = new Vector2(-200 + 500 * i, 100); 

            GameObject plantName = new GameObject(plants[i]);
            TextMeshProUGUI plantNameText = plantName.AddComponent<TextMeshProUGUI>();
            plantName.transform.SetParent(menuItemRectTransform, false);
            plantNameText.text = plants[i];
            plantNameText.fontSize = 60;
            plantNameText.color = Color.black;
        }
    }
}