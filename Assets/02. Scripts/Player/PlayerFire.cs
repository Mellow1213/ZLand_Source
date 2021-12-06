using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletSound;
    public GameObject reloadSound;
    public GameObject bulletEffect;
    public float damage;

    public GameObject firePos;
    Ray ray;
    Transform start;
    ParticleSystem ps;
    [HideInInspector] public float fireCooltime; // �߻� ���� ������ (= ����ӵ�)
    [HideInInspector] public int bullet; // ���� �Ѿ� ����
    bool out_of_bullet; // ���� �ʿ伺 �Ǵ�


    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponentInChildren<ParticleSystem>();
        out_of_bullet = false;
        bullet = 30;
        fireCooltime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        start = firePos.transform;
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
                GetComponent<AudioSource>().Play();
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
            GameObject sound = Instantiate(bulletSound);

            //�Ѿ� �߻� ��ũ��Ʈ : ���� ��ź �̹���
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                GameObject gunEffect = Instantiate(bulletEffect);
                gunEffect.transform.position = hitInfo.point;
                gunEffect.transform.forward = hitInfo.normal;
                ps.Play();
                // �Ѿ� ���� �� ü�� ����
                // �Ѿ� ���� ������Ʈ�� Health ������Ʈ ���� �ÿ��� �۵�
                if(hitInfo.transform.gameObject.GetComponent<Health>() != null)
                    hitInfo.transform.gameObject.GetComponent<Health>().health-=damage;

                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
            }
        }

    }
   
}
