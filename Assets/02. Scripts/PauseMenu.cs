using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 그냥 화면에 UI가 활성화 되어있을 때 
        // timeScale을 0으로 하고 비활성화일 때 1로 하면 될 것 같아요
        // UI 관련은 건드리기 애매해서 주석만 달아놓습니당
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
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
}
