using UnityEngine;

public class GaugeController : MonoBehaviour
{
    [Header("Needles")]
    public RectTransform speedNeedle;      // Assign Speedometer Needle
    public RectTransform altitudeNeedle;   // Assign Altimeter Needle

    [Header("Values")]
    public float speedValue = 0f;
    public float maxSpeed = 400f;

    public float altitudeValue = 0f;
    public float maxAltitude = 9000f;

    [Header("Rates")]
    public float speedIncreaseRate = 40f;      // How fast speed increases when holding button
    public float altitudeIncreaseRate = 300f;  // How fast altitude increases

    // Internal flags
    private bool speedPressed = false;
    private bool altitudePressed = false;

    void Update()
    {
        // If speed button is being held
        if (speedPressed)
        {

            speedValue += speedIncreaseRate * Time.deltaTime;
        }
        else
        {

            speedValue -= speedIncreaseRate * Time.deltaTime;
        }
        speedValue = Mathf.Clamp(speedValue, 0, maxSpeed);

        // If altitude button is being held
        if (altitudePressed)
        {

            altitudeValue += altitudeIncreaseRate * Time.deltaTime;
        }
        else
        {
            altitudeValue -= altitudeIncreaseRate * Time.deltaTime;
        }

         altitudeValue = Mathf.Clamp(altitudeValue, 0, maxAltitude);
        

        speedNeedle.localRotation = Quaternion.Euler(0, 0, MapRangeClamped(speedValue, 0, maxSpeed, 0, -260));
        altitudeNeedle.localRotation = Quaternion.Euler(0, 0, MapRangeClamped(altitudeValue, 0, maxSpeed, 0, -280));
    }



    public static float MapRangeClamped(float value, float inMin, float inMax, float outMin, float outMax)
    {
        float t = Mathf.Clamp01((value - inMin) / (inMax - inMin));
        return outMin + (outMax - outMin) * t;
    }

    // Called when Speed button is pressed down
    public void SpeedPressedDown()
    {
        speedPressed = true;
        Debug.Log("speed pressed down detected");
    }

    // Called when Speed button is released
    public void SpeedReleased()
    {
        speedPressed = false;
        Debug.Log("speed released detected");
    }

    // Called when Altitude button is pressed down
    public void AltitudePressedDown()
    {
        altitudePressed = true;
    }

    // Called when Altitude button is released
    public void AltitudeReleased()
    {
        altitudePressed = false;
    }
}


