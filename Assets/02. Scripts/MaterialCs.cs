using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCs : MonoBehaviour
{
    GameObject player;
    GameObject realPlayer;
    bool canLoot;
    bool isHandle;

    Health health;

    // Start is called before the first frame update
    void Start()
    {
        isHandle = false;
        player = GameObject.Find("Main Camera");
        realPlayer = GameObject.Find("Player");
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.health > 0)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= 10f)
                canLoot = true;
            else
                canLoot = false;

            if (canLoot && Input.GetKeyDown(KeyCode.Q) && isSee())
            {
                if (!isHandle && !realPlayer.GetComponent<PlayerHandle>().handFull)
                    Loot();
                else
                    UnLoot();
            }
        }
    }

    void Loot()
    {
        realPlayer.GetComponent<PlayerHandle>().handFull = true;
        GetComponent<Rigidbody>().isKinematic = true;
        isHandle = true;
        transform.SetParent(player.transform);
    }

    void UnLoot()
    {
        realPlayer.GetComponent<PlayerHandle>().handFull = false;
        GetComponent<Rigidbody>().isKinematic = false;
        isHandle = false;
        transform.parent = null;
    }

    bool isSee()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        return (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z > 0);
    }
}
