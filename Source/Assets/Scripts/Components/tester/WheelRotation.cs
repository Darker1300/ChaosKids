

using UnityEngine;
using System.Collections;

public class WheelRotation : MonoBehaviour
{


    /// <summary>
    /// imagine a wheel or dial whose centre is the centre of the screen.
    /// Click on the wheel and drag it around the centre - clockwise to increase myValue, counter-clockwise to decrease myValue.
    /// myValue is capped at -450 and 4560.
    /// </summary>
    public float myValue = 0f; // This is the output value

    private float click;

    public float factor = 1f;
    // Change this to increase or decrease the wheel's effect on myValue


    void Update()
    {

        // hub of wheel is in centre of screen
        Vector2 hub = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (Input.GetMouseButton(0))
        {

            // Get angle from hub to mouse position
            // (probably a better way to do this)
            Vector2 mousePos = Input.mousePosition;
            float mouseAngle = Vector2.Angle(Vector2.up, mousePos - hub);
            if (mousePos.x < hub.x) mouseAngle = 360f - mouseAngle;

            // If this is the click down, store the starting angle
            if (Input.GetMouseButtonDown(0))
            {
                click = mouseAngle;
            }

            // How much has angle changed since last frame?
            float difference = mouseAngle - click;
            // To prevent error when going past zero
            if (difference > 180f) difference -= 360f;
            if (difference < -180f) difference += 360f;

            // Increment myValue by that difference and clamp it
            myValue += difference * factor;
            click = mouseAngle;
            myValue = Mathf.Clamp(myValue, -450f, 4560f);

        }

    }

}
