using UnityEngine;
using TMPro;

public class RuleUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ruleText;

    void Start()
    {
        UpdateRuleText();
    }

    void UpdateRuleText()
    {
        switch (RuleManager.Instance.activeRule)
        {
            case RuleType.NoShoot:
        
                ruleText.text = " DO NOT SHOOT";
                break;

            case RuleType.NoMoveLeft:
         
                ruleText.text = " DO NOT MOVE LEFT";
                break;

            case RuleType.NoTouchRed:
        
                ruleText.text = " DO NOT TOUCH RED";
                break;
            case RuleType.NoJump:
                ruleText.text = " DO NOT JUMP";
                break;
        }
    }
}
