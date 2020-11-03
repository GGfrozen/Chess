using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureSide",menuName = "Chess/FigureSide",order = 0)]
public class FigureSide : ScriptableObject
{
    [SerializeField] private string sideName = "";
    [SerializeField] private FigureData[] figuresPack = {};
    [SerializeField] private FigureData pawn = default;
    
    public FigureData[] FiguresPack => figuresPack;
    public FigureData Pawn => pawn;
    
    public Vector3 SetPawnPosition(float offset)
    {
        var position = pawn.SpawnPosition;
        var newPositionX = position.x + offset;
        return  new Vector3(newPositionX,position.y,position.z);
    }

    public Vector3 CreatePosition(int index)
    {
        return figuresPack[index].SpawnPosition;
    }

    public GameObject GetPrefab(int index)
    {
        return figuresPack[index].FigurePrefab;
    }

    public GameObject GetPawnPrefab()
    {
        return pawn.FigurePrefab;
    }
    
}
