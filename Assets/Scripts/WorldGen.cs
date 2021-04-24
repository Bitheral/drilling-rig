using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public int ySize;
    public int xSize;
    public GameObject[] ores;
    public GameObject[] materials;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                bool isMaterial = Convert.ToBoolean(Mathf.FloorToInt(UnityEngine.Random.Range(0, 1)));
                if (!isMaterial)
                {
                    // Generate Ores
                    int randomIndex = UnityEngine.Random.Range(0, ores.Length - 1);
                    GameObject selectedOre = Instantiate(ores[randomIndex], new Vector3(x, -y, 0), Quaternion.identity, transform);

                }
                else
                {
                    // Generate Material
                    int randomIndex = UnityEngine.Random.Range(0, materials.Length - 1);
                    GameObject selectedMaterial = Instantiate(materials[randomIndex], new Vector3(x, -y, 0), Quaternion.identity, transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
