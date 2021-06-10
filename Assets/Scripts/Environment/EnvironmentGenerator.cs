using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    public SpriteShapeController spriteShapeController;

    public int cycles;
    public float xMultiplier;
    public float yMultiplier;
    public float noiseStep;
    public float xDifficultyPerStep;
    public float yDifficultyPerStep;
    public float curveMultiplier;

    Vector3 lastPos;

    public float bottom;

    public void OnValidate()
    {
        Clear();

        float x = xMultiplier;
        float y = yMultiplier;
        for (int i = 0; i < cycles; i++)
        {
            lastPos = transform.position + new Vector3(i * x, Mathf.PerlinNoise(0, i * noiseStep) * y);
            spriteShapeController.spline.InsertPointAt(i, lastPos);

            if (i != 0 && i != cycles - 1)
            {
                spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteShapeController.spline.SetLeftTangent(i, Vector3.left * x * curveMultiplier);
                spriteShapeController.spline.SetRightTangent(i, Vector3.right * x * curveMultiplier);
            }

            x += xDifficultyPerStep;
            y += yDifficultyPerStep;
        }

        spriteShapeController.spline.InsertPointAt(cycles, 
            new Vector3(lastPos.x, transform.position.y - bottom));
        spriteShapeController.spline.InsertPointAt(cycles + 1, 
            new Vector3(transform.position.x, transform.position.y - bottom));
    }

    void Clear()
    {
        spriteShapeController.spline.Clear();
    }
}
