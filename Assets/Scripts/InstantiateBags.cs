using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InstantiateBags : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private GameObject slot;
    [SerializeField] private GameObject parentBag;
    [SerializeField] private GameObject mainBag;
    [SerializeField] private GameObject parentVendor;
    [SerializeField] private List<Sprite> foods;
    [SerializeField] private List<Sprite> weapons;
    [SerializeField] private List<Sprite> cloths;
    
    private List<Item> items;
    private List<GameObject> vendorSlots;
    private List<GameObject> bagSlots;
    private const int numOfSlots = 16;
    private void Start()
    {
        bagSlots = new List<GameObject>();
        vendorSlots = new List<GameObject>();
        for (int i = 0; i < numOfSlots; i++)
        {
            GameObject bs = Instantiate(slot, parentBag.transform);
            GameObject vs = Instantiate(slot, parentVendor.transform);
            bagSlots.Add(bs);
            vendorSlots.Add(vs);
        }

        Item food = Instantiate(item, bagSlots[1].transform);
        food.GetComponent<Image>().sprite = foods[Random.Range(0, foods.Count)];
        food.transform.position = bagSlots[1].transform.position;
        
        Item weapon = Instantiate(item, bagSlots[3].transform);
        weapon.GetComponent<Image>().sprite = weapons[Random.Range(0, weapons.Count)];
        weapon.transform.position = bagSlots[3].gameObject.transform.position;
        
        Item cloth = Instantiate(item, bagSlots[6].transform);
        cloth.GetComponent<Image>().sprite = cloths[Random.Range(0, cloths.Count)];
        cloth.transform.position = bagSlots[6].transform.position;

    }
}
