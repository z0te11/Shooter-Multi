using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{
    private BehaviourComponent[] _behaviours;
    private BehaviourComponent _activeBehaviour;

    private void Awake()
    {
        if (GetComponent<BehaviourComponent>() != null) _behaviours = GetComponents<BehaviourComponent>();
    }

    private void Start()
    {
        if (_behaviours != null) StartCoroutine(WaitAndEvaluate(1f));
    }

    private void Update()
    {
        _activeBehaviour?.Behave();
    }

    private IEnumerator WaitAndEvaluate(float waitTime)
    {
        while (_behaviours.Length > 0)
        {
            yield return new WaitForSeconds(waitTime);

            float highScore = float.MinValue;
            _activeBehaviour = null;

            for (int i = 0; i < _behaviours.Length; i++)
            {
                var currentScore = _behaviours[i].Evaluate();
                if (currentScore > highScore)
                {
                    highScore = currentScore;
                    _activeBehaviour = _behaviours[i];
                }
            }
        }
    }

}
