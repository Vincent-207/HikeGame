using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOscilator : MonoBehaviour
{
    Light lightObj;
    [SerializeField]
    float baseStrength, xScale, yScale;
    float current = 0f, offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightObj = GetComponent<Light>();
        offset = Random.Range(0f, 10f);
        current += offset;
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
        float intensity = baseStrength + yScale * Mathf.Sin(current * xScale);
        lightObj.intensity = intensity;
    }
}
