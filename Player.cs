using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float movespeed = 5.0f;
    private float limitx = 8.6f;
    private float limity = 4.5f;
    public Color[] colors;
    public BackGround backGround;

    //�Ѿ˹߻�
    private Transform spPoint;
    public GameObject bulletPrefab;
    public float bulletCollTime = 0.23f;
    private float bulTime = 0.0f;

    //���� UI
    public Text ScoreText; 
    private int ScorePoint = 0;

    //�÷��̾� HP��
    public float PlayerHP = 100.0f;
    public Image HpBar;
    private void Start()
    {
        spPoint = GameObject.Find("spPoint").transform;
    }

    private void Update()
    {
        #region �÷��̾� ��/��/��/�Ʒ� �̵�
        if (Input.GetKey(KeyCode.A))// �������� �̵�
        {
            if (Get_Pos().x > -limitx)
            {
                Move_Pos(Vector3.left * movespeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Get_Pos().x < limitx)
            {
                Move_Pos(Vector3.right * movespeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Get_Pos().y < limity)
            {
                Move_Pos(Vector3.up * movespeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Get_Pos().y > -limity)

            {
                Move_Pos(Vector3.down * movespeed * Time.deltaTime);
            }
        }
        #endregion
        #region ��ǥ���� ���ؼ� ȸ��
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        // ���� ���ϱ�
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        //ȸ��
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        #endregion
        #region �Ѿ� �߻�
        bulTime += Time.deltaTime;
        if (bulTime > bulletCollTime)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bulletPrefab, spPoint.position, spPoint.rotation);
                bulTime = 0.0f;
            }
        }
        #endregion
    }

    public void ScoreUP()
    {
        ScorePoint += 100;
        ScoreText.text = ScorePoint.ToString();

        if (ScorePoint %1000 ==0)
        {
            if (ScorePoint / 1000-1 >= colors.Length)
                return;

            backGround.ChangeBackgroundColor(colors[ScorePoint/1000-1]);
        }
    }
    public void PlayerHPMinus()
    {
        PlayerHP -= 10.0f;
        if(PlayerHP < 1)
        {
            Debug.Log("End");
            SceneManager.LoadScene("EndScene");
        }
        HpBar.fillAmount = PlayerHP/100.0f;
    }

    public void HpUp()
    {
        if (PlayerHP > 100.0f) return;
        PlayerHP += 10;
        HpBar.fillAmount = PlayerHP / 100.0f;
    }
    private void Move_Pos(Vector3 move)
        {
            this.transform.position += move;
        }
    private Vector3 Get_Pos()
        {
            return this.transform.position;
        }
}
