using UnityEngine;

[ExecuteAlways]
public class FaceOffsetController : MonoBehaviour
{
    [Header("Bones")]
    public Transform lipL;
    public Transform lipR;
    public Transform browL;
    public Transform browR;
    public Transform mouth;

    // -------- BASE POSE STORAGE --------
    Vector3 lipLBasePos, lipRBasePos;
    Vector3 lipLBaseRot, lipRBaseRot;
    Vector3 browLBaseRot, browRBaseRot;
    Vector3 mouthBaseRot;

    [System.Serializable]
    public class ExpressionOffset
    {
        public Vector3 lipLPos;
        public Vector3 lipRPos;

        public Vector3 lipLRot;
        public Vector3 lipRRot;

        public Vector3 browLRot;
        public Vector3 browRRot;

        public Vector3 mouthRot;
    }

    [Header("Expression Offsets")]
    public ExpressionOffset neutral;
    public ExpressionOffset happy;
    public ExpressionOffset angry;
    public ExpressionOffset sad;

    [Header("Expression Blending")]
    public float expressionBlendSpeed = 6f;

    ExpressionOffset targetExpression;
    ExpressionOffset blendedExpression = new ExpressionOffset();

    [Header("Talking Settings")]
    public float jawMoveAmount = 10f;
    public float lipMoveAmount = 5f;
    public float talkSpeed = 8f;

    float talkTimer;
    bool isTalking;

    void Start()
    {
        // Save neutral base transforms automatically
        lipLBasePos = lipL.localPosition;
        lipRBasePos = lipR.localPosition;

        lipLBaseRot = lipL.localEulerAngles;
        lipRBaseRot = lipR.localEulerAngles;

        browLBaseRot = browL.localEulerAngles;
        browRBaseRot = browR.localEulerAngles;

        mouthBaseRot = mouth.localEulerAngles;

        SetExpression(neutral);
    }

    void Update()
    {
        if (!Application.isPlaying) return;

        HandleInput();
        BlendExpressions();
        ApplyFace();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetExpression(neutral);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetExpression(happy);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetExpression(angry);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetExpression(sad);

        isTalking = Input.GetKey(KeyCode.Space);
    }

    void SetExpression(ExpressionOffset expr)
    {
        targetExpression = expr;
    }

    void BlendExpressions()
    {
        if (targetExpression == null) return;

        float t = Time.deltaTime * expressionBlendSpeed;

        blendedExpression.lipLPos =
            Vector3.Lerp(blendedExpression.lipLPos, targetExpression.lipLPos, t);

        blendedExpression.lipRPos =
            Vector3.Lerp(blendedExpression.lipRPos, targetExpression.lipRPos, t);

        blendedExpression.lipLRot =
            Vector3.Lerp(blendedExpression.lipLRot, targetExpression.lipLRot, t);

        blendedExpression.lipRRot =
            Vector3.Lerp(blendedExpression.lipRRot, targetExpression.lipRRot, t);

        blendedExpression.browLRot =
            Vector3.Lerp(blendedExpression.browLRot, targetExpression.browLRot, t);

        blendedExpression.browRRot =
            Vector3.Lerp(blendedExpression.browRRot, targetExpression.browRRot, t);

        blendedExpression.mouthRot =
            Vector3.Lerp(blendedExpression.mouthRot, targetExpression.mouthRot, t);
    }

    void ApplyFace()
    {
        if (targetExpression == null) return;

        float jawOffset = 0f;
        float lipWidthOffset = 0f;

        if (isTalking)
        {
            talkTimer += Time.deltaTime * talkSpeed;

            jawOffset = Mathf.Sin(talkTimer) * jawMoveAmount;
            lipWidthOffset = Mathf.Sin(talkTimer) * lipMoveAmount;
        }

        // ----- LIPS POSITION -----
        lipL.localPosition =
            lipLBasePos +
            blendedExpression.lipLPos +
            new Vector3(0, lipWidthOffset, 0);

        lipR.localPosition =
            lipRBasePos +
            blendedExpression.lipRPos +
            new Vector3(0, -lipWidthOffset, 0);

        // ----- LIPS ROTATION -----
        lipL.localEulerAngles =
            lipLBaseRot + blendedExpression.lipLRot;

        lipR.localEulerAngles =
            lipRBaseRot + blendedExpression.lipRRot;

        // ----- BROWS -----
        browL.localEulerAngles =
            browLBaseRot + blendedExpression.browLRot;

        browR.localEulerAngles =
            browRBaseRot + blendedExpression.browRRot;

        // ----- MOUTH / JAW -----
        mouth.localEulerAngles =
            mouthBaseRot +
            blendedExpression.mouthRot +
            new Vector3(0, jawOffset, 0);
    }

#if UNITY_EDITOR

    [ContextMenu("Capture Neutral Base Pose")]
    void CaptureBasePose()
    {
        lipLBasePos = lipL.localPosition;
        lipRBasePos = lipR.localPosition;

        lipLBaseRot = lipL.localEulerAngles;
        lipRBaseRot = lipR.localEulerAngles;

        browLBaseRot = browL.localEulerAngles;
        browRBaseRot = browR.localEulerAngles;

        mouthBaseRot = mouth.localEulerAngles;

        UnityEditor.EditorUtility.SetDirty(this);
    }

    [ContextMenu("Capture Happy From Current Pose")]
    void CaptureHappy()
    {
        CaptureExpression(happy);
    }

    [ContextMenu("Capture Angry From Current Pose")]
    void CaptureAngry()
    {
        CaptureExpression(angry);
    }

    [ContextMenu("Capture Sad From Current Pose")]
    void CaptureSad()
    {
        CaptureExpression(sad);
    }

    void CaptureExpression(ExpressionOffset target)
    {
        target.lipLPos = lipL.localPosition - lipLBasePos;
        target.lipRPos = lipR.localPosition - lipRBasePos;

        target.lipLRot = lipL.localEulerAngles - lipLBaseRot;
        target.lipRRot = lipR.localEulerAngles - lipRBaseRot;

        target.browLRot = browL.localEulerAngles - browLBaseRot;
        target.browRRot = browR.localEulerAngles - browRBaseRot;

        target.mouthRot = mouth.localEulerAngles - mouthBaseRot;

        UnityEditor.EditorUtility.SetDirty(this);
    }

#endif
}
