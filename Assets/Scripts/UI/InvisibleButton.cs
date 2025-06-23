using UnityEngine;

public class InvisibleButton : MonoBehaviour
{
    private InvisibleAbility _invisAbility;
    public void UseInvisible()
    {
        if (GameManager.instance.GetPlayer() != null)
        {
            if (_invisAbility == null) _invisAbility = GameManager.instance.GetPlayer().GetComponent<InvisibleAbility>();
            _invisAbility.Execute();
        }
    }
}
