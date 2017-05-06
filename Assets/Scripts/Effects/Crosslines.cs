using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Crosslines : MonoBehaviour {

    public Material crosslines;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        crosslines.SetFloat("_HorizFac", Screen.height);
        crosslines.SetFloat("_VertFac", Screen.width);

        Graphics.Blit(source, destination, crosslines);
    }
}
