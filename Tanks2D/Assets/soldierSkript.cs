using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierSkript : MonoBehaviour {
    //Soldier sold;
    Animator  anim;
    bool dzaxic;
    float speed = 0.03f; 
    bool inPos;
    public Sprite ajiHamar;
    
	// Use this for initialization
	void Start () 
    {
        Sprite nkar=gameObject.GetComponent<SpriteRenderer>().sprite;
        if (transform.position.x < 0)
        {
            dzaxic = true;
        }
        else
        {
            dzaxic = false;
            nkar =ajiHamar;

        }
        anim =gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.x > 18 || transform.position.x < -18)
        {
            Manager.manager.SoliderN--;
            Destroy(gameObject);
        }
        if (transform.position.y < Manager.manager.tank.position.y + 0.7f && transform.position.y > Manager.manager.tank.position.y - 1.5f)
        {
               GnumaAraj();
        }
        else
        {
            GnumaHet();
        }
        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.name == "Tank")
        {
            Manager.manager.paytel.Play();
            gameObject.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            gameObject.transform.GetChild(0).parent = Manager.manager.tank;
            Manager.manager.life -= 10;
            Manager.manager.SoliderN--;
            Destroy(gameObject);
        }
    }

    void Kangnuma()
    {
        if (dzaxic)
        {
            transform.Translate(0, 0, 0);
            anim.SetBool("vaziDzaxic", false);
        }

        if (!dzaxic)
        {
            transform.Translate(0, 0, 0);
            anim.SetBool("vaziAjic", false);
        }
    }

    void GnumaAraj()
    {
        if (dzaxic)
        {
            transform.Translate(speed, 0, 0);
            anim.SetBool("vaziDzaxic", true);
        }

        if (!dzaxic)
        {
            transform.Translate(-speed, 0, 0);
            anim.SetBool("vaziAjic", true);
        }
    }

    void GnumaHet()
    {
        if (dzaxic)
        {
            transform.Translate(-speed, 0, 0);
            anim.SetBool("vaziDzaxic", false);
            anim.SetBool("dzaxicAj", true);
            anim.SetBool("vaziAjic", true);


        }

        if (!dzaxic)
        {
            transform.Translate(speed, 0, 0);
            anim.SetBool("vaziAjic", false);
            anim.SetBool("ajicDzax", true);
            anim.SetBool("vaziDzaxic", true);
        }
    }
}



