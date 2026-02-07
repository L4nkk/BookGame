using UnityEngine;

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

    ExpressionOffset currentExpression;

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
        HandleInput();
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
        currentExpression = expr;
    }

    void ApplyFace()
    {
        if (currentExpression == null) return;

        float jawOffset = 0f;
        float lipOffset = 0f;

        if (isTalking)
        {
            talkTimer += Time.deltaTime * talkSpeed;
            jawOffset = Mathf.Sin(talkTimer) * jawMoveAmount;
            lipOffset = Mathf.Sin(talkTimer) * lipMoveAmount;
        }

        // ----- LIPS -----
        lipL.localPosition =
            lipLBasePos + currentExpression.lipLPos + new Vector3(lipOffset, 0, 0);

        lipR.localPosition =
            lipRBasePos + currentExpression.lipRPos + new Vector3(lipOffset, 0, 0);

        lipL.localEulerAngles =
            lipLBaseRot + currentExpression.lipLRot;

        lipR.localEulerAngles =
            lipRBaseRot + currentExpression.lipRRot;

        // ----- BROWS -----
        browL.localEulerAngles =
            browLBaseRot + currentExpression.browLRot;

        browR.localEulerAngles =
            browRBaseRot + currentExpression.browRRot;

        // ----- MOUTH / JAW -----
        mouth.localEulerAngles =
            mouthBaseRot +
            currentExpression.mouthRot +
            new Vector3(jawOffset, 0, 0);
    }
}
