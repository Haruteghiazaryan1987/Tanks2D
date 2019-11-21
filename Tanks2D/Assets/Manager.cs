using UnityEngine.UIElements;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager manager;
    static public int snaryadN = 30;
    public int destroyedCar;
    public int destroyedBashnya;
    public int scoreCar = 10;
    public int scoreBashnya = 20;
    public int score;
    public Slider slider;
    public float life = 100;
    public Transform tank;

    public GameObject avto;
    public GameObject bashnya;
    public GameObject soldier;

    Vector2 oldPosTank;
    float time;

    public AudioSource paytel;

    void Start()
    {
        paytel = GetComponent<AudioSource>();
        manager = this;
        oldPosTank = tank.position;


    }

    // Update is called once per frame
    void Update()
    {
        print("BashnyaN =  " + BashnyaN);
        if ((Vector2)tank.position == oldPosTank)
        {
            time += Time.deltaTime;
            if ((int)time >= 2)
            {
                SoldierControl();
                oldPosTank = (Vector2)tank.position;
                time = 0;
            }
        }
        else
        {
            time = 0;
            oldPosTank = (Vector2)tank.position;
        }



        if (life <= 0)
        {
            Application.LoadLevel(2);
            life = 1;
        }
        if (BashnyaN < 0)
            BashnyaN = 0;
        if (CarN < 0)
            CarN = 0;
        if (SoliderN < 0)
            SoliderN = 0;
        BashnyaControl();
        CanvasControl();
        CarControl();
    }
    int carN ;
    public int CarN
    {
        get { return carN; }
        set { carN = value; }
    }
    int bashnyaN;
    public int BashnyaN
    {
        get { return bashnyaN; }
        set { bashnyaN = value; }
    }
    int soliderN;
    public int SoliderN
    {
        get { return soliderN; }
        set { soliderN = value; }
    }    
    
    void BashnyaControl()
    {
        float posX = 0;
        int a = Random.Range(0, 2);
        if (a == 0)
            posX = Random.Range(-8, -11);
        else
            posX = Random.Range(8, 11);
        if (BashnyaN < 1)
        {
            Vector2 bashnyaPos = new Vector2(posX, tank.position.y + Random.Range(15, 19));
            Instantiate(bashnya, bashnyaPos, Quaternion.identity);
            BashnyaN++;
        }
    }

    void SoldierControl()
    {
        float posX = 0;
        int a = Random.Range(0, 2);
        if (a == 0)
            posX = -17;
        else
            posX = 17;
        if (SoliderN < 1)
        {
            Vector2 soldierPos = new Vector2(posX, tank.position.y);
            Instantiate(soldier, soldierPos, Quaternion.identity);
            SoliderN++;
        }
        
    }

    void CarControl()
    {


        if (CarN < 1)
        {
            CarN++;
            Vector2 carPos = new Vector2(tank.position.x + Random.Range(-4, 5), tank.position.y + Random.Range(15, 19));
            Instantiate(avto, carPos, Quaternion.identity);
        }
    }   

    public void TesadDursDest(GameObject obj)
    {
        if ((tank.position - obj.transform.position).magnitude > 40)
        {
            Destroy(obj);
        }
    }

    void CanvasControl()
    {
        if (life > 100)
            life = 100;
        if (life < 0)
            life = 0;
        slider.value = life;
        score = destroyedCar * scoreCar + destroyedBashnya * scoreBashnya;
    }

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 20), "Score    " + score);
        GUI.Label(new Rect(60, 50, 100, 20), "" + destroyedCar);
        GUI.Label(new Rect(60, 90, 100, 20), "" + destroyedBashnya);
        GUI.Label(new Rect(30, Screen.height-30, 1000, 600)," "+ snaryadN);
        if (snaryadN == 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2, 100, 20), "Game Over");
            Application.LoadLevel(2);
            snaryadN = 30;
        }
    }
    float n;
    bool Shochik(float t)
    {
        n=n+Time.deltaTime;
        if (n > t)
        {
            n = 0;
            return true;
        }
        else
            return false;
    }

    
}


