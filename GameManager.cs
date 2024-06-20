using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Level1
    private float stage01Time = 0.0f;
    private float stage02Time = 0.0f;

    private float ItemTime =0.0f;
    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject Item;


    private void Update()
    {
        stage01Time += Time.deltaTime;
        stage02Time += Time.deltaTime;
        ItemTime += Time.deltaTime; // 증가하는

        if(stage01Time > 1.5f)
        {
            Instantiate(enemy1, new Vector3 
                (Random.Range(-10,10)
                ,Random.Range(-10,10),0)
                ,Quaternion.identity);
            stage01Time = 0.0f;
        }
        if (stage02Time > 10.0f)
        {
            Instantiate(enemy2, new Vector3
                (Random.Range(-10, 10)
                , Random.Range(-10, 10), 0)
                , Quaternion.identity);
            stage02Time = 8.5f;
        }
        if (ItemTime > 5.0f)
        {
            Instantiate(Item, new Vector3
                (Random.Range(-10,10)
                ,Random.Range(10,10),0)
                ,Quaternion.identity);
            ItemTime = 0.0f;
        }
    }
}
