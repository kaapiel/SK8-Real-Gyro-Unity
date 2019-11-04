using UnityEngine;

public enum SwipeDirection
{
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,
}

public class SwipeListener : MonoBehaviour
{
    private static SwipeListener instance;
    public static SwipeListener Instance { get { return instance; }}

    public SwipeDirection Direction { get; set; }

    private Vector3 touchPosition;
    private float swipeResistanceX = 100.0f;
    private float swipeResistanceY = 200.0f;

    Vector2 touchLook;
    Vector2 smoothV;
    public float sensitivity = 0.4f;
    public float smoothing = 1.0f;

    Vector3 startPosition;
    Vector3 endPosition;

    float yRotation;

    private void Start()
    {
        instance = this;
    }

    public void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
            {
                if (deltaSwipe.x < 0)
                {
                    //Direction |= SwipeDirection.Right;
                    Debug.Log("SWIPE PARA DIREITA");
                }
                else
                {
                    //Direction |= SwipeDirection.Left;
                    Debug.Log("SWIPE PARA ESQUERDA");
                }
            }
            else if(Mathf.Abs(deltaSwipe.y) > swipeResistanceY)
            {
                if(deltaSwipe.y < 0)
                {
                    //Direction |= SwipeDirection.Up;
                    Debug.Log("SWIPE PARA CIMA");
                }
                else 
                {
                    //Direction |= SwipeDirection.Down;
                    Debug.Log("SWIPE PARA BAIXO");

                    transform.position = Vector3.MoveTowards(transform.position, Vector3.forward, 1*Time.deltaTime);
                }
            }
        }
    }

}