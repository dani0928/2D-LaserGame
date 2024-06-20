using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChild : MonoBehaviour
{
    //회전속도
    [SerializeField]
    private float speed = 60.0f;
    // 아이템을 먹을 때 마다 생성되는 자식 개수
    [SerializeField]
    private int childCnt = 2;
    //자식으로 만들어질 프리펩
    [SerializeField]
    private GameObject child = null;
    //생성되는 자식 오브젝트와의 거리
    [SerializeField]
    private float distance = 1.2f;
    //아이템을 먹은 횟수
    int increaseCount = 0;

    Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void CreateChild()
    {
        increaseCount += 1; //아이템을 하나 먹을때
        if(increaseCount > 2)  //아이템 3개 이상을 먹을때
        {
            player.HpUp();
            Debug.Log("플레이어 HP 증가");
            increaseCount = 3;
            return;
        }
        if(increaseCount <=2) //아이템을 두개먹었을때
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
            //자식 오브젝트를 생성
            GameObject go = Instantiate(child);
            //자식의 개수에 맞춰서 균등하게 배치하기 위해서, 간격 구함
            float angle = 360.0f / childCnt;
            //각도에 Sin 함수로 Y좌표를 구하고, Cos함수로 X좌표를 구한다.
            float newY = Mathf.Sin(i * angle * Mathf.Deg2Rad);
            float newX = Mathf.Cos(i * angle * Mathf.Deg2Rad);
            //구한 위치에서 거리를 곱하고, 부모 위치에 맞춰서 보정
            newY = (newY * distance) + this.transform.position.y;
            newX = (newX * distance) + this.transform.position.x;
            //새로운 좌표를 위치에 넣어준다.
            go.transform.position = new Vector3(newX, newY, 0.0f);
            //생성한 오브젝트의 부모를 이 스크립트가 붙은 게임오브젝트로 지정
            go.transform.parent = this.transform;
        }
    }
    private void Update()
    {
      //부모를 회전시키면 자식들은 따라서 회전
      transform.Rotate(Vector3.forward,speed * Time.deltaTime);
    }
}
