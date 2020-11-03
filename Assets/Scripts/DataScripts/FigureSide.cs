﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureSide",menuName = "Chess/FigureSide",order = 0)]
public class FigureSide : ScriptableObject
{
    [SerializeField] private string sideName;
    [SerializeField] private FigureData[] figuresPack;
    [SerializeField] private FigureData pawn;

    public FigureData[] FiguresPack => figuresPack;

    public FigureData Pawn => pawn;

   
}
