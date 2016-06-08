using UnityEngine;
using System.Collections;

public class Meneger : MonoBehaviour {
    public GameObject playerprefab;
    public GameObject mobprefab;
    public Map map;
    public Door door;

    public static int score =0;
    public static int hi = 0;
    public static int playerhp=3;
    private static int level = 1;
    public static Meneger Instance;
    public GameObject Player;
    public CameraFoll camerafoll;
    private int sm = 0;
    private int sh = 0;
    private int sizem = 17;
    private int sizeh = 13;
    public int countbomb = 1;
    public static int countbonusbomb=0;
    public static void NextLvL()
    {
        
        level++;
        Application.LoadLevel("1");
        
    }
    public static void GoToLvl(int x)
    {
      
        level = x;
        Application.LoadLevel("1");
    }

    void Awake()
    {
        Instance = this;
    }


	void Start ()
    {
        if (PlayerPrefs.HasKey("HiScore"))
        { hi = PlayerPrefs.GetInt("HiScore"); }
        Mob.Count = 0;
        if (level == 1)
        {
          
            map.Create(sizem, sizeh);
       
            map.CreateMobs(3, 1, 0);
      
        }
        if (level == 2)
        {
   
            map.Create(sizem, sizeh);

            map.CreateMobs(2, 2, 1);
  
        }
        if (level == 3)
        {
    
            sh = 10;
            sizem += sm;
            sizeh += sh;
            map.Create(sizem, sizeh);
      
            map.CreateMobs(1, 3, 2);
          
           
        }
        if (level == 4)
        {
         
            sm = 10;
            sizem += sm;
            sizeh += sh;
            map.Create(sizem, sizeh);
            map.CreateMobs(0, 4, 3);
         }
        map.CreateBonusX(map.GetBonus(level));
        camerafoll.SetMax(sizem - 9.15f, sizeh - 6);
        CreatePlayer();

    }
    void CreatePlayer()
    {

          Player = (GameObject)Instantiate(playerprefab, new Vector3(2, sizeh-2, 0), transform.rotation);
    }
    public void Reload()
    {
        Meneger.GoToLvl(level);
    }
    public void NewPlayer(float wait)
    {
        if (playerhp > 0)
      {
            Invoke("Reload", wait);
            playerhp -= 1;
       }
        else
        {
            
            Application.LoadLevel("0");

        }
    }
	void Update () {
       if (hi <= score)
        {
            hi = score;
            PlayerPrefs.SetInt("HiScore", hi);
        }

       
	}
}
