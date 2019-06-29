using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerControl : MonoBehaviour
{
    public GameObject P1;
    public TextMeshProUGUI Score;
    public GameObject level;
    public GameObject GameOverPanel;
    public float SPD = 50;
    Rigidbody pRB;
    Transform startPos;

    bool GameOver = false;

    void Start()
    {
        pRB=GetComponent<Rigidbody>();
        //startPos.position = new Vector3(0, 3.5f, 4);
        //startPos.rotation = Quaternion.Euler(new Vector3(-90, 0f, 0));

    }


    void Update()
    {
        //Debug.Log(startPos.position);

    }

    private void FixedUpdate()
    {
        if (GameOver)
        {
            GameOverPanel.SetActive(true);

        }
        else
        {
            if (transform.position.z > 200 * (StaticVars.Count + 1))
            {
                StaticVars.Count++;
            }
            Score.text = (StaticVars.Count * 100).ToString();
            GameOverPanel.SetActive(false);

            
        }
        Debug.Log(GameOver);
        MovePlayer();
    }

    public void Restart()
    {
        Debug.Log("RESET");

        Physics.gravity = new Vector3(0, -9.81f, 0);

        //reset level
        StaticVars.Count = 0;

        //reset player
        this.transform.position = new Vector3(0, 3.5f, 4);
        this.transform.rotation = Quaternion.Euler(new Vector3(-90, 0f, 0));
        P1.GetComponent<Rigidbody>().useGravity = false;
        pRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        //reset score
        Score.text = "0";
        
        GameOver = false;
    }

    void MovePlayer()
    {
        if (!GameOver)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //transform.Translate(new Vector3(SPD*Time.deltaTime, 0, 0));
                pRB.AddForce(-transform.right * SPD);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //transform.Translate(new Vector3(SPD*Time.deltaTime, 0, 0));
                pRB.AddForce(transform.right * SPD);
            }
            pRB.AddForce(new Vector3(0,0,800+StaticVars.Count*25));

        }

        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -6.4f, 6.4f);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            GameOver = true;
            StaticVars.Count++;
            this.GetComponent<Rigidbody>().useGravity = true;
            pRB.constraints = RigidbodyConstraints.None;
            Physics.gravity = new Vector3(0, 10.81f, 0);
            pRB.AddTorque(0, 0, 25f, ForceMode.Acceleration);
        }
    }

}
