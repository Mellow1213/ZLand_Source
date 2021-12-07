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
        // �׳� ȭ�鿡 UI�� Ȱ��ȭ �Ǿ����� �� 
        // timeScale�� 0���� �ϰ� ��Ȱ��ȭ�� �� 1�� �ϸ� �� �� ���ƿ�
        // UI ������ �ǵ帮�� �ָ��ؼ� �ּ��� �޾Ƴ����ϴ�
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
