using UnityEngine;

public class Spot
{
    public Vector3 position;
    public Color pegColor;
    public GameObject peg;
    public Quaternion baseCodePegRotation = Quaternion.Euler(180, 0, 0);
    private static Vector3 baseHeadLinePosition = new Vector3(-0.022f, -0.117f, -11.62f);
    private const string _material_color_variable_name = "_Color";

    public Quaternion CodePegRotation = Quaternion.Euler(180f, 0, 0);
    private static Vector3 _baseLinePosition = new Vector3(0, 0, 0);
    private static float _horizontalShiftPegOffset = -1.63f;
    private static float _verticalShiftPegOffset = -1.118f;


    public static Spot CreateClueSpot(int lineIndex, int spotIndex)
    {
        //TODO implement CluePeg logic
        float x = CalcCodeXPosition(spotIndex, baseHeadLinePosition.x);
        Vector3 spotPosition = new Vector3(x, baseHeadLinePosition.y, baseHeadLinePosition.z);
        return CreateSpot(spotPosition);
    }

    public static Spot CreateCodeSpot(int lineIndex,  int spotIndex)
    {
        float x = CalcCodeXPosition(spotIndex, _baseLinePosition.x);
        float z = CalcCodeZPosition(lineIndex, _baseLinePosition.z);
        Vector3 spotPosition = new Vector3(x, _baseLinePosition.y, z);
        return CreateSpot(spotPosition);
    }
    public static Spot CreateHeadCodeSpot(int index)
    {
        float x = CalcCodeXPosition(index, baseHeadLinePosition.x);
        Vector3 spotPosition = new Vector3(x, baseHeadLinePosition.y, baseHeadLinePosition.z);

        return CreateSpot(spotPosition);
    }

    private static float CalcCodeXPosition(int spotIndex, float baseXPosition)
    {
        float factor = spotIndex * _horizontalShiftPegOffset;
        return factor + baseXPosition;
    }

    private static float CalcCodeZPosition(int lineIndex, float baseZPosition)
    {
        float factor = lineIndex * _verticalShiftPegOffset;
        return factor + baseZPosition;
    }

    private static Spot CreateSpot(Vector3 position)
    {
        Spot spot = new Spot
        {
            position = position
        };
        return spot;
    }

    public void SetPeg(GameObject peg, Color color)
    {
        this.peg = peg;
        this.peg.transform.position = this.position;

        SetPegColor(color);
    }

    public void SetPegColor(Color color)
    {
        this.peg.SetActive(true);
        this.pegColor = color;
        Renderer pegRenderer = this.peg.GetComponent<Renderer>();
        pegRenderer.material.SetColor(_material_color_variable_name, color);
    }

    public void Clear()
    {
        if (this.peg != null)
        {
            this.peg.SetActive(false);
        }
        this.pegColor = Color.clear;
    }

    public bool HasGameObject()
    {
        return this.peg != null;
    }

    public bool HasPeg()
    {
        return HasGameObject() && peg.activeSelf;
    }

}
