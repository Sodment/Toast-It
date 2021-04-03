using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Class for handling diffrent kind of swipes
/// </summary>
public class SwipeManager : MonoBehaviour
{

    public float swipeThreshold = 50f;
    public float timeThreshold = 0.3f;

    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;
    public UnityEvent OnSwipeUp;
    public UnityEvent OnSwipeDown;

    private Vector2 fingerDown;
    private float fingerDownTime;
    private Vector2 fingerUp;
    private float fingerUpTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.fingerDown = Input.mousePosition;
            this.fingerUp = Input.mousePosition;
            this.fingerDownTime = Time.timeSinceLevelLoad;
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.fingerDown = Input.mousePosition;
            this.fingerUpTime = Time.timeSinceLevelLoad;
            this.CheckSwipe();
        }
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                this.fingerDown = touch.position;
                this.fingerUp = touch.position;
                this.fingerDownTime = Time.timeSinceLevelLoad;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                this.fingerDown = touch.position;
                this.fingerUpTime = Time.timeSinceLevelLoad;
                this.CheckSwipe();
            }
        }
    }

    /// <summary>
    /// Method for handling diffrent kind of swipes where
    /// deltaX is the diffrence between startpoint and endpoint of swipe in X axis
    /// deltaY is the diffrence between startpoint and endpoint of swipe in Y axis
    /// </summary>
    private void CheckSwipe()
    {
        float duration = this.fingerUpTime - this.fingerDownTime;
        if (duration > this.timeThreshold) return;

        float deltaX = this.fingerDown.x - this.fingerUp.x;
        if (Mathf.Abs(deltaX) > this.swipeThreshold)
        {
            if (deltaX > 0)
            {
                this.OnSwipeRight.Invoke();
                //Debug.Log("right");
            }
            else if (deltaX < 0)
            {
                this.OnSwipeLeft.Invoke();
                //Debug.Log("left");
            }
        }

        float deltaY = fingerDown.y - fingerUp.y;
        if (Mathf.Abs(deltaY) > this.swipeThreshold)
        {
            if (deltaY > 0)
            {
                this.OnSwipeUp.Invoke();
                //Debug.Log("up");
            }
            else if (deltaY < 0)
            {
                this.OnSwipeDown.Invoke();
                //Debug.Log("down");
            }
        }

        this.fingerUp = this.fingerDown;
    }
}