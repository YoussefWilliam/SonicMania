using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    Vector3 cameraPlay;
    bool thirdCameraView = false;

    private void Start()
    {
        cameraPlay = new Vector3(0, 25.8f, -40f);
    }
    void Update()
    {
        transform.position = player.position + cameraPlay;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(thirdCameraView == false)
            {
                cameraPlay = new Vector3(0, 25.8f, -40f);
                thirdCameraView = true;
            }
            else
            {
                cameraPlay = new Vector3(1f,0, 1f);
                thirdCameraView = false;
            }
        }
    }

    public void CisClicked()
    {
        if (thirdCameraView == false)
        {
            cameraPlay = new Vector3(0, 25.8f, -40f);
            thirdCameraView = true;
        }
        else
        {
            cameraPlay = new Vector3(1f, 0, 1f);
            thirdCameraView = false;
        }
    }
}
