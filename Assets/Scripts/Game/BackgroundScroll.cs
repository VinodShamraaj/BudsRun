using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bgRenderer;
    private float speedRatio = 0.042f;

    void Update()
    {
        bgRenderer.material.mainTextureOffset+= new Vector2(speed* Time.deltaTime,0);
    }

    public void SetBackgroundSpeed(float newSpeed){
        speed = newSpeed * speedRatio;
    }
}
