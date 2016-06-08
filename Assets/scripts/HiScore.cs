using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HiScore : MonoBehaviour {
	void Update () {

        GetComponent<Text>().text = " " + Meneger.hi;
    }
}
