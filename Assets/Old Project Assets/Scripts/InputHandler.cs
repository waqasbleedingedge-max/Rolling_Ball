using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NA.Vehicles.Ball;
using NA.Cameras;

public class InputHandler : MonoBehaviour
{
    public Text phaseDisplaytext;
    private Touch touch;
  //  private float touchSpeed;
  //  private float displayTime;

    private Vector2 touchStart, touchEnd;


    public static float inputX,inputY,inputZ;

    //public BallUserControl bUserControl;
    public FreeLookCam fLC;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.touchCount>0f)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                touchEnd = touch.position;

              //  Debug.Log("X Input =" + (touchEnd.x - touchStart.x));
                // Debug.Log("Y Input =" + (touchEnd.y - touchStart.y));
                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y;
                if (x < 20 && x > -20)
                    x = 0;
                if (y < 10 && y > -10)
                    y = 0;

                if (x >= 1000)
                    x = 1000;
                if (x < -1000)
                    x = -1000;
                if (y >= 1000)
                    y = 1000;
                if (y <= -1000)
                    y = -1000;


                inputX = x / 1000f;
                inputY = y / 1000f;
                // Debug.Log("x = " + inputX);
                //  Debug.Log("y = " + inputY);
                //  inputX =Mathf.Clamp(touchEnd.x- touchStart.x,-1,1);
                // inputY = Mathf.Clamp(touchEnd.y- touchStart.y,-1,1);
                //  inputZ = Vector2.Distance(touchStart,touchEnd);

                //  Debug.Log("x = " + inputX);
                //  Debug.Log("y = " + inputY);
                // Debug.Log("Altitude = " + touch.azimuthAngle);
               // touchStart = touch.position;
            }
            else if(touch.phase == TouchPhase.Stationary)
            {
                touchStart = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                inputX = 0f;
                inputY = 0f;
                inputZ = 0f;
              //  Debug.Log("ended");

            }





          //  fLC.x = bUserControl.h = inputX;
          //  bUserControl.v = inputY;
            


        }
    }


}
