using UnityEngine;
using UnityEngine.UI;


public class AirplaneHUDController : MonoBehaviour
{
    [Header("Speedometer Controls")]
    public Slider SpeedSlider;
    public RectTransform speedneedle;

    [Header("Altimeter Controls")]
    public Slider altitudeSlider;
    public RectTransform altitudeNeedle;


    [Header("Needle Rotation Settings")]
    public float speedMinAngle = 130f;
    public float speedMaxAngle = 130f;
    public float altitudeMinAngle = 130f;
    public float altitudeMaxAngle = 130f;


    void Start()
    {

        SpeedSlider.onValueChanged.AddListener(UpdateSpeedometer);
        altitudeSlider.onValueChanged.AddListener(UpdateAltimeter);
    }

    void UpdateSpeedometer(float value)
    {
        float angle = 0;

        angle = MapRangeClamped(SpeedSlider.value, 0, 1, speedMinAngle, speedMaxAngle);

        speedneedle.localRotation = Quaternion.Euler(0, 0, angle);
    }

    void UpdateAltimeter(float value)
    {
        float angle = 0;

        angle = MapRangeClamped(altitudeSlider.value, 0, 1, altitudeMinAngle, altitudeMaxAngle);

        altitudeNeedle.localRotation = Quaternion.Euler(0, 0, angle);
    }

    public static float MapRangeClamped(float value, float inMin, float inMax, float outMin, float outMax)
    {
        float t = Mathf.Clamp01((value - inMin) / (inMax - inMin));
        return outMin + (outMax - outMin) * t;
    }

}
