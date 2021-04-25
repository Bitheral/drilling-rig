using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;
    PlayerInventory playerInventory;

    public GameObject dirtParticles;
    public GameObject stoneParticles;

    public AudioSource drillingSound;

    public float speed = 1;

    private Vector3 drillLimit_up;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerInventory = player.GetComponent<PlayerInventory>();

        drillingSound = Camera.main.GetComponent<AudioSource>();

        drillLimit_up = transform.position;
        drillLimit_up.y = 4.1f;

        Vector3 drillPos = transform.position;

        if (drillPos.y > drillLimit_up.y)
        {
            drillPos.y = drillLimit_up.y;
        }

        transform.position = drillPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 drillPos = transform.position;

        if(drillPos.y > drillLimit_up.y)
        {
            drillPos.y = drillLimit_up.y;
        }

        transform.position = drillPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Block>())
        {
            if(other.gameObject.GetComponent<Block>().breakable)
            {
                drillingSound.Play();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Bedrock"))
        {
            playerController.setDrilling(false);
        }
        if(other.GetComponent<Block>())
        {
            if (other.GetComponent<Block>().breakable)
            {
                string goName = other.gameObject.name;
                playerController.setDrilling(true);
                other.GetComponent<Block>().Damage(speed);
                if (goName.Contains("Grass") || goName.Contains("Dirt"))
                {
                    dirtParticles.GetComponent<ParticleSystem>().Play();
                }
                else
                {
                    stoneParticles.GetComponent<ParticleSystem>().Play();
                }
            }
            
        }

        if (other.gameObject.GetComponent<Block>().breakable)
        {
            if (other.gameObject.GetComponent<Block>().isDestroyed || !playerController.isDrilling)
            {
                if (other.gameObject.GetComponent<Block>())
                {
                    string goName = other.gameObject.name;
                    if (goName.Contains("Grass") || goName.Contains("Dirt"))
                    {
                        dirtParticles.GetComponent<ParticleSystem>().Stop();
                        playerInventory.items[0].weight += Random.Range(0.5f, 1);
                    }
                    else
                    {
                        if (goName.Contains("Stone"))
                        {
                            playerInventory.items[1].weight += Random.Range(1, 5);
                        }
                        else if (goName.Contains("Copper"))
                        {
                            playerInventory.items[2].weight += (Random.Range(1, 5) + Random.Range(0.8f, 1.2f));
                        }
                        else if (goName.Contains("Iron"))
                        {
                            playerInventory.items[3].weight += (Random.Range(1, 5) + Random.Range(1, 2));
                        }
                        else if (goName.Contains("Gold"))
                        {
                            playerInventory.items[2].weight += (Random.Range(1, 5) + Random.Range(1.5f, 2f));
                        }

                        stoneParticles.GetComponent<ParticleSystem>().Stop();
                    }
                    playerController.setDrilling(false);
                    other.enabled = false;
                    other.gameObject.SetActive(false);
                    drillingSound.Stop();
                }
            }
        } else
        {
            playerController.setDrilling(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Block>().breakable)
        {
            if (other.gameObject.GetComponent<Block>().isDestroyed || !playerController.isDrilling)
            {
                if (other.gameObject.GetComponent<Block>())
                {
                    string goName = other.gameObject.name;
                    if (goName.Contains("Grass") || goName.Contains("Dirt"))
                    {
                        dirtParticles.GetComponent<ParticleSystem>().Stop();
                        playerInventory.items[0].weight += Random.Range(0.5f, 1);
                    }
                    else
                    {
                        if (goName.Contains("Stone"))
                        {
                            playerInventory.items[1].weight += Random.Range(1, 5);
                        }
                        else if (goName.Contains("Copper"))
                        {
                            playerInventory.items[2].weight += (Random.Range(1, 5) + Random.Range(0.8f, 1.2f));
                        }
                        else if (goName.Contains("Iron"))
                        {
                            playerInventory.items[3].weight += (Random.Range(1, 5) + Random.Range(1, 2));
                        }
                        else if (goName.Contains("Gold"))
                        {
                            playerInventory.items[2].weight += (Random.Range(1, 5) + Random.Range(1.5f, 2f));
                        }

                        stoneParticles.GetComponent<ParticleSystem>().Stop();
                    }
                    playerController.setDrilling(false);
                    other.enabled = false;
                    other.gameObject.SetActive(false);
                    drillingSound.Stop();
                }
            }
        }

        playerController.setDrilling(false);
        drillingSound.Stop();
    }
}
