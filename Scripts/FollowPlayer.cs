using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 ov = new Vector3(0, 5.5f, -10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + ov;
    }

}
