using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // public GameObject bulletSound;
    // public GameObject reloadSound;
    public float damage;

    [HideInInspector] public float fireCooltime; // �߻� ���� ������ (= ����ӵ�)
    [HideInInspector] public int bullet; // ���� �Ѿ� ����
    bool out_of_bullet; // ���� �ʿ伺 �Ǵ�


    // Start is called before the first frame update
    void Start()
    {
        out_of_bullet = false;
        bullet = 30;
        fireCooltime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("bullet = "+bullet);
        //Debug.Log("fireCooltime = " + fireCooltime);
        Shoot();
    }

    // �Ѿ� �߻�
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullet = 0;
        }
        // ���� ��Ŀ����
        if (bullet <= 0)
        {
            if (!out_of_bullet)
            {
                //reloadSound.gameObject.GetComponent<AudioSource>().Play();
                fireCooltime = 1.5f;
                out_of_bullet = true;
            }
            if (fireCooltime <= 0)
            {
                bullet = 30;
                out_of_bullet = false;
            }
        }

        fireCooltime -= Time.deltaTime; // ������

        // �Ѿ��� �ѹ� �߻�� �� ������ �Ͼ�� ��ũ��Ʈ
        OneShot();
    }

    void OneShot()
    {
        if (Input.GetMouseButton(0) && fireCooltime <= 0f && bullet > 0)
        {
            bullet--;
            fireCooltime = 0.1f;
            //GameObject sound = Instantiate(bulletSound);

            //�Ѿ� �߻� ��ũ��Ʈ : ���� ��ź �̹���
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.transform.position,
                Camera.main.transform.forward, out hitInfo, 300f))
            {
                // �Ѿ� ���� �� ü�� ����
                // �Ѿ� ���� ������Ʈ�� Health ������Ʈ ���� �ÿ��� �۵�
                if(hitInfo.transform.gameObject.GetComponent<Health>() != null)
                    hitInfo.transform.gameObject.GetComponent<Health>().health-=damage;

                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
            }
        }

    }
   
}