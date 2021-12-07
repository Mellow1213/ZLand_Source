using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    int Route1;
    int Route2;
    bool dontDestroy;

    public int score;
    public int kill;
    float finalTimer;

    public GameObject Wave;

    public bool gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
        finalTimer = 0;
        score = 0;
        kill = 0;
        dontDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursors();

        MaterialManage();
    }

    void Cursors()
    {

        Cursor.lockState = CursorLockMode.Confined;
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
        }
    }

    void MaterialManage()
    {
        Route1 = GameObject.FindGameObjectsWithTag("Route1").Length;
        Route2 = GameObject.FindGameObjectsWithTag("Route2").Length;
        if ((Route1 != 6 || Route2 != 6) && !dontDestroy)
            RouteManage();

        if (dontDestroy)
        {
            if (Route2 == Route1)
            {
                Wave.SetActive(true);
                finalTimer += Time.deltaTime;
                gameEnd = (finalTimer >= 60);
                Debug.Log("finalTimer : " + finalTimer + ", gameEnd : " + gameEnd);
            }
        }
    }

    void RouteManage()
    {
        if (Route1 != 6)
            for (int i = 0; i < Route2; i++)
                Destroy(GameObject.FindGameObjectsWithTag("Route2")[i]);
        if (Route2 != 6)
            for (int i = 0; i < Route1; i++)
                Destroy(GameObject.FindGameObjectsWithTag("Route1")[i]);
        dontDestroy = true;
    }
}
