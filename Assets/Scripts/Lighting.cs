using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{

    public GameObject player;
    public GameObject distanceMeter;
    public Light directionalLight;
    float distance;
    private int mapEnd;

    // Start is called before the first frame update
    void Start()
    {
        mapEnd = GameObject.Find("World").GetComponent<WorldGen>().ySize;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, distanceMeter.transform.position);
        directionalLight.color = Color.Lerp(Color.white, Color.black, distance / (mapEnd / 4));
    }
}
