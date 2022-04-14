using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float horsePower = 20;
    public readonly float turnSpeed = 42;
    public  float hip;
    public float vip;
    private Rigidbody playerRb;
    public GameObject massOC;

    [SerializeField] float speed;
    public TextMeshProUGUI showSpeed;

    [SerializeField] float rpm;
    public TextMeshProUGUI showRpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int couterOW = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("myBlueCar").GetComponent<Rigidbody>();
        playerRb.centerOfMass = massOC.transform.position;
    }

    // Update is called once per frame
  
    void FixedUpdate()
    {
        hip = Input.GetAxis("Horizontal");
        vip = Input.GetAxis("Vertical");
        //This is move code for our car
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * vip);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * hip);

        if (isOntheG() == true)
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * vip, ForceMode.Impulse);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * hip);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            showSpeed.SetText("Speed: " + speed + "mph");

            rpm = Mathf.RoundToInt((speed % 30) * 40);
            showRpm.SetText("RPM: " + rpm);
        }
    }

    bool isOntheG()
    {
        couterOW = 0;

        foreach(WheelCollider w in allWheels)
        {
            if (w.isGrounded)
            {
                couterOW++;
            }
        }

        if(couterOW > 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
