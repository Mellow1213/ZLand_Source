using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCs : MonoBehaviour
{
    GameObject player;

    bool canLoot;
    bool isHandle;
    // Start is called before the first frame update
    void Start()
    {
        isHandle = false;
        player = GameObject.Find("Soldier_demo");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 7f)
            canLoot = true;
        else
            canLoot = false;

        if(canLoot && Input.GetKeyDown(KeyCode.Q))
        {
            if (!isHandle)
                Loot();
            else
                UnLoot();
        }
    }

    void Loot()
    {
        isHandle = true;
        transform.SetParent(player.transform);
    }

    void UnLoot()
    {
        isHandle = false;
        transform.parent = null;
    }

}
