using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flmScript : MonoBehaviour {
    GameObject par;

	// Use this for initialization
	void Start () {
        par = GameObject.Find("flm(Clone)").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0 , 0.05f);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("mtav1");

        if (col.transform.name == "Tank")
        {
            print("mtav2");
            par.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            par.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            par.transform.GetChild(0).GetComponent<CapsuleCollider2D>().enabled = false;
            par.transform.GetChild(1).GetComponent<Animator>().enabled = true;
            par.transform.GetChild(1).transform.parent = Manager.manager.tank;
            Manager.manager.life -= 10;
        }
    }
}
