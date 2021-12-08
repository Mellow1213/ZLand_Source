using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    bool paused = false;

    Health health;
    EventManager end;

    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
        health = GameObject.Find("Player").GetComponent<Health>();
        end = GameObject.Find("PlayerEvent").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
        }

        if (health.health <= 0)
        {
            paused = false;
        }

        if (end.gameEnd == true) {
            paused = true;
        }

        if (paused) {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused) {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

        public void OnClickMain()
    {
        Debug.Log("메인화면으로");
        SceneManager.LoadScene("Main_Title");
    }
}
