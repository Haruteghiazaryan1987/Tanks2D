using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank;
    Vector3 tankOldPos;
    // Start is called before the first frame update
    void Start()
    {
        tankOldPos = tank.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( 0,tank.position.y - tankOldPos.y, 0);
        tankOldPos = tank.position;
    }
}
