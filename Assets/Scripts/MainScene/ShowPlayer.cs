using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShowPlayer : MonoBehaviour
{
    Vector3 TargetPosition;
    Transform PlayerTransform;
    NavMeshAgent Agent;
    Animator Anim;
    public bool showEnd = false;
    public bool Show = false;
    public GameObject AnimPlayer, Camera;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        PlayerTransform = GetComponent<Transform>();
        Anim = AnimPlayer.GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(Show);
        if (Show)
            PlayerFront();
        else
            PlayerBack();
    }

    public void PlayerFront()
    {
        TargetPosition = new Vector3(14.7f, 0.05493499f, 15.8f);
        Agent.SetDestination(TargetPosition);
        PlayerTransform.localEulerAngles = new Vector3(0.0f, PlayerTransform.rotation.y, PlayerTransform.rotation.z);
        PlayerTransform.LookAt(TargetPosition);
        if (PlayerTransform.position.x != 14.79333f && PlayerTransform.position.z != 15.61333f && PlayerTransform.position.y != 0.07042176f)
        {
            Anim.SetBool("isRun", true);
        }
        else
        {
            Anim.SetBool("isRun", false);
            showEnd = true;
        }
    }

    public void PlayerBack()
    {
        TargetPosition = new Vector3(13.63f, 0.065f, 12.706f);
        Agent.SetDestination(TargetPosition);
        PlayerTransform.localEulerAngles = new Vector3(0.0f, PlayerTransform.rotation.y, PlayerTransform.rotation.z);
        PlayerTransform.LookAt(TargetPosition);
        if (PlayerTransform.position.x != 13.63f && PlayerTransform.position.z != 12.706f && PlayerTransform.position.y != 0.065f)
        {
            Anim.SetBool("isRun", true);
        }
        else
        {
            Anim.SetBool("isRun", false);
        }
    }
}
