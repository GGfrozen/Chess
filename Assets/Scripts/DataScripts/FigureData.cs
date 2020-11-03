using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureData",menuName = "Chess/FigureData",order = 0)]
public class FigureData : ScriptableObject
{
    [SerializeField] private string figureColor;
    [SerializeField] private string figureName;
    [SerializeField] private GameObject figurePrefab;
    [SerializeField] private int spawnIndex;
    [SerializeField] private Vector3 spawnPosition;

    public GameObject FigurePrefab => figurePrefab;

    public int SpawnIndex => spawnIndex;

    public Vector3 SpawnPosition => spawnPosition;
    

}
