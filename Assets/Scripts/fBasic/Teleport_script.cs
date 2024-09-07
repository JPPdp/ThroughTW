using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // create accessible object
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
