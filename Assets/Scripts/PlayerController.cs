using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerController : MonoBehaviour
{
    Camera mainCam;
    Vector3 offset;

    float maxLeft;
    float maxRight;
    float maxTop;
    float maxBottom;

    [SerializeField] InputActionReference moveActionToUse;
    [SerializeField] float speed;

    void Start()
    {
        mainCam = Camera.main;
      
        StartCoroutine(SetBoundary());
    }

    // Update is called once per frame
    void Update()
    {
        TouchSystem();

        //TouchPad();

    }

    private void TouchPad()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        transform.Translate(speed * Time.deltaTime * moveDirection);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxBottom, maxTop), 0);
    }

    private void TouchSystem()
    {
        if (Touch.activeTouches.Count > 0)
        {

            if (Touch.activeTouches[0].finger.index == 0)
            {
                Touch myTouch = Touch.activeTouches[0];
                Vector3 touchPos = myTouch.screenPosition;


                if (touchPos.x == Mathf.Infinity)
                    return;
                touchPos = mainCam.ScreenToWorldPoint(touchPos);
                if (Touch.activeTouches[0].phase == TouchPhase.Began)
                {
                    offset = touchPos - transform.position;
                }

                if (Touch.activeTouches[0].phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);

                }
                if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
              {
                  transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);

               }
           }


           transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxBottom, maxTop), 0);

      }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }


    IEnumerator SetBoundary()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        maxBottom = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxTop = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;

    }
}
