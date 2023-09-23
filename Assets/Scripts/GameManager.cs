using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int bulletChosen = 0;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChooseBullet(int bullet)
    {
        bulletChosen = bullet;
        Debug.Log("bullet chosen " + bullet);
        SceneManager.LoadScene("MainScene");
    }

    public int GetBulletStr()
    {
        return bulletChosen * 5;
    }
}
