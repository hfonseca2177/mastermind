using UnityEngine;


public enum SpotType
{
    CODE, CLUE
}

public class Spot
{
    public Vector3 position;
    public Color pegColor;
    public GameObject peg;
    private SpotType _type;

    public static Spot CreateClueSpot(Vector3 position)
    {
        return CreateSpot(position, SpotType.CLUE);
    }

    public static Spot CreateCodeSpot(Vector3 position)
    {
        return CreateSpot(position, SpotType.CODE);
    }

    private static Spot CreateSpot(Vector3 position, SpotType type)
    {
        Spot spot = new Spot
        {
            position = position,
            _type = type
        };
        return spot;
    }

    public void SetPeg(GameObject peg, Color color)
    {
        this.peg = peg;
        this.pegColor = color;
        this.peg.transform.position = this.position;
    }

    public void SetPeg(Color color)
    {
        this.peg.SetActive(true);
        this.pegColor = color;
        this.peg.GetComponent<SpriteRenderer>().color = color;
    }

    public void Clear()
    {
        if(this.peg != null)
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
