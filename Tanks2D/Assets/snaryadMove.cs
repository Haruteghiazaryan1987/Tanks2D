using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snaryadMove : MonoBehaviour
{
    AudioSource krakel;
    // Start is called before the first frame update
    void Start()
    {
        krakel = GetComponent<AudioSource>();
        krakel.Play();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate( 0,0.5f, 0);
        Manager.manager.TesadDursDest(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.name == "car(Clone)")
        {            
            Manager.manager.CarN--;
            Manager.manager.destroyedCar++;
            col.gameObject.GetComponent<Animator>().SetBool("oncol", true);
            col.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy( col.gameObject.GetComponent<Collider2D>());
            Destroy(gameObject);
        }

        if (col.gameObject.transform.name == "bashnya(Clone)")
        {
            Manager.manager.BashnyaN--;
            Manager.manager.destroyedBashnya++;
            col.gameObject.transform.GetChild(0).GetComponent<Animator>().enabled=true;
            col.gameObject.transform.GetChild(1).GetComponent<Animator>().enabled=true;
            col.gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Destroy(gameObject);
        }
    }
}
