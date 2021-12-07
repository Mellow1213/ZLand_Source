using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeGenerate : MonoBehaviour
{

    public GameObject prefab;
    public GameObject f;
    int barriCount = 0;
    int barriCountMax = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        f = GameObject.FindWithTag("barri");
        if (barriCount > barriCountMax) {
            Destroy(f);
            barriCount--;
        }
    }

    public void OnclickBarricade() {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject barri = Instantiate(prefab) as GameObject;
        barri.transform.position = player.transform.position;
        barriCount++;

    }
}
