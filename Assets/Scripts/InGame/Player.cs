using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    float hAxis;
    float vAxis;
    public float Speed = 15.0f;
    public GameObject Camera;
    bool wDown;
    bool jDown;
    bool cDown;

    bool isJump;
    bool isDodge = false;
    bool isTPS = true;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Animator anim;
    Rigidbody rigid;
    public PhotonView PV;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!PV.IsMine)
            return;
            Move();
            GetInput();
            Jump();
            Dodge();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        cDown = Input.GetKeyDown(KeyCode.C);
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        if (isDodge)
            moveVec = dodgeVec;
        Speed = 15.0f;
        //transform.position += moveVec * Speed * (wDown ? 1.5f : 0.8f) * Time.deltaTime;
        transform.Translate(moveVec * Speed * (wDown ? 1.7f : 0.8f) * Time.deltaTime);

        anim.SetBool("isWalk", moveVec != Vector3.zero);
        anim.SetBool("isRun", wDown);
    }

    void Jump()
    {
        if (jDown && !isJump && !isDodge)
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge()
    {
        if (cDown && !isJump && !isDodge)
        {
            dodgeVec = moveVec;
            Speed *= 1.5f;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.5f); 
        }
    }

    void DodgeOut()
    {
        Speed *= 0.5f;
        isDodge = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }

}
