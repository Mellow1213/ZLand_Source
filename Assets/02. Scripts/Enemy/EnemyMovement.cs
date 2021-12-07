using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    UnityEngine.AI.NavMeshAgent agent;
    public float damage;
    public float attack_cooltime;
    float timer;

    bool isAttack;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = 0;
        ani = GetComponent<Animator>();
        isAttack = false;

        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (target.gameObject.tag == "Player")
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 3.5f)
            {
                agent.destination = target.transform.position;
            }
            else
            {
                agent.destination = transform.position;
            }

            if (gameObject.name != "Skull")
            {
                if (Vector3.Distance(transform.position, target.transform.position) < 5f)
                {
                    ani.SetBool("isAttack", true);
                    Attack();
                }
                else
                    ani.SetBool("isAttack", false);

            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) < 5f)
                {
                    GetComponent<Animation>().Play("attack");
                    Attack();
                }
                else
                    GetComponent<Animation>().Play("run");

            }

        }
        void Attack()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                target.gameObject.GetComponent<Health>().health -= damage;
                timer = attack_cooltime;
                agent.enabled = false;
            }

        }

    }
}
