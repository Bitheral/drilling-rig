using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;
    public int dropCount;

    private Material crack_material;
    private GameObject crack;

    void Start()
    {
        GameObject cracks = new GameObject("Crack");
        Vector3 crackPos = cracks.transform.position;
        cracks.SetActive(false);
        crackPos.x = transform.position.x;
        crackPos.y = transform.position.y;
        cracks.transform.SetParent(transform);
        cracks.AddComponent<MeshRenderer>();
        cracks.AddComponent<MeshFilter>();
        cracks.GetComponent<MeshFilter>().mesh = Resources.Load<GameObject>("CubeMesh").GetComponent<MeshFilter>().sharedMesh;
        cracks.GetComponent<MeshRenderer>().material = crack_material;
        cracks.transform.position = crackPos;
        crack = cracks;


    }

    // Update is called once per frame
    void Update()
    {
        if(health < 100)
        {
            crack.SetActive(true);
        }

        if(health <= 0)
        {
            Destroy(transform);
        }
    }
}
