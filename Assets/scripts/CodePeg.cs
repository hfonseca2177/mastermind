using UnityEngine;

public class CodePeg : MonoBehaviour
{
    public GameObject codePegRef;

    private void CreateCodePeg(Line line, Color color)
    {
        Spot codeSpot = line.GetNextCodeSpot();
        if (codeSpot.HasGameObject())
        {
            codeSpot.SetPeg(color);
        }
        else
        {
            GameObject newPeg = Instantiate(codePegRef, codeSpot.position, Quaternion.Euler(0, 0, 0));
            codeSpot.SetPeg(newPeg, color);
        }
    }
}