using UnityEngine;

public class CluePeg : MonoBehaviour
{
    public GameObject cluePegRef;

    public void CreateRightColorCluePeg(Line line)
    {
        CreateCluePeg(line, Color.white);
    }

    public void CreateRightColorAndPositionCluePeg(Line line)
    {
        CreateCluePeg(line, Color.white);
    }

    private void CreateCluePeg(Line line, Color color)
    {
        Spot clueSpot = line.GetNextClueSpot();
        if (clueSpot.HasGameObject())
        {
            clueSpot.SetPegColor(color);
        }
        else
        {
            GameObject newPeg = Instantiate(cluePegRef, clueSpot.position, Quaternion.Euler(0, 0, 0));
            clueSpot.SetPeg(newPeg, color);
        }
    }

}
