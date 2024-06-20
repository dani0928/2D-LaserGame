using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildObj : MonoBehaviour
{
    GameObject spPoint;
    public GameObject bulletPrefab;
    private float delayTime = 0.0f;

    private void Start()
    {
        spPoint = GameObject.FindWithTag("spPoint");
    }

    private void Update()
    {
        delayTime += Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            if(delayTime> 0.5f)
            {
                Instantiate(bulletPrefab, transform.position, spPoint.transform.rotation);
                delayTime = 0.0f;
            }
        }
    }
}
