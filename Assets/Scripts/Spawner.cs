using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject diamond;

    void Start()
    {
        GameObject diam = Instantiate(diamond, transform.position, transform.rotation);
    }
}
