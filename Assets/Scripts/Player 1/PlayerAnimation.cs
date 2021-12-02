using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator ani;
    
    private int bullet;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            ani.SetBool("run", true);
        else
            ani.SetBool("run", false);
        GameObject g = transform.parent.gameObject;
        bullet = g.GetComponent<PlayerFire>().bullet;
        if (Input.GetMouseButton(0) && bullet!=0)
            ani.SetTrigger("S");
        else
            ani.ResetTrigger("S");

    }
}
