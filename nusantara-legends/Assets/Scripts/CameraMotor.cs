using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public float boundX = 0.15f;
    public float boundY = 0.13f;
    public Transform lookAt;

    // LateUpdate is used because we want the camera move right after the character is move
    // so, there is a little delay between character move and camera move
    private void LateUpdate()
    {
        Vector3 deltaCam = Vector3.zero;


        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX < -boundX || deltaX > boundX)
        {
            if( lookAt.position.x > -6.584431)
            {
                if (lookAt.position.x < transform.position.x && lookAt.position.x > -8)
                {
                    // character is on the left of camera center
                    deltaCam.x = deltaX + boundX;
                }
                else
                {
                    // character is on right side of the camera center
                    deltaCam.x = deltaX - boundX;
                }
            }

            
        }

        // check if we're inside the bounds in Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY < -boundY || deltaY > boundY)
        {
            if (lookAt.position.y < transform.position.y)
            {
                // if character is downside of the camera center
                deltaCam.y = deltaY + boundX;
            }
            else
            {
                deltaCam.y = deltaY - boundY;
            }
        }

        transform.position += new Vector3(deltaCam.x, deltaCam.y, 0);

    }


}
