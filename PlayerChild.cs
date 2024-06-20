using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChild : MonoBehaviour
{
    //ȸ���ӵ�
    [SerializeField]
    private float speed = 60.0f;
    // �������� ���� �� ���� �����Ǵ� �ڽ� ����
    [SerializeField]
    private int childCnt = 2;
    //�ڽ����� ������� ������
    [SerializeField]
    private GameObject child = null;
    //�����Ǵ� �ڽ� ������Ʈ���� �Ÿ�
    [SerializeField]
    private float distance = 1.2f;
    //�������� ���� Ƚ��
    int increaseCount = 0;

    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void CreateChild()
    {
        increaseCount += 1; //�������� �ϳ� ������
        if(increaseCount > 2)  //������ 3�� �̻��� ������
        {
            player.HpUp();
            Debug.Log("�÷��̾� HP ����");
            increaseCount = 3;
            return;
        }
        if(increaseCount <=2) //�������� �ΰ��Ծ�����
        {
            GameObject[] playerChilds = GameObject.FindGameObjectsWithTag("PlayerChildObj");
            childCnt += playerChilds.Length;
            for(int i = 0;i< playerChilds.Length; i++)
            {
                Destroy(playerChilds[i]);
            }
        }
        for (int i = 0; i< childCnt; i++) 
        { 
            //�ڽ� ������Ʈ�� ����
            GameObject go = Instantiate(child);
            //�ڽ��� ������ ���缭 �յ��ϰ� ��ġ�ϱ� ���ؼ�, ���� ����
            float angle = 360.0f / childCnt;
            //������ Sin �Լ��� Y��ǥ�� ���ϰ�, Cos�Լ��� X��ǥ�� ���Ѵ�.
            float newY = Mathf.Sin(i * angle * Mathf.Deg2Rad);
            float newX = Mathf.Cos(i * angle * Mathf.Deg2Rad);
            //���� ��ġ���� �Ÿ��� ���ϰ�, �θ� ��ġ�� ���缭 ����
            newY = (newY * distance) + this.transform.position.y;
            newX = (newX * distance) + this.transform.position.x;
            //���ο� ��ǥ�� ��ġ�� �־��ش�.
            go.transform.position = new Vector3(newX, newY, 0.0f);
            //������ ������Ʈ�� �θ� �� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� ����
            go.transform.parent = this.transform;
        }
    }
    private void Update()
    {
      //�θ� ȸ����Ű�� �ڽĵ��� ���� ȸ��
      transform.Rotate(Vector3.forward,speed * Time.deltaTime);
    }
}
