using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject P1;
    

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(P1.GetComponent<Transform>().position.x, P1.GetComponent<Transform>().position.y - .09f, P1.GetComponent<Transform>().position.z - .13f);
    }
}
