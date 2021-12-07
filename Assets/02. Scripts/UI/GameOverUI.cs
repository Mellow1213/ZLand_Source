using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.health == 0)
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnClickRestart()
    {
        Debug.Log("재시작");
        SceneManager.LoadScene("In_game_UI"); //씬 전환
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
