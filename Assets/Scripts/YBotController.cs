using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class YBotController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    int isWalkingHash;
    int velocityZHash;
    int velocityXHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        isWalkingHash = Animator.StringToHash("isWalking");
        velocityXHash = Animator.StringToHash("velocityX");
        velocityZHash = Animator.StringToHash("velocityZ");



    }

    private void Update()
    {
        Vector3 velocity = agent.velocity;
        bool isMoving = agent.velocity.magnitude > 0.01f && agent.remainingDistance > agent.radius;

        animator.SetBool("isWalking", isMoving);

        velocity = transform.InverseTransformVector(velocity);

        animator.SetFloat("velocityXHash", velocity.x);
        animator.SetFloat("velocityZHash", velocity.z);


    }
}