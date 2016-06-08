using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	void Update () {
        GetComponent<Text>().text = " " + Meneger.score;
    }
}
