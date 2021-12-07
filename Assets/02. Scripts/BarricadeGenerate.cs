using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeGenerate : MonoBehaviour
{

    public GameObject prefab;
    public GameObject f;
    int barriCount = 0;
    int barriCountMax = 2;
    EventManager score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("PlayerEvent").GetComponent<EventManager>();

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
        if (score.score > 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            GameObject barri = Instantiate(prefab) as GameObject;
            barri.transform.position = player.transform.position;
            barriCount++;
            score.score--;
        }
    }
}
