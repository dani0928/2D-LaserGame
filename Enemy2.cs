using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    #region 변수
    public float EnemyHP = 5.0f;
    private float speed = 0.4f;
    Transform playerTr;
    Player player;

    //적군 폭발 이펙트
    public GameObject deadEffect;

    //카메라 효과
    new CameraShake camera;
    #endregion
    private void Start()
    {
        playerTr=GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTr.position, Time.deltaTime* speed);
        transform.Rotate(Vector3.forward*speed*200.0f*Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other) //BoxCollider Trigger 속성 체크 시!
    {
        if (other.gameObject.tag =="Bullet")
        {
            Debug.Log("EnemyHP:" + EnemyHP);
            EnemyHP -= 10f;
        }
        if(EnemyHP < 0.0f)
        {
            //Debug.Log("사망");
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            camera.VibrateForTime(0.05f);
            Debug.Log("흔들림");
            player.ScoreUP();
            Destroy(this.gameObject);   
        }
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("플레이어와 충돌");
            player.PlayerHPMinus();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            camera.VibrateForTime(0.05f);
            Destroy(this.gameObject);
        }
    }
}
