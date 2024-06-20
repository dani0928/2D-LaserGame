using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float speed = 0.1f;
    public GameObject itemEffect;
    private Transform playerTr;
    private PlayerChild playerChild;

    private void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>(); 
        playerChild = GameObject.FindWithTag("PlayerChild").GetComponent<PlayerChild>();
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTr.position, Time.deltaTime * speed);
        transform.Rotate(Vector3.forward * speed * 100.0f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(itemEffect, transform.position,Quaternion.identity); //����������Ʈ ����
            // �÷��̾��� �ڽ� ��� ����
            playerChild.CreateChild();
            Destroy(this.gameObject); //������ ������Ʈ�� ����
        }
    }
}
