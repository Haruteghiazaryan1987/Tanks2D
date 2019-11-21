using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(0, -0.02f, 0);
        if ((Manager.manager.tank.position - transform.position).magnitude > 30)
        {
            if(gameObject.GetComponent<Collider2D>()!=null)
            Manager.manager.CarN--;
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.name == "Tank")
        {
            Manager.manager.paytel.Play();
            Manager.manager.life -= 10;
            Manager.manager.CarN--;
            Manager.manager.destroyedCar++;
            gameObject.GetComponent<Animator>().SetBool("oncol", true);
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(gameObject.GetComponent<Collider2D>());
            //Destroy(gameObject);
        }
        if(col.gameObject. transform.name=="snaryadSP 1(Clone)")
            Manager.manager.paytel.Play();
    }
}
