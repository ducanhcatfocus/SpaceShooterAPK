using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossBaseState : MonoBehaviour
{
    protected Camera mainCam;
    protected BossController bossController;

    protected float maxLeft;
    protected float maxRight;
    protected float maxTop;
    protected float maxBottom;

    private void Awake()
    {
        bossController = GetComponent<BossController>();
        mainCam = Camera.main;
    }
    protected virtual void Start()
    {
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.3f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.7f, 0)).x;
        maxBottom = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
        maxTop = mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }


    public virtual void RunState()
    {

    }

    public virtual void StopState()
    {
        StopAllCoroutines();
    }
   
}
