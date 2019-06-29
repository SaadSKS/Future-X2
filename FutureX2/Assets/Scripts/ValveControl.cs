using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveControl : MonoBehaviour
{
    public Animator anim1;
    public GameObject P1;
    private float DistanceMin=100;

    private Vector3 playerPos = new Vector3(0,0,0);

    void Start()
    {
        anim1 = GetComponent<Animator>();
        P1=GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = P1.GetComponent<Transform>().position;
        if(Vector3.Distance(playerPos, this.transform.position) < DistanceMin)
        {
            anim1.SetBool("InRange", true);
        }
        else
        {
            anim1.SetBool("InRange", false);
        }
        if (playerPos.z > (this.transform.position.z+5))
        {
            gameObject.SetActive(false);
        }
    }
}
