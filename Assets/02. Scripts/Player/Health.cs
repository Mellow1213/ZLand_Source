using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    GameObject Ev;

    // Start is called before the first frame update
    void Start()
    {
        Ev = GameObject.Find("PlayerEvent");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Ev.GetComponent<EventManager>().kill++;
            Ev.GetComponent<EventManager>().score++; 
        }
        if (gameObject.name == "Player")
            Debug.Log(health);
    }
}
