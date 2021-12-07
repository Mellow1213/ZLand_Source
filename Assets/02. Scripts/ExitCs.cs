using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCs : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Route1" || collision.gameObject.tag == "Route2")
            collision.gameObject.SetActive(false);
    }
}
