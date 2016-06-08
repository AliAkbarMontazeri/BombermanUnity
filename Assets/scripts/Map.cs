using UnityEngine;
using System.Collections;
public enum Detali
{
    trava=0, bron=1, bomba=2, cegla=3, mob=5, door=6, bonus=7, 
}
public class Map : MonoBehaviour {
    public GameObject bronPrefab;
    public GameObject ceglaPrefab;
    public GameObject travaPrefab;
    public GameObject mobPrefab;
    public GameObject mobPrefab2;
    public GameObject mobPrefab3;
    public GameObject Door;
    public GameObject NextLevl;
    public GameObject kordonprefabLR1;
    public GameObject kordonprefabLR2;
    public GameObject kordonprefabLR2imege;
    public GameObject kordonprefabHW;
    public GameObject kytprefab;


    public GameObject BonusFire;
    public GameObject BonusBomb;
    public GameObject BonusHp;
    public const int M = 0;
    public const int N = 0;
    private int m = 17;
    private int h = 13;
    public const int Zahisnepole = 5;

    private Detali[,] mas;
    private int r;
    private int p;
    public int[,] array;
    
    public void CreateBonusX(GameObject prefab)
    {
            do
            {
                r = Random.Range(2, m-2);
                p = Random.Range(1, h-1);
            }
            while (mas[r, p] != Detali.cegla);
                GameObject.Instantiate(prefab , new Vector3(r, p, 0), Quaternion.identity);
    }
    public GameObject GetBonus(int level)
    {
        GameObject ob=null;
        switch (level%3+1)
        {
            case 1:
                ob = BonusBomb;
                break;
            case 2:
                ob = BonusFire;
                break;
            case 3:
                ob = BonusHp;
                break;

            default: ob = BonusHp;
                break;
        }
        return ob;
    }
    private void CreateDoor()
    {
        do
        {
            r = Random.Range(2, m - 2);
            p = Random.Range(1, h - 1);
        }
        while (mas[r, p] != Detali.cegla);
      
            GameObject.Instantiate(Door, new Vector3(r, p, 0), Quaternion.identity);
            GameObject.Instantiate(NextLevl, new Vector3(r, p, 0), Quaternion.identity);

    }
    private void CreateMob(Detali[,] x, int count, GameObject mobpref)
    {
                for (int i = 0; i < count ; i++)
        {
            do
            {
                r = Random.Range(2, m - 2);
                p = Random.Range(1, h - 1);
            }
            while (x[r, p] != Detali.trava || (r < Zahisnepole && p > h - Zahisnepole));
            GameObject.Instantiate(mobpref, new Vector3(r, p, 0), Quaternion.identity);
        }
    }
    private void Cegla(Detali [,] x)
    {
     
        int yh;
        int ym;
        int y;

        yh = (h - 2) / 2;
        ym = (m - 4) / 2;
        y = (yh * ym) + 2;
       
        for (int i = 0; i < y; i++)
        {
            do
            {
                r = Random.Range(2, m-2);
                p = Random.Range(1, h-1);
            }
            while (x[r, p] != Detali.trava);
            x[r, p] = Detali.cegla;
        }

        x[2, h-2] = 0;
        x[2, h-3] = 0;
        x[3, h-2] = 0;
    }
    private void CreateBron()
    {
        GameObject.Instantiate(kytprefab, new Vector3(1, 0, 0), Quaternion.Euler(180, 0, 0));
        GameObject.Instantiate(kytprefab, new Vector3(1, h - 1, 0), Quaternion.Euler(0, 0, 0));
        GameObject.Instantiate(kytprefab, new Vector3(m - 2, h - 1, 0), Quaternion.Euler(0, 180, 0));
        GameObject.Instantiate(kytprefab, new Vector3(m - 2, 0, 0), Quaternion.Euler(0, 0, 180));
        for (int i = 3; i < m-2; i += 2)
        {
            for (int j = 2; j < h-1; j += 2)
            {
               mas[i, j] = Detali.bron;
                AddPrefab(bronPrefab, i, j);
                
            }
        }
        for (int j = 0; j < h; j++)
        {
            mas[0, j] = Detali.bron;
            mas[1, j] = Detali.bron;
            mas[m - 2, j] = Detali.bron;
            mas[m - 1, j] = Detali.bron;

            if (j % 3 == 1 && j > 3 && j < h - 3)
            {
                GameObject.Instantiate(kordonprefabLR2imege, new Vector3(1, j, 0), Quaternion.identity);
                GameObject.Instantiate(kordonprefabLR2imege, new Vector3(m - 2, j, 0), Quaternion.Euler(0, 180, 0));
            }
            else
            {
                GameObject.Instantiate(kordonprefabLR2, new Vector3(1, j, 0), Quaternion.identity);
                GameObject.Instantiate(kordonprefabLR2, new Vector3(m - 2, j, 0), Quaternion.Euler(0, 180, 0));

            }


            GameObject.Instantiate(kordonprefabLR2, new Vector3(m - 2, j, 0), Quaternion.Euler(0, 180, 0));

            GameObject.Instantiate(kordonprefabLR1, new Vector3(0, j, 0), Quaternion.identity);
            GameObject.Instantiate(kordonprefabLR1, new Vector3(m - 1, j, 0), Quaternion.Euler(0, 180, 0));

        }
        for (int i = 2; i < m - 2; i++)
        {

            mas[i, 0] = Detali.bron;
            mas[i, h - 1] = Detali.bron;
            GameObject.Instantiate(kordonprefabHW, new Vector3(i, 0, 0), Quaternion.identity);
            GameObject.Instantiate(kordonprefabHW, new Vector3(i, h - 1, 0), Quaternion.Euler(180, 0, 0));
        }
    }
    public void CreateMobs(int m1, int m2, int m3)
    {
        CreateMob(mas, m3, mobPrefab3);
        CreateMob(mas, m2, mobPrefab2);
        CreateMob(mas, m1, mobPrefab);
    }
    public void Create(int SizeMapM, int SizeMapH)
    {
        m = SizeMapM;
        h = SizeMapH;
        mas = new Detali[m, h];
        for (int i = 2; i < m-2; i++)
        {
            for (int j = 1; j < h-1; j++)
            {
                mas[i, j] = 0;
            }
        }


        CreateBron();
        Cegla(mas);
        CreateDoor();

      

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (mas[i, j] != Detali.bron)
                    AddPrefab(travaPrefab, i, j);
                if (mas[i, j] == Detali.cegla)
                    AddPrefab(ceglaPrefab, i, j);
             }
        }
    }
    private void AddPrefab(GameObject prefab, int i, int j)
    {
        GameObject gob=(GameObject)GameObject.Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
        gob.transform.parent = this.transform;
    }
    public Detali GetOb(int x, int y)
    {
        if (x < 0 || y < 0 || x >= m || y >= h)
            return 0;
        return mas[x, y];
    }
    public void SetOb(int x, int y, Detali c)
    {
        if (x < 0 || y < 0 || x >= m || y >= h)
            return ;
        mas[x, y]=c;
    }

}