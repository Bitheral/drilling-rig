using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public int ySize;
    public int xSize;

    public int noiseScale;
    public GameObject[] ores;
    public GameObject[] materials;

    public Texture2D texEx;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        texEx = new Texture2D(xSize, ySize);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float xCoord = (float)x / xSize * noiseScale;
                float yCoord = (float)y / ySize * noiseScale;
                float sample = Mathf.PerlinNoise(xCoord + Random.Range(x, xSize), yCoord + Random.Range(y, ySize));
                texEx.SetPixel(x, y, new Color(sample, sample, sample));

                if (y > Random.Range(0, ySize / 3))
                {
                    if (sample < 0.5)
                    {
                        // Ore
                        if ((sample < 0.5f && sample > 0.45f) && y > Random.Range(ySize / 3, ySize))
                        {
                            GeneratePrefabs(ores, x, y, 0, texEx);
                        }
                        else
                        {
                            GeneratePrefab(materials[1], x, y, 0);
                        }
                    } else
                    {
                        GeneratePrefab(materials[1], x, y, 0);
                    }
                }
                else
                {
                    GeneratePrefab(materials[0], x, y, 0);
                }                
            }
        }


        texEx.Apply();
        mat.SetTexture("_MainTex", texEx);
    }


    // Update is called once per frame
    void Update()
    {
    }

    void GeneratePrefabs(GameObject[] array, int x, int y, int z, Texture2D tex)
    {
        int random = UnityEngine.Random.Range(0, array.Length);
        Color pixColor;
        Debug.Log(array[random].name.ToLower());
        switch (array[random].name.ToLower())
        {
            case "gold": pixColor = new Color(215 / 255, 207 / 255, 73 / 255); break;
            case "iron": pixColor = new Color(203 / 255, 205 / 255, 205 / 255); break;
            case "copper": pixColor = new Color(184 / 255, 115 / 255, 51 / 255); break;
            case "dirt": pixColor = new Color(76 / 255, 61 / 255, 54 / 255); break;
            case "stone": pixColor = new Color(103 / 255, 103 / 255, 103 / 255); break;
            default: pixColor = new Color(1, 1, 1); break;
        }
        tex.SetPixel(x, y, pixColor);
        Instantiate(array[random], new Vector3(x, -y, z), Quaternion.identity, transform);
    }

    void GeneratePrefab(GameObject gm, int x, int y, int z)
    {
        Instantiate(gm, new Vector3(x, -y, z), Quaternion.identity, transform);
    }
}
