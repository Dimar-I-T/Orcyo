using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class totalscore : MonoBehaviour
{

    public static int angkaMinus;

    public static DataPemain dataPemain;

    //GameObject
    public GameObject Badge120;
    public GameObject BadgeBreakfree;
    public GameObject empty;
    public GameObject DataPemainObject;

    /// <summary>
    /// total
    /// </summary>
    public Text TotalTextPlus;
    public static int total;
    public static int angka;
    public static int totalsementara;
   
    /// <summary>
    /// Deaths
    /// </summary>
    public Text TotalTextMati;
    public static int totalmati;
    public static int angkaMati;
    public static int totalsementaramati;

    /// <summary>
    /// Wins
    /// </summary>
    public Text totalWintext;
    public static int totalwins;
    public static int angkaWin;
    public static int totalsementarawin;

    /// <summary>
    /// Skillz
    /// </summary>
    public Text skillText;
    public string skill;
    public static int totalSkills;
    public static int angkaSkills;
    public static int totalsementaraSkills;

    /// <summary>
    /// Badge
    /// </summary>
    public static int angkaBadge;
    public static int totalBadge;
    public static int sementaraBadge;
    
    /// <summary>
    /// Difficulty
    /// </summary>
    public static int difficultyNumber;
    private bool easyModeAktif = false;
    public GameObject EasyModeText;
    public GameObject HardModeText;
    public GameObject WinsText;
    public GameObject CurrentLevelText;
    public GameObject DifficultySelectionObject;
    public GameObject EasyModeSystem;
    /// EasyMODE
     // Theme Putih
    public Text lanjutTEXTPutih;
    public Text lanjutTEXTPutih3;
    public GameObject TombolLanjutPutih;
    public GameObject TombolPlayBiasaPutih;
    public GameObject TombolLanjutPutih3;
    public GameObject TombolPlayBiasaPutih3;
     // Theme Dark
    public Text lanjutTEXTDark;
    public Text lanjutTEXTDark4;
    public GameObject TombolLanjutDark;
    public GameObject TombolPlayBiasaDark;
    public GameObject TombolLanjutDark4;
    public GameObject TombolPlayBiasaDark4;
    /// Sudah End
    public GameObject TombolUlangDark;
    public GameObject TombolUlangPutih;
    public GameObject TombolUlangDark4;
    public GameObject TombolUlangPutih3;

    /// <summary>
    /// Save Point Level;
    /// </summary>
    public static int saveLevelPoint;
    public Text textLevel;

    private TextMeshProUGUI tmp;
  
    // Start is called before the first frame update
    void Awake()
    {
       
        //Plus
        /*tmp = GetComponent<TextMeshProUGUI>();
        totalsementara = PlayerPrefs.GetInt("H");
        total = totalsementara;

        //Deaths
        totalsementaramati = PlayerPrefs.GetInt("S");
        totalmati = totalsementaramati;
  
        //Wins
        totalsementarawin = PlayerPrefs.GetInt("T");
        totalwins = totalsementarawin;

        //Skills
        totalsementaraSkills = PlayerPrefs.GetInt("U");
        totalSkills = totalsementaraSkills;

        //Badge
        sementaraBadge = PlayerPrefs.GetInt("B");
        totalBadge = sementaraBadge;*/


        dataPemain = DataPemainObject.GetComponent<DataPemain>();

    }

    private void Start()
    {

        //PlayerData data = SaveSystem.LoadPlayer();
        //dataPemain.wins = data.wins;
        //dataPemain.deaths = data.deaths;
        //dataPemain.scores = data.totalScores;
        //dataPemain.angkaBadge = data.angkaBadge;
        //dataPemain.pilihanDifficulty = data.angkaDifficulty;
        //dataPemain.levelPoint = data.levelPointData;

    }

    // Update is called once per frame
    void Update()
    {
        lanjutTEXTPutih.text = "Level " + dataPemain.levelPoint;
        lanjutTEXTPutih3.text = "Level " + dataPemain.levelPoint;
        lanjutTEXTDark.text = "Level " + dataPemain.levelPoint;
        lanjutTEXTDark4.text = "Level " + dataPemain.levelPoint;
        /*PlayerPrefs.SetInt("H", totalsementara);
        if (angka > totalsementara)
        {
            if(totalsementara > angka)
            {
                PlayerPrefs.SetInt("H", angka);
            }
        }
        total = PlayerPrefs.GetInt("H");*/
        TotalTextPlus.text = "Total Score : " + dataPemain.scores;

        /////////
        ///Deaths

        /*PlayerPrefs.SetInt("S", totalsementaramati);
        if(angkaMati > totalsementaramati)
        {
            PlayerPrefs.SetInt("S", angkaMati);
        }
        totalmati = PlayerPrefs.GetInt("S");*/
        TotalTextMati.text = "Deaths : " + dataPemain.deaths;

        ///////
        ///Wins

        /*PlayerPrefs.SetInt("T", totalsementarawin);
        if(angkaWin > totalsementarawin)
        {
            PlayerPrefs.SetInt("T", angkaWin);
        }
        totalwins = PlayerPrefs.GetInt("T");*/
        totalWintext.text = "Wins : " + dataPemain.wins;

        ///////
        ///SavePointLevel

        //////
        ///Skills

        if (dataPemain.scores == 0 && dataPemain.deaths == 0)
        {
            skill = "Beginner";
        }
        else if(dataPemain.deaths >= dataPemain.scores)
        {
            skill = "Noob";
        }
        else if(dataPemain.scores > dataPemain.deaths)
        {
            skill = "Pro";
        }
        skillText.text = "Skill : " + skill;

        //////
        ///Badge

        /*PlayerPrefs.SetInt("B", sementaraBadge);
        if(angkaBadge > sementaraBadge)
        {
            PlayerPrefs.SetInt("B", angkaBadge);
        }
        totalBadge = PlayerPrefs.GetInt("B");*/

        // switch statement (totalbadge(int))
        /*(switch (dataPemain.angkaBadge)
        {
            // kalo dia totalbadgenya 1 berarti dia akan menampilkan badge reachedLevel120.
            case 1:
                Badge120.SetActive(true);
                empty.SetActive(false);
                BadgeBreakfree.SetActive(false);
                break;
            // kalo dia totalbadgenya 2 berarti dia akan menampilkan badge reachedLevel120 dan badge breakFree.
            case 2:
                BadgeBreakfree.SetActive(true);
                Badge120.SetActive(true);
                empty.SetActive(false);
                break;
            // kalo dia total badgenya selain 1 dan 2 maka dia akan menampilkan badge kosong
            default:
                empty.SetActive(true);
                Badge120.SetActive(false);
                BadgeBreakfree.SetActive(false);
                break;
        }*/

        if(dataPemain.angkaBadge < 1)
        {
            // kalo dia total badgenya kurang dari 1 maka dia akan menampilkan badge kosong
            empty.SetActive(true);
            Badge120.SetActive(false);
            BadgeBreakfree.SetActive(false);
        }else if(dataPemain.angkaBadge == 1)
        {
            // kalo dia totalbadgenya 1 berarti dia akan menampilkan badge reachedLevel120.
            Badge120.SetActive(true);
            empty.SetActive(false);
            BadgeBreakfree.SetActive(false);
        }else if(dataPemain.angkaBadge > 1)
        {
            // kalo dia totalbadgenya lebih dari 1 {2,3,4, inf} berarti dia akan menampilkan badge reachedLevel120 dan badge breakFree.
            BadgeBreakfree.SetActive(true);
            Badge120.SetActive(true);
            empty.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            dataPemain.levelPoint = 0;
            dataPemain.angkaBadge = 0;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            dataPemain.angkaBadge++;
        }else if (Input.GetKeyDown(KeyCode.G))
        {
            dataPemain.levelPoint = -1;
        }else if (Input.GetKeyDown(KeyCode.H))
        {
            dataPemain.levelPoint = 0;
        }

        if(easyModeAktif == true)
        {
            // Easy Mode
            EasyModeSystem.SetActive(true);
            if(dataPemain.levelPoint > 1)
            {
                TombolLanjutPutih.SetActive(true);
                TombolLanjutDark.SetActive(true);
                TombolLanjutPutih3.SetActive(true);
                TombolLanjutDark4.SetActive(true);
                TombolPlayBiasaPutih.SetActive(false);
                TombolPlayBiasaDark.SetActive(false);
                TombolPlayBiasaPutih3.SetActive(false);
                TombolPlayBiasaDark4.SetActive(false);
                TombolUlangPutih.SetActive(false);
                TombolUlangDark.SetActive(false);
                TombolUlangPutih3.SetActive(false);
                TombolUlangDark4.SetActive(false);
                textLevel.text = "Current Level : " + dataPemain.levelPoint;
            }
            else if(dataPemain.levelPoint == 0)
            {
                TombolLanjutPutih.SetActive(false);
                TombolLanjutDark.SetActive(false);
                TombolLanjutPutih3.SetActive(false);
                TombolLanjutDark4.SetActive(false);
                TombolPlayBiasaPutih.SetActive(true);
                TombolPlayBiasaDark.SetActive(true);
                TombolPlayBiasaPutih3.SetActive(true);
                TombolPlayBiasaDark4.SetActive(true);
                TombolUlangPutih.SetActive(false);
                TombolUlangDark.SetActive(false);
                TombolUlangPutih3.SetActive(false);
                TombolUlangDark4.SetActive(false);
                textLevel.text = "Good Luck :]";
            }
            else if(dataPemain.levelPoint == 1)
            {
                TombolLanjutPutih.SetActive(false);
                TombolLanjutDark.SetActive(false);
                TombolLanjutPutih3.SetActive(false);
                TombolLanjutDark4.SetActive(false);
                TombolPlayBiasaPutih.SetActive(true);
                TombolPlayBiasaDark.SetActive(true);
                TombolPlayBiasaPutih3.SetActive(true);
                TombolPlayBiasaDark4.SetActive(true);
                TombolUlangPutih.SetActive(false);
                TombolUlangDark.SetActive(false);
                TombolUlangPutih3.SetActive(false);
                TombolUlangDark4.SetActive(false);
                textLevel.text = "Good Luck :]";
            }
            else if (dataPemain.levelPoint < 0)
            {
                TombolLanjutPutih.SetActive(false);
                TombolLanjutDark.SetActive(false);
                TombolLanjutPutih3.SetActive(false);
                TombolLanjutDark4.SetActive(false);
                TombolPlayBiasaPutih.SetActive(false);
                TombolPlayBiasaDark.SetActive(false);
                TombolPlayBiasaPutih3.SetActive(false);
                TombolPlayBiasaDark4.SetActive(false);
                TombolUlangPutih.SetActive(true);
                TombolUlangDark.SetActive(true);
                TombolUlangPutih3.SetActive(true);
                TombolUlangDark4.SetActive(true);
                textLevel.text = "You've Ended all levels!!" ;
            }

        }
        else if(easyModeAktif == false)
        {
            // Kalo dia Hard Mode
            EasyModeSystem.SetActive(false);
            TombolPlayBiasaPutih.SetActive(true);
            TombolPlayBiasaDark.SetActive(true);
            TombolPlayBiasaPutih3.SetActive(true);
            TombolPlayBiasaDark4.SetActive(true);
            TombolLanjutPutih.SetActive(false);
            TombolLanjutDark.SetActive(false);
            TombolLanjutPutih3.SetActive(false);
            TombolLanjutDark4.SetActive(false);
        }


        switch (dataPemain.pilihanDifficulty)
        {
            case 1:
                // Easy Mode
                DifficultySelectionObject.SetActive(false);
                EasyModeText.SetActive(true);
                HardModeText.SetActive(false);
                WinsText.SetActive(false);
                CurrentLevelText.SetActive(true);
                easyModeAktif = true;
                //SaveSystem.SavePlayer(dataPemain);
                break;
            case 2:
                // Hard Mode
                DifficultySelectionObject.SetActive(false);
                EasyModeText.SetActive(false);
                HardModeText.SetActive(true);
                CurrentLevelText.SetActive(false);
                WinsText.SetActive(true);
                easyModeAktif = false;
                //SaveSystem.SavePlayer(dataPemain);
                break;

            default:
                // Jika Player belum memilih apa apa
                DifficultySelectionObject.SetActive(true);
                EasyModeText.SetActive(false);
                HardModeText.SetActive(false);
                CurrentLevelText.SetActive(false);
                WinsText.SetActive(false);
                easyModeAktif = false;
                //SaveSystem.SavePlayer(dataPemain);
                break;

        }

    }

    public void ContinueLevel()
    {
        
    }


    /**public void tambah()
    {
        angka += 1;
    }**/
}
