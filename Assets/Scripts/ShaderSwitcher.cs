using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSwitcher : MonoBehaviour
{
    private Shader _defaulShader;
    private Renderer _render;
    private bool _isSwitched = false;
    private void Start()
    {
        _render = GetComponent<Renderer>();
        _defaulShader = _render.material.shader;
    }

    public void ChangeShader(Shader newShader)
    {
        if (!_isSwitched)
        {
            _render.material.shader = newShader;
            _isSwitched = true;
        }
    }

    public void UseDefaultShader()
    {
        _render.material.shader = _defaulShader;
        _isSwitched = false;
    }
}
