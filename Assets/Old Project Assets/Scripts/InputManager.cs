using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{


    [Header("Dragging BAll")]

    public bool dragging = false;
    public bool touchBegan = false;
    public bool touchMoving = false;
    public bool stationaryTouch = false;
    public bool touchEnd = false;
    public Vector3 prevPos;
    public Vector3 currentPos;
    int frames = 0;
  
    float time;

    public float horizontal;
    public float vertical;

    [Header("Shoot BAll")]
    public Vector2 InitialPos, FinalPos;
    






    private void FixedUpdate()
    {
        if (touchBegan)
        {
            time += Time.fixedDeltaTime;
            frames++;
            //Debug.Log("Frames "+frames);
        }
        else
        {
            // Its Working Fine but commented for ControlFreak Work
            //if(frames>0 && frames<=5)
            //{
                
            //    float dis = Vector3.Distance(InitialPos,FinalPos);
            //    if (dis > 150 )
            //    {
            //        LevelManager.Instance.Ball_Ref.ShootBall = true;
            //    }
            //}
            //frames = 0;
        }
        //frames++;
        //if (frames == 3)
        //{
            if (touchMoving)
            {


                if (currentPos == prevPos)
                {

                    stationaryTouch = true;
                    time = 0f;
                }
                else
                {
                    stationaryTouch = false;
                    Vector3 Dir =  (currentPos - prevPos)/100;
                    horizontal = Dir.x;
                    vertical = Dir.y;
                Debug.Log("Speed = " + Dir);
                prevPos = currentPos;
                    time = 0f;
                    FinalPos = currentPos;
                }

               
            }

            if (stationaryTouch||!touchBegan||!touchMoving)
            {
                //horizontal2 = horizontal;
                //vertical2 = vertical;
                horizontal = 0;
                vertical = 0;
                stationaryTouch = false;
            
        }

        //    frames = 0;


        //}
    }


    public virtual void OnPointerDown(PointerEventData eventData)
    {
        touchBegan = true;
        prevPos = eventData.position;
        InitialPos = eventData.position;

        OnDrag(eventData);

    }

    public void OnDrag(PointerEventData eventData)
    {
        touchMoving = true;
        currentPos = eventData.position;

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        currentPos = eventData.position;
        touchBegan = false;
        touchMoving = false;

        prevPos = currentPos = Vector3.zero;
    }
}
