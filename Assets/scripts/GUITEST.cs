using UnityEngine;
using System.Collections;

public class GUITEST : MonoBehaviour {
    private int window=0;
    public void GoToUI()
    {
        if (window == 0)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            window = 1;
        }
       else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            window = 0;
        }

    }    
      public void GoToLvl(int lvl)
    {
        Meneger.GoToLvl(lvl);
        Meneger.playerhp = 3;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

