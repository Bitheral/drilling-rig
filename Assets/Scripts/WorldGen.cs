using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public int ySize;
    public int xSize;
    public int zSize;

    public int noiseScale;
    public GameObject[] ores;
    public GameObject[] materials;

    public GameObject oreGen;

    // Start is called before the first frame update
    void Start()
    {
        // Generate spheres with triggers for Ore gen
        int oreSections = Random.Range(10, 50);
        for (int i = 0; i < oreSections; i++)
        {
            int randX = Random.Range(0, xSize);
            int randY = Random.Range(ySize / 3, ySize);

            oreGen.GetComponent<SphereCollider>().radius = Random.Range(1, 10);
            Instantiate(oreGen, new Vector3(randX, -randY, 0), Quaternion.identity, transform);
        }

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    float xCoord = (float)x / xSize * noiseScale;
                    float yCoord = (float)y / ySize * noiseScale;
                    float zCoord = (float)z / zSize * noiseScale;
                    //float sample = Mathf.PerlinNoise(xCoord + Random.Range(x, xSize), yCoord + Random.Range(y, ySize));
                    float sample = PerlinNoise3D(xCoord + Random.Range(x, xSize), yCoord + Random.Range(y, ySize), zCoord + Random.Range(z, zSize));

                    if (y > 0)
                    {
                        if (y > Random.Range(0, ySize / 3))
                        {
                            if (y > Random.Range(ySize / 3, ySize))
                            {
                                if (isIntersectingSection(x, y) && (sample < 0.5 && sample > 0.3f))
                                {
                                    GeneratePrefabs(ores, x, y, z);
                                }
                                else
                                {
                                    GeneratePrefab(materials[1], x, y, z);
                                }
                            }
                            else
                            {
                                GeneratePrefab(materials[1], x, y, z);
                            }
                        }
                        else
                        {
                            GeneratePrefab(materials[0], x, y, z);
                        }
                    }
                    else
                    {
                        GeneratePrefab(materials[2], x, y, z);
                    }
                }
            }
        }

        for(int x = -1; x <= xSize; x++)
        {
            GeneratePrefab(materials[3], x, ySize, 0);

            GeneratePrefab(materials[3], x, ySize, 1);
        }

        for(int y = -5; y < ySize; y++)
        {
            GeneratePrefab(materials[3], -1, y, 0);
            GeneratePrefab(materials[3], xSize, y, 0);

            GeneratePrefab(materials[3], -1, y, 1);
            GeneratePrefab(materials[3], xSize, y, 1);
        }


        GameObject[] oS = GameObject.FindGameObjectsWithTag("OreGen");
        for (var o = 0; o < oS.Length; o++)
        {
            Destroy(oS[o]);
        }
    }

    public static float PerlinNoise3D(float x, float y, float z)
    {
        float xy = Mathf.PerlinNoise(x, y);
        float xz = Mathf.PerlinNoise(x, z);
        float yz = Mathf.PerlinNoise(y, z);
        float yx = Mathf.PerlinNoise(y, x);
        float zx = Mathf.PerlinNoise(z, x);
        float zy = Mathf.PerlinNoise(z, y);

        return (xy + xz + yz + yx + zx + zy) / 6;
    }

    bool isIntersectingSection(int x, int y)
    {
        GameObject[] oS = GameObject.FindGameObjectsWithTag("OreGen");
        for (var o = 0; o < oS.Length; o++)
        {
            GameObject oreSection = oS[o];
            //Vector3 size = oreSection.GetComponent<SphereCollider>().bounds.size;
            SphereCollider collider = oreSection.GetComponent<SphereCollider>();
            Vector3 pos = collider.bounds.center;
            int xDistance = Mathf.FloorToInt(Mathf.Pow(x - pos.x, 2));
            int yDistance = Mathf.FloorToInt(Mathf.Pow(-y - pos.y, 2));
            if (Mathf.Sqrt(xDistance + yDistance) <= collider.radius)
            {
                return true;
            }
        }

        return false;
    }

    void GeneratePrefabs(GameObject[] array, int x, int y, int z)
    {
        int random = Random.Range(0, array.Length);
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);
        Instantiate(array[random], new Vector3(x, -y, z), rotation, transform);
    }

    void GeneratePrefab(GameObject gm, int x, int y, int z)
    {
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);
        Instantiate(gm, new Vector3(x, -y, z), rotation, transform);
    }
}
