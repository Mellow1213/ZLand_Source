using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W)
            )&& !transform.gameObject.GetComponent<AudioSource>().isPlaying
            &&!player.GetComponent<PlayerMovement>().isJumping)
            transform.gameObject.GetComponent<AudioSource>().Play();

    }
}
