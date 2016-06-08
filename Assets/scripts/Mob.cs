using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    public GameObject prefabSmertmob;
    int turn;
   [SerializeField] private int score=0;
    int irendom = 0;
    [SerializeField, Range (0.1f, 3)]private float MobSpeed = 1;
    public static int Count = 0;

    IEnumerator MyCoroutine()
    {     Turn();
        while (true)
        {
                    
            int k = Random.Range(1, 4) * 2;
            Turn();
            for (int i=0; i<20*k; i++)
            {
                UpdateMove(0.05f*MobSpeed);
                yield return new WaitForSeconds(0.05f);
         
            }
        }
    }

    public int Turn()
    {   int temp = turn;
        turn = Random.Range(1, 5);
        if (turn == temp)
            Turn();
        int myX = (int)(transform.position.x + 0.5);
        int myY = (int)(transform.position.y + 0.5);
        transform.position = new Vector3(myX, myY, 0);

        return turn;
    }
    void Awake()
    {
        Count++;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fire")
        {
            Object smob;
            smob = Instantiate(prefabSmertmob, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(smob, 0.4f);
            Meneger.score += score;
            Count--;
            Destroy(gameObject);
        }
    }
  /*      void OnDestroy()
    {
        Object smob;
        smob = Instantiate(prefabSmertmob, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        Destroy(smob, 0.4f);
        Meneger.score += score;
        Count--;
    }*/
	void Start () {
       
        StartCoroutine(MyCoroutine());
	}
   

    bool CanMove(Vector3 vec)
    {
        int x = (int)(vec.x + 0.5);
        int y = (int)(vec.y + 0.5);
        if (Meneger.Instance.map.GetOb(x, y) == Detali.bron || Meneger.Instance.map.GetOb(x, y) == Detali.cegla|| Meneger.Instance.map.GetOb(x, y) == Detali.bomba)
        {
                  return false;
        }
        return true;
  
    }
    Vector3 GetTurn(int turn,float m)
    {   if (turn == 1)
            return transform.position + (new Vector3(0, 1f, 0)) * m+ new Vector3(0, 0.5f, 0);
        if (turn == 2)
            return transform.position + (new Vector3(1f, 0, 0)) * m+new Vector3(0.5f, 0, 0);
        if (turn == 3)
            return transform.position + (new Vector3(0, -1f, 0)) * m+ new Vector3(0, -0.5f, 0);
        if (turn == 4)
            return transform.position + (new Vector3(-1f, 0, 0)) * m+ new Vector3(-0.5f, 0, 0);
        return transform.position;
    }
    void UpdateMove (float m)
    {
  
        int myX = (int)(transform.position.x+0.45);

        int myY = (int)(transform.position.y+0.45);

        bool bimove = false;
      //  float offset = 1f;
        if (turn == 1)
        {
            
            if (CanMove(GetTurn(turn,m)))
            {
                transform.position += (new Vector3(0, 1, 0)) * m;
              //  Debug.Log("true1");
                bimove = true;
            }
  
        }
       else if (turn == 2)
        {

            if (CanMove(GetTurn(turn, m)))
            {
                transform.position += (new Vector3(1, 0, 0)) * m;
                bimove = true;
               // Debug.Log("true2");
            }
      
        }
        else if (turn == 3)
        {
            if (CanMove(GetTurn(turn, m)))
            {
                transform.position += (new Vector3(0, -1, 0)) * m;
                bimove = true;
               // Debug.Log("true3");
            }
  

        }
       else if (turn == 4)
        {
            if (CanMove(GetTurn(turn, m)))
            {
                transform.position += (new Vector3(-1, 0, 0)) * m;
                bimove = true;
               // Debug.Log("true4");
            }
     

        }
        if (bimove == false)
        {
            if (irendom < 16)
            {

                Turn();
                irendom += 1;
                UpdateMove(m);
              
            }

        }
        else irendom = 0;
       
    }
    void OnDrawGizmos()
    {
        Vector3 nextsee = GetTurn(turn, 0.05f * MobSpeed);
        bool can = CanMove(nextsee);

        Gizmos.color = can ? Color.green : Color.red;
        Gizmos.DrawSphere(nextsee, 0.1f);
    }
}
