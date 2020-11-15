using UnityEngine;

public class CodePeg : MonoBehaviour
{
    public GameObject codePegRef;
    
    public void CreateCodePeg(BaseLine line, Color color)
    {
        Spot codeSpot = line.GetNextCodeSpot();
        if (codeSpot.HasGameObject())
        {
            codeSpot.SetPegColor(color);
        }
        else
        {
            GameObject newPeg = Instantiate(codePegRef, codeSpot.position, codeSpot.baseCodePegRotation);
            codeSpot.SetPeg(newPeg, color);
        }
    }
}