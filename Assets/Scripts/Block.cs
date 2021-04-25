using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update

    public float density = 100;
    public bool isDestroyed = false;
    public bool breakable = true;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(density <= 0)
        {
            isDestroyed = true;
        }
    }

    public void Damage(float drillSpeed)
    {
        if (breakable)
        {
            density -= drillSpeed;
        }
    }
}
