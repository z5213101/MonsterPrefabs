using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystaleffect : MonoBehaviour
{
    private Camera camera;
    private int _downRestFactor = 1;
    private float _visibility = 0;
    private float _reFractionMag = 0;
    private string _globalTextureName = "GlobalRefractionTex";
    private string _globalVisibilityName = "GlobalVisibility";
    private string _globalRefractionMagName = "GlobalRefractionMag";
    // Start is called before the first frame update
    void Start()
    {
        GenerateRT();
    }

    // Update is called once per frame
    void GenerateRT()
    {
        camera = GetComponent<Camera>();
        if (camera.targetTexture != null)
        {
            RenderTexture temp = camera.targetTexture;
            camera.targetTexture = null;
            DestroyImmediate(temp);
        }

        camera.targetTexture = new RenderTexture(camera.pixelWidth >> _downRestFactor, camera.pixelHeight >> _downRestFactor, 16);
        camera.targetTexture.filterMode = FilterMode.Bilinear;

        Shader.SetGlobalTexture(_globalTextureName, camera.targetTexture);
        Shader.SetGlobalFloat(_globalRefractionMagName, _reFractionMag);
        Shader.SetGlobalFloat(_globalVisibilityName, _visibility);
    }
}
