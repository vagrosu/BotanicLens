using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateInventory : MonoBehaviour
{
    FirebaseHandler handler;

    void Start()
    {
        handler = new FirebaseHandler();
        Debug.Log(handler.plants.Count);
        for (int i = 0; i < handler.plants.Count; i++)
        {
            GameObject menuItem = new GameObject("MenuItem");

            RectTransform menuItemRectTransform = menuItem.AddComponent<RectTransform>();
            menuItemRectTransform.sizeDelta = new Vector2(200f + i * 30, 50f - i * 10);
            menuItem.transform.SetParent(this.transform, false);

            GameObject plantName = new GameObject(handler.plants[i]);
            TextMeshProUGUI plantNameText = plantName.AddComponent<TextMeshProUGUI>();
            plantName.transform.SetParent(menuItemRectTransform, false);
            plantNameText.text = handler.plants[i];

            plantNameText.fontSize = 50;
            plantNameText.color = Color.black;
        }
    }
}