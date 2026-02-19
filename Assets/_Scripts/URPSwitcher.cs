using UnityEngine;
using UnityEngine.Rendering;

public class URPSwitcher : MonoBehaviour
{
    public RenderPipelineAsset newPipeline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GraphicsSettings.defaultRenderPipeline = newPipeline;
    }
}
