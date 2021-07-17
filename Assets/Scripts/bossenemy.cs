using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class bossenemy : MonoBehaviour
{
    Transform target;

    NavMeshAgent agent;
    Animator anim;

    public float bosshealthpt = 100f;
    

    // Start is called before the first frame update
    void Start()
    {
        bosshealthpt = 100f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(bosshealthpt);
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > 1.5)
        {
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            anim.SetBool("iswalking", true);
            anim.SetBool("isattacking", false);
        }
        else
        {
            /*agent.updatePosition = false;*/
            anim.SetBool("iswalking", false);
            anim.SetBool("isattacking", true);
        }
    }



    public void damage(float amount)
    {
        
        bosshealthpt -= amount;
        if (bosshealthpt <= 0f)
        {
            die();
        }

    }
    void die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("win");

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerhealth -= 30;
            Debug.Log("hittt");
        }
    }
}
