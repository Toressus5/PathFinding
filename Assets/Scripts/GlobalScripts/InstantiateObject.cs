using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public void InstantiateWantedObject(GameObject wantedObject, Vector3 position)
    {
        Instantiate(wantedObject, position, Quaternion.identity);
        return;
    }
}
