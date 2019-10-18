using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public Rigidbody rigid;
    public Transform player;
    public float force;
    private bool onGround = true;
     
    public float jumpForce;
    public enum Lane { Left, Center, Right }
    public enum MoveDirection { Left, Right, None }

    Lane currentLane = Lane.Center;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    private void FixedUpdate()
    {
      

        rigid.AddForce(0, 0, force * Time.deltaTime);

        MoveDirection requestedMoveDirection = MoveDirection.None;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            requestedMoveDirection = MoveDirection.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            requestedMoveDirection = MoveDirection.Right;
        }
        switch (requestedMoveDirection)
        {
            case MoveDirection.Right:
                if (currentLane == Lane.Right)
                {
                    break; //Do nothing when in right lane
                }
                else if (currentLane == Lane.Center)
                {
                    MoveRight();
                    currentLane = Lane.Right;
                }
                else if (currentLane == Lane.Left)
                {
                    MoveRight();
                    currentLane = Lane.Center;
                }
                break;
            case MoveDirection.Left:
                if (currentLane == Lane.Left)
                {
                    break; //Do nothing when in left lane
                }
                else if (currentLane == Lane.Center)
                {
                    MoveLeft();
                    currentLane = Lane.Left;
                }
                else if (currentLane == Lane.Right)
                {
                    MoveLeft();
                    currentLane = Lane.Center;
                }
                break;
        }

    }


   public void MoveLeft()
    {
        transform.position = new Vector3(player.position.x - 50, player.position.y, player.position.z);
    }
    public void MoveRight()
    {
        transform.position = new Vector3(player.position.x + 50, player.position.y, player.position.z);
    }

}
