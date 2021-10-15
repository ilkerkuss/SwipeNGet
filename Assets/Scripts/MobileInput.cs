using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance { set; get; }

    [HideInInspector]
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    [HideInInspector]
    public Vector2 swipeDelta, startTouch;
    private const float deadZone = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // B�t�n boollar� s�f�rl�yoruz
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;

        //Input

        #region Bilgisayar Kontrolleri
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        #endregion

        #region Mobil Kontrolleri
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }

        }

        #endregion
        // Mesafeyi hesapl�yoruz

        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // Mobil i�in
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            // Bilgisayar i�in
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }
        }

        //  Deadzone u ge�tik mi
        if (swipeDelta.magnitude > deadZone)
        {
            // evet ge�tik
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Sol mu sa� m�
                if (x < 0)
                {
                    // sol
                    swipeLeft = true;
                }
                else
                {
                    // sa�
                    swipeRight = true;
                }
            }
            else
            {
                //Yukar� m� a�a��s� m�
                if (y < 0)
                {
                    // a�a��
                    swipeDown = true;
                }
                else
                {
                    // yukar�
                    swipeUp = true;
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
