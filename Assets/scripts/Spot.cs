using UnityEngine;

public class Spot
{
    public Vector3 position;
    public Color pegColor;
    public GameObject peg;
    public Quaternion baseCodePegRotation = Quaternion.Euler(121.23f, -1.52588f, -1.52588f);
    private static Vector3 baseHeadLinePosition = new Vector3(-1.24f, 7.89f, 4.696f);
    private static float _horizontalOffsetCodeSpot = 1.65f;
    private const string _material_color_variable_name = "_Color";


    public static Spot CreateClueSpot(int index, Vector3 position)
    {
        return CreateSpot(position);
    }

    public static Spot CreateCodeSpot(int index, Vector3 position)
    {
        return CreateSpot(position);
    }
    public static Spot CreateHeadCodeSpot(int index)
    {
        float x = CalcCodeXPosition(index, baseHeadLinePosition.x);
        Vector3 spotPosition = new Vector3(x, baseHeadLinePosition.y, baseHeadLinePosition.z);

        return CreateSpot(spotPosition);
    }

    private static float CalcCodeXPosition(int spotIndex, float baseXPosition)
    {
        float factor = spotIndex * _horizontalOffsetCodeSpot;
        return factor + baseXPosition;
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
