using UnityEngine;

public class GlitchManager : MonoBehaviour
{
    public static GlitchManager Instance;

    [Header("Unlocked Glitches")]
    public bool phaseBullets;
    public bool rewindTime;
    public bool gravityFlip;
    public bool redSolid;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UnlockGlitch(RuleType rule)
    {
        switch (rule)
        {
            case RuleType.NoShoot:
                phaseBullets = true;
                break;

            case RuleType.NoMoveLeft:
                rewindTime = true;
                break;

            case RuleType.NoJump:
                gravityFlip = true;
                break;

            case RuleType.NoTouchRed:
                redSolid = true;
                break;
        }

        Debug.Log("GLITCH UNLOCKED: " + rule);
    }
}
