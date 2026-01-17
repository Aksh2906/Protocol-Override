using UnityEngine;

public enum RuleType
{
    None,
    NoShoot,
    NoMoveLeft,
    NoJump,
    NoTouchRed
}

public class RuleManager : MonoBehaviour
{
    public static RuleManager Instance;

    [Header("Active Rule")]
    public RuleType activeRule = RuleType.None;
    public bool ruleBroken = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // -------- RULE CHECKS --------

    public void CheckShoot()
    {
        if (ruleBroken) return;

        if (activeRule == RuleType.NoShoot)
        {
            BreakRule();
        }
    }

    public void CheckMoveLeft(float horizontalInput)
    {
        if (ruleBroken) return;

        if (activeRule == RuleType.NoMoveLeft && horizontalInput < 0)
        {
            BreakRule();
        }
    }

    public void CheckTouchRed(GameObject other)
    {
        if (ruleBroken) return;

        if (activeRule == RuleType.NoTouchRed && other.CompareTag("Red"))
        {
            BreakRule();
        }
    }
    public void CheckJump()
    {
        if (ruleBroken) return;

        if (activeRule == RuleType.NoJump)
        {
            BreakRule();
        }
    }


    void BreakRule()
    {
        ruleBroken = true;
        Debug.Log("RULE BROKEN: " + activeRule);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.ruleBreak);
        GlitchManager.Instance.UnlockGlitch(activeRule);

    }
}
