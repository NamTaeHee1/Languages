using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Transform target;
    public Rigidbody myRigid;
    public float dist = 4f;

    [SerializeField]
    private float lookSensitivity;

    private float CameraX = 0.0f;
    private float CameraY = 0.0f;
    private float CharacterX = 0.0f;
    private float CharacterY = 0.0f;
    private float rotSpeed = 80.0f;

    public float CameraYMinLimit;
    public float CameraYMaxLimit;
    public float CharacterYMinLimit;
    public float CharacterYMaxLimit;

    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;


    void Update()
    {
        CameraRotation();
        CharacterRotation();
    }

    public void CameraRotation()
    {
        CameraX += Input.GetAxis("Mouse X") * xSpeed * 0.015f;
        CameraY += Input.GetAxis("Mouse Y") * ySpeed * 0.015f;

        CameraY = Mathf.Clamp(CameraY, CameraYMinLimit, CameraYMaxLimit);

        Quaternion rotation = Quaternion.Euler(-CameraY, CameraX, 0);
        Vector3 position = rotation * new Vector3(0, 0.9f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

        transform.rotation = rotation;
    }

    public void CharacterRotation()
    {
        Debug.Log("fuew");
        CharacterX += Input.GetAxis("Mouse X") * xSpeed * 0.015f;

        Quaternion rotation = Quaternion.Euler(0, CharacterX, 0);

        target.transform.eulerAngles = new Vector3(0, CharacterX, 0);
    }
}
