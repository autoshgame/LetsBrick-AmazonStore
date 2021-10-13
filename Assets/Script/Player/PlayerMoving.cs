using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private float speed = 8f;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    private void Update()
    {
        MovingByTouch();
        PreventGetingOutOfScreen();
    }


    void MovingByTouch()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Debug.Log(touch.position);

            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);

            // -7 and 0 is the limitation of touch, you can not go futher
            if (touchPosition.y >= -7 && touchPosition.y <= 0)
            {
                if (touchPosition.x > 0)
                {
                    this.transform.Translate(Vector2.right * Time.deltaTime * speed);
                }
                else if (touchPosition.x <= 0)
                {
                    this.transform.Translate(Vector2.left * Time.deltaTime * speed);
                }
            }
        }
#endif
        //Test moving in Unity Flatform
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            //Debug.Log(touchPosition);
            // -7 and 0 is the limitation of touch, you can not go futher
            if (touchPosition.y >= -7 && touchPosition.y <= 0)
            {
                if (touchPosition.x > 0)
                {
                    this.transform.Translate(Vector2.right * Time.deltaTime * speed);
                }
                else if (touchPosition.x <= 0)
                {
                    this.transform.Translate(Vector2.left * Time.deltaTime * speed);
                }
            }
        }
#endif
    }


    void PreventGetingOutOfScreen()
    {
        // left bound and right bound  have been calculated
        float leftBound = -2.54f;
        float rightBound = 2.54f;

        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector2(leftBound, transform.position.y);
        }
        else if (transform.position.x >= rightBound)
        {
            transform.position = new Vector2(rightBound, transform.position.y);
        }
    }
}
