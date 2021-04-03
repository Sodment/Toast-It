using UnityEngine;
using UnityEngine.EventSystems;

public class MoveableArrow : EventTrigger
{
    public enum Direction { Left, Right, Up, Down};
    public Direction dir;

    public Transform defaultPos;
    public Transform arrowImage;

    public float Speed = 600.0f;


    public override void OnDrag(PointerEventData data)
    {
        Debug.Log("Drag");
        switch (dir)
        {
            case Direction.Up: 
                {
                    arrowImage.Translate(data.delta.y*Vector3.up * Speed * Time.deltaTime, Space.World);
                    break; 
                }
            case Direction.Down:
                {
                    arrowImage.Translate(data.delta.y * Vector3.up * Speed * Time.deltaTime, Space.World);
                    break; 
                }
            case Direction.Left:
                {
                    arrowImage.Translate(data.delta.x * Vector3.right * Speed * Time.deltaTime, Space.World);
                    break; 
                }
            case Direction.Right: 
                {
                    arrowImage.Translate(data.delta.x * Vector3.right * Speed * Time.deltaTime, Space.World);
                    break; 
                }
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        arrowImage.gameObject.LeanMove(defaultPos.position, 0.5f).setEase(LeanTweenType.easeOutBounce);
    }
}
