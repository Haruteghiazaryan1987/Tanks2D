using UnityEngine;
using UnityEngine.UIElements;

public class zagrScen : MonoBehaviour {
    public Slider slayder;
    public float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer>1 && timer<2)
            slayder.value=25;
        if(timer>2 && timer<3)
            slayder.value=60;
        if (timer > 3)
        {
            slayder.value = 100;
            Application.LoadLevel(1);
        }
	}
}
