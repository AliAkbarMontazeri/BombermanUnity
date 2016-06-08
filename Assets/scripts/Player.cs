using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject bombPrefab;
    public GameObject Smert;
    private float playerSpeed = 2.5f;
    
    private bool Islive = true;
    Object smert;

    private bool _isGrounded = true;
    bool _isPlaying_grouch = false;
    bool _isPlaying_walk = false;
    bool _isPlaying_hadooken = false;

    Animator animator;

    const int WAIT = 0;
    const int LEFT = 1;
    const int UP = 2;
    const int RIGHT = 3;
    const int DUWN = 4;


    int _currentAnimationState = WAIT;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("+other" + other.gameObject.name);
        if (other.gameObject.tag == "mob")
        {
            KillPlayer();
        }
      

    }
    void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("---  " + Meneger.Instance.CountMobs);
      
           
        
       
        if (other.tag == "bonusfire")
        {
            Bomba.range += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "bonusbomb")
        {
            Meneger.countbonusbomb += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "bonushp")
        {
            Meneger.playerhp += 1;
            Destroy(other.gameObject);
        }
       if (other.tag == "fire" && Islive==true)
        {
            
            KillPlayer();
        }
 
    }
    void KillPlayer()
    {
        Destroy(gameObject);
        smert = Instantiate(Smert, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

        Destroy(smert, 0.4f);
        
        Meneger.Instance.NewPlayer(1f);
    
        Islive = false;
      }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void CreateBomb(int x, int y)
    {

              var go = (GameObject)Instantiate(bombPrefab, new Vector3(x, y, 0), transform.rotation);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space) && Meneger.Instance.countbomb + Meneger.countbonusbomb > 0)
        {
            int myX = (int)(transform.position.x + 0.5);
            int myY = (int)(transform.position.y + 0.5);
            if (Meneger.Instance.map.GetOb(myX, myY) != Detali.bomba)
            {
                CreateBomb(myX, myY);
                Meneger.Instance.countbomb -= 1;
            }
        }

        float transV = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float transH = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        if (transV != 0)
            transform.position += new Vector3(0, transV, 0);
        else if (transH != 0)
            transform.position += new Vector3(transH, 0, 0);

        animator.SetFloat("hoz", Input.GetAxis("Horizontal"));
        animator.SetFloat("ver", Input.GetAxis("Vertical"));
        if (transH != 0 || transV != 0)
        {
            if (Input.GetKeyDown("w"))
            {
                transform.position += new Vector3(transH, 0, 0);
                chState(UP);
            }
            else if (Input.GetKeyDown("a"))
            {
                chState(LEFT);
            }
            else if (Input.GetKeyDown("d"))
            {
                chState(RIGHT);

            }
            else if (Input.GetKeyDown("s"))
            {
                chState(DUWN);
            }
        }
        else
            chState(WAIT);


    }
    void chState(int state)
    {
        if (_currentAnimationState == state)
            return;

        switch (state)
        {
            case WAIT:
                animator.SetInteger("Nit", WAIT);
                break;

            case LEFT:
                animator.SetInteger("Nit", LEFT);
                break;

            case UP:
                animator.SetInteger("Nit", UP);
                break;

            case RIGHT:
                animator.SetInteger("Nit", RIGHT);
                break;

            case DUWN:
                animator.SetInteger("Nit", DUWN);
                break;
        }
    }
}
