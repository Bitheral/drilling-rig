using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDrilling = false;
    public float speed;
    public float speedMultiplier = 0.05f;
    public float maxHeight = 4f;

    public bool drillAtTop;
    public GameObject drillObj;
    private Vector3 drillPos;
    private Drill drill;

    public GameObject DrillLight;
    public GameObject LightSpawner;

    public GameObject mapCamera;
    public bool showMap;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        showMap = false;

        drill = drillObj.GetComponent<Drill>();
        mapCamera = GameObject.FindGameObjectWithTag("MapCam");
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.GetComponent<Pause>().isPaused)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        } else
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            showMap = !showMap;
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(DrillLight, LightSpawner.transform.position, Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.GetComponent<Pause>().isPaused = !canvas.GetComponent<Pause>().isPaused;
        }

        mapCamera.SetActive(showMap);

        float translationY = Input.GetAxis("Vertical");
        float translationX = Input.GetAxis("Horizontal");

        translationY *= Time.deltaTime;


        // Make it move 10 meters per second instead of 10 meters per frame...
        translationX *= Time.deltaTime;
        speed = (GetComponent<PlayerInventory>().currentWeight + GetComponent<Rigidbody>().mass) * translationX;

        // Move translation along the object's z-axis
        if (!isDrilling)
        {
            drill.transform.Translate(0, 0, -translationY);
            transform.Translate(-translationX, 0, 0);
        }
    }

    public void setDrilling(bool state)
    {
        this.isDrilling = state;
    }

    // Constrains a value between a minimum and maximum value.
    //
    // Taken from p5.js
    // https://github.com/processing/p5.js/blob/main/src/math/calculation.js#L111

    float constrain(float value, int low, int high) {
        return Mathf.Max(Mathf.Min(value, high), low);
    }


    // Remaps a number from one range to another
    //
    // Taken from p5.js and modified to fit C#
    // https://github.com/processing/p5.js/blob/main/src/math/calculation.js#L450

    float map(float value, int currentStart, int currentStop, int targetStart, int targetStop, bool withinBounds) {
        float new_value = (value - currentStart) / (currentStop - currentStart) * (targetStop - targetStart) + targetStart;
        if (!withinBounds) return new_value;

        if (targetStart < targetStop) return constrain(new_value, targetStart, targetStop);
        else return constrain(new_value, targetStop, targetStart);
    }
}
