using UnityEngine;
using System.Collections;

public class NextLevl : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Mob.Count <= 0)
        {
            if (other.tag == "Player")
            {

                                Meneger.NextLvL();
            }
        }
    }

}
