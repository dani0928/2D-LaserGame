using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float YscrollSpeed = 1.0f;
    public float XscrollSpeed = 1.0f;
    Material back;

    private void Start()
    {
        back = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        float newOffsetY =back.mainTextureOffset.y + YscrollSpeed * Time.deltaTime;
        float newOffsetX =back.mainTextureOffset.x + XscrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(newOffsetX,newOffsetY);

        back.mainTextureOffset = newOffset;
 
    }
    public void ChangeBackgroundColor(Color newColor)
    {
        back.color = newColor;
    }
}
