using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDrilling = false;
    private float speed = 1;
    private float maxHeight = 4f;

    public bool drillAtTop;
    public GameObject drill;
    private Vector3 drillPos;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = new Vector3(drill.transform.position.x, 4f, drill.transform.position.z);
        drill.transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        drillPos = drill.transform.position;
        drillAtTop = drillPos.y > maxHeight;

        float translationY = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        translationY *= Time.deltaTime;

        if (drillAtTop) {
            Debug.Log("Out of bounds");
            drillPos.y = maxHeight;
            drill.transform.position = drillPos;
        }
        else {
            drill.transform.Translate(0, 0, -translationY);
        }


        // Make it move 10 meters per second instead of 10 meters per frame...
        translationX *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(-translationX, 0, 0);
    }
}
