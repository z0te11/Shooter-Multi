using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleAbility : Ability
{
    public float cooldownInvisible;
    public float durationInvis;
    public bool isInvisible = false;
    
    [SerializeField] private Shader _invisibleShader;
    private ShaderSwitcher _shaderSwitcher;
    private float _invisibleTime = float.MinValue;

    private void Awake()
    {
        _shaderSwitcher = GetComponentInChildren<ShaderSwitcher>();
    }

    private IEnumerator UnUseInvisibilty(float sec)
    {
        yield return new WaitForSeconds(sec);
        isInvisible = false;
        _shaderSwitcher.UseDefaultShader();
        Debug.Log("Unuse Invisible");

    }

    public override void Execute()
    {
        if (!isInvisible)
        {
            if (Time.time < _invisibleTime + cooldownInvisible) return;

            _invisibleTime = Time.time;
            isInvisible = true;
            _shaderSwitcher.ChangeShader(_invisibleShader);
            StartCoroutine(UnUseInvisibilty(durationInvis));
            Debug.Log("Use Invisible");
        }
    }
}
