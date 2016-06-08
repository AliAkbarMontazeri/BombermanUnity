using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    private bool opendoor=false;
    public bool OpDo { get { return opendoor; } set { opendoor = value; } }
    void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("InTriger", true);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("InTriger", false);

        }
    }
    void Update () {
     
        if (Mob.Count <= 0)
        {

            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("Mobdead");
        }


    }
}
