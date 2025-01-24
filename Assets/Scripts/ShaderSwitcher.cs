using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSwitcher : MonoBehaviour
{
    private Shader _defaulShader;
    private Renderer _render;
    private void Start()
    {
        _render = GetComponent<Renderer>();
        _defaulShader = _render.material.shader;
    }

    public void ChangeShader(Shader newShader)
    {
        _render.material.shader = newShader;
    }

    public void UseDefaultShader()
    {
        _render.material.shader = _defaulShader;
    }
}
