using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = new Vector3(transform.position.x, 3.4f, transform.position.z);
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<CapsuleCollider>().enabled = false;
    }

    private void onTriggerStay(Collider other)
    {
        Debug.Log(other.name + " Drill.cs");
    }
}
