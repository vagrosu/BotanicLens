
using System;
using System.Collections.Generic;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    public GameObject Bamboo;
    public GameObject Bonsai;
    public GameObject Cactus;
    public GameObject sunflower;
    public GameObject Yucca;
    public GameObject echeveria;
    public GameObject Kalanchoe;
    public GameObject orchid;



    Dictionary<string, GameObject> allPlants = new Dictionary<string, GameObject>();

    void Awake()
    {
        this.transform.position = new Vector2(0, 0);
        allPlants.Add("Bamboo", Bamboo);
        //allPlants.Add("Bonsai", Bonsai);
        allPlants.Add("Cactus", Cactus);
        allPlants.Add("Yucca", Yucca);
        allPlants.Add("Kalanchoe", Kalanchoe);


        int index = 0;
        foreach( var pair in allPlants)
        {
            InventoryItem menuTriggerer = new InventoryItem(pair.Key, index);
            GameObject menuItem = menuTriggerer.spawnItem(this.transform);

            GameObject plant = Instantiate(pair.Value, menuItem.transform);
            plant.transform.localPosition = new Vector3(0, 0.5f, 0);
            plant.transform.localScale = new Vector3(0.25f, 0.5f, 0.25f);
            plant.transform.SetParent(menuItem.transform);

            index += 1;
        }
    }
}