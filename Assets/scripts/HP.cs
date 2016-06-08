using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HP : MonoBehaviour {
	void Update () {
        GetComponent<Text>().text = " "+ Meneger.playerhp;

    }
}
