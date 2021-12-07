using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttt : MonoBehaviour
{
    public GameObject player;

    Vector3 v;
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Soldier_demo");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        Vector3 v = player.transform.position - transform.position;
        v.y = 0;
        cc = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
        
        Debug.Log(v);
        cc.Move(v * Time.deltaTime / 2);
    }
}

