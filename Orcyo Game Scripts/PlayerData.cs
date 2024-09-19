using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int wins;
    public int deaths;
    public int totalScores;
    public int angkaBadge;
    public int angkaDifficulty;
    public int levelPointData;

    //. Akan di pake di luar script ini 
    public PlayerData(DataPemain player)
    {
        // data Wins
        wins = player.wins;
        // data Deaths
        deaths = player.deaths;
        // data Total Scores
        totalScores = player.scores;
        // data Angka Badge
        angkaBadge = player.angkaBadge;
        // data Angka Difficulty
        angkaDifficulty = player.pilihanDifficulty;
        // data Level Point
        levelPointData = player.levelPoint;
    }
}
