using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    private float timer = 240;
    string Tim(float t)
    {   
        int ostt = (int)t % 60;
       string os =ostt.ToString("00");
       int mint = ((int)t / 60);

        string s = mint+":"+os; 
        return s;
    }

	void Update () {

        if (timer > 60)
        {   
            timer -= Time.deltaTime;
            GetComponent<Text>().text = Tim(timer);
        }
        else if ((timer < 60) && (timer>0))
        {
            
            timer -= Time.deltaTime;
            GetComponent<Text>().text = Tim(timer);
            GetComponent<Text>().color = Color.red;
            
        }
        
    }
}
