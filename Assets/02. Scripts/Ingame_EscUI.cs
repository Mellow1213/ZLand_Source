using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingame_EscUI : MonoBehaviour
{
    GameObject tFlag;

    // Start is called before the first frame update
    void Start()
    {
        tFlag = GameObject.Find("Panel");
        tFlag.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            tFlag.gameObject.SetActive(true);
        }
    }

    public void OnClickTurret()
    {
        Debug.Log("�ͷ�");
        tFlag.gameObject.SetActive(true);
    }

    public void OnClickUpgrade()
    {
        Debug.Log("���׷��̵�");
    }

    public void OnClickBack()
    {
        Debug.Log("x");
        tFlag.gameObject.SetActive(false);
    }

    public void OnClickMain()
    {
        Debug.Log("����ȭ������");
        SceneManager.LoadScene("Main_Title");
    }
}
