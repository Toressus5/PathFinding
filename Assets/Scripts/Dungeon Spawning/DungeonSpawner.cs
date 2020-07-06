using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public int doorPosition;
    private int templateNumber;
    private int maxNumber;

    private RoomTemplates templates;
    private RandomNumberGenerator randNumber;
    private InstantiateObject instantiateWantedObject;

    private bool spawned = false;
    

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        randNumber = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RandomNumberGenerator>();
        instantiateWantedObject = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InstantiateObject>();
        
        Invoke("Spawn",0.1f);
    }
    
    void Spawn()
    {
        if (spawned == false)
        {
            if (doorPosition == 1)
            {
                maxNumber = MaxNumberCount(templates.bottomDoorRooms);
                templateNumber = randNumber.RandomNumber(0, maxNumber);
                instantiateWantedObject.InstantiateWantedObject(templates.bottomDoorRooms[templateNumber], transform.position);
            }
            else if (doorPosition == 2)
            {
                maxNumber = MaxNumberCount(templates.topDoorRooms);
                templateNumber = randNumber.RandomNumber(0, maxNumber);
                instantiateWantedObject.InstantiateWantedObject(templates.topDoorRooms[templateNumber], transform.position);
            }
            else if (doorPosition == 3)
            {
                maxNumber = MaxNumberCount(templates.leftDoorRooms);
                templateNumber = randNumber.RandomNumber(0, maxNumber);
                instantiateWantedObject.InstantiateWantedObject(templates.leftDoorRooms[templateNumber], transform.position);
            }
            else if (doorPosition == 4)
            {
                maxNumber = MaxNumberCount(templates.rightDoorRooms);
                templateNumber = randNumber.RandomNumber(0, maxNumber);
                instantiateWantedObject.InstantiateWantedObject(templates.rightDoorRooms[templateNumber], transform.position);
            }
            spawned = true;
        }
        
    }

    private int MaxNumberCount(GameObject[] template)
    {
        int numberOfTemplates = 0;
        for (int i = 0; i < template.Length; i++)
        {
            numberOfTemplates++;
        }
        return numberOfTemplates;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<DungeonSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }

}
