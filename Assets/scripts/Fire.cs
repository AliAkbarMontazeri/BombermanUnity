using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
    public GameObject cegF;
    

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerStay2D(Collider2D other)
    {
       Object oc;
    
       
        if (other.tag=="cegla")
        {
            Destroy(other.gameObject);
            oc= Instantiate(cegF, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(oc, 0.4f);
            Destroy(gameObject);
        }
        if (other.tag=="bomb")
        {
            Destroy(other.gameObject);
        }
       

    }
    void OnDestroy()
    {
        int myX = (int)(transform.position.x + 0.5);
        int myY = (int)(transform.position.y + 0.5);

        Meneger.Instance.map.SetOb(myX, myY, 0);
    }
}
