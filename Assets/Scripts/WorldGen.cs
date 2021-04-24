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

    // Start is called before the first frame update
    void Start()
    {
        Texture2D tex = new Texture2D(xSize, ySize);

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float xCoord = (float)x / xSize * noiseScale;
                float yCoord = (float)y / ySize * noiseScale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                if (sample > 0.5)
                {
                    // Mat
                    GeneratePrefab(materials, x, y, 0);
                } else
                {
                    // Ore
                    if((sample < 0.25f && sample > 0.1f) && y > Random.Range(5,10))
                    {
                        GeneratePrefab(ores, x, y, 0);
                    } else
                    {
                        GeneratePrefab(materials, x, y, 0);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GeneratePrefab(GameObject[] array, int x, int y, int z)
    {
        int random = UnityEngine.Random.Range(0, array.Length);
        Instantiate(array[random], new Vector3(x, -y, z), Quaternion.identity, transform);
    }
}
