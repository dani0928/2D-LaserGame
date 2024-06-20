using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    #region ����
    public float EnemyHP = 5.0f;
    private float speed = 0.4f;
    Transform playerTr;
    Player player;

    //���� ���� ����Ʈ
    public GameObject deadEffect;

    //ī�޶� ȿ��
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

    public void OnTriggerEnter2D(Collider2D other) //BoxCollider Trigger �Ӽ� üũ ��!
    {
        if (other.gameObject.tag =="Bullet")
        {
            Debug.Log("EnemyHP:" + EnemyHP);
            EnemyHP -= 10f;
        }
        if(EnemyHP < 0.0f)
        {
            //Debug.Log("���");
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            camera.VibrateForTime(0.05f);
            Debug.Log("��鸲");
            player.ScoreUP();
            Destroy(this.gameObject);   
        }
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("�÷��̾�� �浹");
            player.PlayerHPMinus();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            camera.VibrateForTime(0.05f);
            Destroy(this.gameObject);
        }
    }
}
