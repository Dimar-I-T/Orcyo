using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPemain : MonoBehaviour
{

    public int wins;
    public int deaths;
    public int scores;
    public int angkaBadge;
    public int pilihanDifficulty;
    public int levelPoint = 1;

    public void Awake()
    {
        wins = totalscore.totalwins;
        deaths = totalscore.totalmati;
        scores = totalscore.total;
        angkaBadge = totalscore.angkaBadge;
        pilihanDifficulty = totalscore.difficultyNumber;
        levelPoint = 1;
    }

}
