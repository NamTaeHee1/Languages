using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        transform.position = new Vector3(Target.gameObject.transform.position.x, 
            Target.gameObject.transform.position.y + 6, Target.gameObject.transform.position.z - 15);
    }
}
