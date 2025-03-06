using UnityEngine;
using UnityEngine.AI;

public class ZombieChase : MonoBehaviour
{
    public Transform target;
    public float chaseRadius = 20f;
    private NavMeshAgent agent;
    private Animator anim;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target is not null)
        {
            if (Vector3.Distance(transform.position, target.position) <= chaseRadius)
            {
                agent.isStopped = false;
                agent.SetDestination(target.position);
                anim.SetBool("isChasing", true);
            }
            else
            {
                agent.isStopped = true;
                anim.SetBool("isChasing", false);
            }
        }
    }
}
