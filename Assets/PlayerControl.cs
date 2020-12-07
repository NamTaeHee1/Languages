using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Transform PlayerTransform;
    Vector3 moveVec;
    Animator anim;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerAnimation();
    }
    void FixedUpdate()
    {
        PlayerMoveAndRotate();
    }

    void PlayerMoveAndRotate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool shiftDown = Input.GetKey(KeyCode.LeftShift);

        moveVec = new Vector3(h, 0, v).normalized;

        PlayerTransform.position += moveVec * (shiftDown ? 20.0f : 10.0f) * Time.deltaTime;
        PlayerTransform.LookAt(PlayerTransform.position + moveVec);
    }

    void PlayerAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("isWalk", true);
            if (Input.GetKey(KeyCode.LeftShift))
                anim.SetBool("isRun", true);
            else
                anim.SetBool("isRun", false);
        }
        else
            anim.SetBool("isWalk", false);
    }
}
