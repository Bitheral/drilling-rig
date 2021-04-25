using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public string name;
    public float weight;
    public float costPerKg;

    public Item(string nameIn, float costIn)
    {
        name = nameIn;
        weight = 0;
        costPerKg = costIn;
    }

    public override string ToString() => $"({name}, {weight}, £{costPerKg}/kg";
}

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxWeight = 5000;
    public float currentWeight = 0;

    public float totalValue = 0;

    [SerializeField]
    public Item[] items= { new Item("Copper",  4.77f), new Item("Iron", 0.5f), new Item("Gold", 36682.7f) };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float totalWeight = 0;
        for (int i = 0; i < items.Length; i++)
        {
            totalWeight += items[i].weight;
            totalValue += (items[i].costPerKg * items[i].weight);
        }

        currentWeight = totalWeight;
    }
}
