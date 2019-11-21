using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour

{
    Animator anim;
    public GameObject snaryad;
    float speed = 0;
    Transform snaryadPoint;
    // Start is called before the first frame update
    void Start()
    {
        anim= gameObject.transform.GetChild(0).GetComponent<Animator>();
        snaryadPoint = transform.GetChild(0).GetChild(0).GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Manager.snaryadN != 0)
        {
            anim.SetBool("bashnyaSharjel", true);
            GameObject ns = Instantiate(snaryad);
            ns.transform.position = new Vector2(snaryadPoint.position.x, snaryadPoint.position.y);
            ns.transform.parent = snaryadPoint;
            ns.transform.localEulerAngles = new Vector3(0, 0, 90);
            ns.transform.parent = null;
            Manager.snaryadN--;
        }
        else
        {
            anim.SetBool("bashnyaSharjel", false);
        }

        speed=Input.GetAxis("Vertical")/35;
        transform.Translate(-speed, 0, 0);
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal"));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.name != "flm(Clone)/flames")
        {
           // Destroy(col.gameObject);
        }
    }
    void BashnyanSharjel()
    {

    }
}
