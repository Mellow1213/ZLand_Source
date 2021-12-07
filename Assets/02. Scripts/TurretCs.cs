using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCs : MonoBehaviour
{
    

    public Transform head;
    public bool headRotate;
    public float distance;
    public float rotspeed = 5;

    public GameObject player;
 // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.DrawLine(head.transform.position, player.transform.position, Color.yellow);
        if (distance < 20)
        {
            headRotate = true;
        }
        else
        {
            headRotate = false;
        }
        if (headRotate)
        {
            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, Quaternion.LookRotation(player.transform.position - head.transform.position), rotspeed * Time.deltaTime);
        }


    }
}
