using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashnyaScript : MonoBehaviour {
    GameObject gyula;int c = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (gyula != null)
            gyula.transform.Translate(0, 0, 0.05f);

        if ((Manager.manager.tank.position.y - transform.position.y) > 15)
        {
            if (gameObject.GetComponent<CircleCollider2D>() != null)
                Manager.manager.BashnyaN--;
            print("mtav if");
            Destroy(gameObject);
        }
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.transform.name == "Tank")
        {
            gyula=(GameObject) Instantiate(Resources.Load("flm"),new Vector2(2,0),Quaternion.identity);
            if (transform.position.x > 0)
                gyula.transform.position = new Vector2(transform.position.x - 0.45f, transform.position.y + 0.4f);
            else
                gyula.transform.position = new Vector2(transform.position.x + 0.45f, transform.position.y + 0.4f);
            gyula.transform.LookAt(Manager.manager.tank);
            

        }

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        
        
        if (col.transform.name == "snaryadSP 1(Clone)")
        {
            c++;
            print("mtav ="+c);
            print(Manager.manager.destroyedBashnya);
            Manager.manager.paytel.Play();
            gameObject.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

        }

    }
}
