using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour
{

    public GameObject Fireprefab;
    public static int range=3;
    IEnumerator MyCoroutine(float wait)
    {
      
        yield return new WaitForSeconds(wait);
        int myX = (int)(transform.position.x + 0.5);
        int myY = (int)(transform.position.y + 0.5);
        Fire(range, myX, myY);

        
     }
    public bool CreateFire(int x, int y)
    {
        if (Meneger.Instance.map.GetOb(x, y) == Detali.bron)
            return false;

        Instantiate(Fireprefab, new Vector3(x, y, 0), Quaternion.identity);
        Debug.Log("fire"); 

        if (Meneger.Instance.map.GetOb(x, y) == Detali.cegla|| Meneger.Instance.map.GetOb(x, y) == Detali.bonus)
            return false;
        return true;
    }
    public void Fire(int size, int x, int y)
    {
        for (int j = x; j < size+x; j++)
        {
            if (CreateFire(j, y) == false)
                break;
        }
        for (int j = x; j > x-size; j--)
        {
            if (CreateFire(j, y) == false)
                break;
        }
        for (int j = y; j < size + y; j++)
        {
            if (CreateFire(x, j) == false)
                break;

        }
        for (int j = y; j > y-size; j--)
        {
            if (CreateFire(x, j) == false)
                break;
        }

    }
    void Start()
    {

        Meneger.Instance.map.SetOb((int)(transform.position.x + 0.5), (int)(transform.position.y + 0.5), Detali.bomba);
        Invoke("Bah", 4.0f);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false; 

        }
    }

    private void Bah()
    {
        Meneger.Instance.countbomb += 1;
        Meneger.Instance.map.SetOb((int)(transform.position.x + 0.5), (int)(transform.position.y + 0.5), Detali.trava);
        int myX = (int)(transform.position.x + 0.5);
        int myY = (int)(transform.position.y + 0.5);
        Fire(range, myX, myY);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fire")
        {
            Bah();
          
        }
    }

}