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
        player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        if (Vector3.Distance(player.transform.position, transform.position) <= 10f)
            canLoot = true;
        else
            canLoot = false;

        if(canLoot && Input.GetKeyDown(KeyCode.Q) && isSee())
        {
            if (!isHandle)
                Loot();
            else
                UnLoot();
        }
    }

    void Loot()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isHandle = true;
        transform.SetParent(player.transform);
    }

    void UnLoot()
    {
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
