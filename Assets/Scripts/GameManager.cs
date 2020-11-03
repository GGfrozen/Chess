using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject boardPrefab = default;
    [SerializeField] private Transform boardSpawnPoint = default;
    [SerializeField] private float boardSpawnOffset = 0.5f;

    [SerializeField] private FigureSide[] figureSide = {};

    private List<GameObject> activeFigure = new List<GameObject>();
    private void Start()
    {
        SpawnBoard();
        SpawnFigureToBoard();
    }

    private void SpawnBoard()
    {
        var position = boardSpawnPoint.position;
        var spawnPosition = new Vector3(position.x + boardSpawnOffset,position.y,position.z+ boardSpawnOffset);
        Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnFigure(int index,int sideIndex)
    {
        var figurePrefab = figureSide[sideIndex].GetPrefab(index);
        var createPosition = figureSide[sideIndex].CreatePosition(index);
        var figure = Instantiate(figurePrefab, createPosition, Quaternion.identity);
        activeFigure.Add(figure);
    }

    private void SpawnFigureToBoard()
    {
        for (var i = 0; i <= figureSide[0].FiguresPack.Length-1; i++)
        {
            SpawnFigure(i,0);
            SpawnFigure(i,1);
            SpawnPawn(0);
            SpawnPawn(1);
        }
    }

    private void SpawnPawn(int index)
    {
        var blackPawn = figureSide[index].GetPawnPrefab();
        var whitePawn = figureSide[index].GetPawnPrefab();
        for (var i = 0; i <= 7; i++)
        {
            var position = figureSide[index].SetPawnPosition(i);
            var pawn = Instantiate(blackPawn, position, Quaternion.identity);
            var pawn2 = Instantiate(whitePawn, position, Quaternion.identity);
        }
        
    }
}
