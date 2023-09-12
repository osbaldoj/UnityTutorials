using UnityEngine;
using Cinemachine;

public class ShakeCamera : MonoBehaviour
{

    CinemachineVirtualCamera cvc;

    public static float duration;
    public static float intensity;
    public static bool isShaking;

    private void Awake()
    {

    }
    public static void Shake()
    {
        duration = 0.2f;
        intensity = 0.8f;
        isShaking = true;
    }
    void Update()
    {
        if (isShaking)
        {
            cvc = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();

            CinemachineBasicMultiChannelPerlin perlin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            perlin.m_AmplitudeGain = intensity;

            duration -= Time.deltaTime;

            if (duration <= 0f)
            {
                perlin.m_AmplitudeGain = 0;
                isShaking = false;
            }
        }
    }
}
