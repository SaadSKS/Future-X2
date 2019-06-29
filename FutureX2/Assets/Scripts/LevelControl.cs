using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject P1;
    private float DistanceMin = 600;
    private Vector3 playerPos = new Vector3(0, 0, 0);


    void Start()
    {
        P1 = GameObject.FindGameObjectWithTag("Player");

    }


    void Update()
    {

        playerPos = P1.GetComponent<Transform>().position;
        if (Vector3.Distance(playerPos, this.transform.position) < DistanceMin)
        {

        }
        else
        {

        }
        if (playerPos.z > (this.transform.position.z + 5))
        {
            gameObject.SetActive(false);
        }

    }
}
