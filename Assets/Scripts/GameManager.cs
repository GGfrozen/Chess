using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject boardPrefab;
    [SerializeField] private Transform boardSpawnPoint;
    [SerializeField] private float boardSpawnOffset = 0.5f;

    [SerializeField] private FigureSide[] figureSide;

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
        var figurePrefab = figureSide[sideIndex].FiguresPack[index].FigurePrefab;
        var createPosition = figureSide[sideIndex].FiguresPack[index].SpawnPosition;
        var figure = Instantiate(figurePrefab, createPosition, Quaternion.identity);
        activeFigure.Add(figure);
        SpawnPawn(sideIndex);
    }

    private void SpawnFigureToBoard()
    {
        for (var i = 0; i <= figureSide[0].FiguresPack.Length-1; i++)
        {
            SpawnFigure(i,0);
            SpawnFigure(i,1);
            
        }
    }

    private void SpawnPawn(int index)
    {
        var blackPawn = figureSide[index].Pawn;
        var whitePawn = figureSide[index].Pawn;
        for (var i = 0; i <= 8; i++)
        {
            var newBlackPositionX = blackPawn.SpawnPosition.x + i;
            var newBlackPosition = new Vector3(newBlackPositionX,blackPawn.SpawnPosition.y,blackPawn.SpawnPosition.z);
            var newWhitePositionX = whitePawn.SpawnPosition.x + i;
            var newWhitePosition = new Vector3(newWhitePositionX,whitePawn.SpawnPosition.y,whitePawn.SpawnPosition.z);
            
            var pawn = Instantiate(blackPawn, newBlackPosition, Quaternion.identity);
            var pawn2 = Instantiate(whitePawn, newWhitePosition, Quaternion.identity);
        }
        
    }
}
