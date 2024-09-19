using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.UI;

public class gerakan : MonoBehaviour
{

    ///////
    // Ads
    string gameIdGP = "3883299";
    string gameIdAppStore = "3883298";
    string IklanBiasa = "video";
    string myPlacementId = "rewardedVideo";

    public static int Angkajatuh = 0;
    public int posYminus = -12;
    public int posYplus = 25;
   
    //kecepatan
    public static float kecepatan = 0f;
    float kanankiri;
    public static float lompatan = 700f;
    [HideInInspector]public static int lompatVelo = 19;
    public int KecepatanTurun;
    public static int kecepatanSetelah;
    public static float kecepatanRotasi;

    //object
    public GameObject finish;
    public GameObject adaEnergi;
    public GameObject habisEnergi;
    public GameObject vignetteMati;

    //boolian
    bool AdaEnergi = true;
    bool HabisEnergi = false;
    bool flip = true;
    bool Respawn = false;
    bool IsPlayStore;
    public static bool sampai = false;
    public static bool Gakhabis = false;
    private bool vignetteAktif = false;
    public static bool bisaLompat = false;
    public static bool bisaMaju = false;

    //RigidBody2D
    public Rigidbody2D rigid;

    //Lain
    public int pilihan2;
    private int Energi;
    public Transform hilang;
    public static float detik;
    public TextMeshProUGUI detikTulisan;
    public static bool detikAktif;
    int levelSekarang = 1;

    //RespawnPoint
    public Vector3 respawn;
    public static Quaternion rotasi;

    ///////

	public GameObject[] api;

    void Start()
    {
        PlayerPrefs.SetInt("wins", 0);
        PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex);
        //Advertisement.Initialize(gameIdGP, false);

        Application.targetFrameRate = 300;

        kecepatanSetelah = KecepatanTurun;

        ///Vector3 respawner
        respawn = transform.position;
        rotasi = transform.rotation;
        rigid = GetComponent<Rigidbody2D>();

        detikAktif = true;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            energiberkurangHorizontal();
        }

        if (Input.GetKey(KeyCode.W))
        {
            jumpButton();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            energiberkurangHorizontal();
        }

        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (Energi == 1)
        {

            duaenergi.Energi = 2;
            empatenergi.Energi = 4;
            satuenergi.Energi = 1;

        }

        if(Gakhabis == true)
        {
            // Habis
        }else if(Gakhabis == false)
        {
            // GkHabis
        }

        // Mengatur aktif atau tidak-nya Vignette Saat Mati
        if (vignetteAktif == true)
        {
            vignetteMati.SetActive(true);
        } else if (vignetteAktif == false)
        {
            vignetteMati.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
        }
        ///horizontal movement
        kanankiri = CrossPlatformInputManager.GetAxisRaw("Horizontal") * kecepatan;
        InvokeRepeating(nameof(SaveData), 1f, 10f);

        //if (bisaMaju) { rigid.velocity += Vector2.right * kecepatan * 50 * Time.deltaTime; }
        if (detikAktif) { detik += Time.deltaTime; }

        /*if (CrossPlatformInputManager.GetButton("Horizontal") || duaenergi.Energi > 0 || empatenergi.Energi > 0 || satuenergi.Energi > 0)
        {
            rigid.velocity += Vector2.right * kecepatan * Time.deltaTime;
        }*/

    }

    public void GerakanKeKanan()
    {
        //bisaMaju = true;
    }public void GerakanKeUPKanan()
    {
        //bisaMaju = false;
    }

    public void jumpButton()
    {
        if (rigid.velocity.y == 0)
        {
            rigid.velocity = Vector2.up * lompatVelo;
        }
    }

    private void LateUpdate()
    {
        if (scoreasli.Score == 1)
        {
            badge.Badge = "Nice!!!";
        }

        else if (scoreasli.Score == 0 )
        {
            badge.Badge = "Not Bad";
        }

        else if(scoreasli.Score < 0 && scoreasli.Score > -10)
        {
            badge.Badge = "Bad but at least you won";
        }

        else if(scoreasli.Score < -10 && scoreasli.Score > -50)
        {
            badge.Badge = "Bruh";
        }

        else if(scoreasli.Score < -50)
        {
            badge.Badge = "Terrible";
        }
    }

    public void gkhabis()
    {
        habisEnergi.SetActive(false);
        Time.timeScale = 1f;
        HabisEnergi = false;
    }

    void habis()
    {
        habisEnergi.SetActive(true);
        Time.timeScale = 1f;
        HabisEnergi = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, 0);
        }

        transform.Translate(kanankiri * Time.fixedDeltaTime, 0, 0);
        //Vector2 kanan = kanankiri * Vector2.right * kecepatan;

        /// lompatan
        if (CrossPlatformInputManager.GetButton("Jump") && rigid.velocity.y == 0 /*bisaLompat == true*/)
        {
            rigid.velocity = Vector2.up * lompatVelo;
        }

        /// jatuh bakal balik lagi  
        if (rigid.position.y < posYminus)
        {
            FindObjectOfType<audiomanager>().Play("mati");
            VignetteAktif();
            Invoke(nameof(VignetteTidakAktif), 0.5f);
            transform.position = respawn;
            satuenergi.Energi = 1;
            fixedEnergi();
            kesentuhjatuh.angka = 1;
            kalokitajatuhdiabakanspawnlagi.angka = 1;
            isibalok.angka = 1;
            kesentuhjatuhkebawah.angkaJ = 1;
            kenahilangasli.angka = 1;
            //totalscore.angkaMati++;
            //totalscore.totalsementaramati++;
            //PlayerPrefs.SetInt("S", totalscore.totalsementaramati);
            //totalscore.angka--;
            //totalscore.totalsementara--;
            //PlayerPrefs.SetInt("H", totalscore.totalsementara);
            //totalscore.dataPemain.deaths++;
            //totalscore.dataPemain.scores--;
            duaenergi.Energi = 2;
            empatenergi.Energi = 4;
            lompatVelo = 19;
            lompatan = 900f;
            scoreasli.Score -= 1;
            DeathsStat.deaths += 1;
            kecepatan = 10f;
        }
        else if (rigid.position.y > posYminus)
        {
            kesentuhjatuh.angka = 0;
            kalokitajatuhdiabakanspawnlagi.angka = 0;
            isibalok.angka = 0;
            kesentuhjatuhkebawah.angkaJ = 0;
            kenahilangasli.angka = 0;
        }

        if (rigid.position.y > posYplus)
        {
            FindObjectOfType<audiomanager>().Play("mati");
            VignetteAktif();
            Invoke(nameof(VignetteTidakAktif), 0.5f);
            transform.position = respawn;
            satuenergi.Energi = 1;
            fixedEnergi();
            kalokitajatuhdiabakanspawnlagi.angka2 = 1;
            kesentuhjatuhkebawah.angkaJ = 1;
            //totalscore.angkaMati++;
            //totalscore.totalsementaramati++;
            //PlayerPrefs.SetInt("S", totalscore.totalsementaramati);
            //totalscore.angka--;
            //totalscore.totalsementara--;
            //PlayerPrefs.SetInt("H", totalscore.totalsementara);
            //totalscore.dataPemain.deaths++;
            //totalscore.dataPemain.scores--;
            duaenergi.Energi = 2;
            empatenergi.Energi = 4;
            lompatVelo = 19;
            lompatan = 900f;
            scoreasli.Score -= 1;
            DeathsStat.deaths += 1;
            kecepatan = 10f;
        }
        else if (rigid.position.y != posYplus)
        {
            kalokitajatuhdiabakanspawnlagi.angka2 = 0;
            kesentuhjatuhkebawah.angkaJ = 0;
        }

        if (Respawn == true)
        {
            FindObjectOfType<audiomanager>().Play("mati");
        }

    }

    public void VignetteAktif()
    {
        vignetteAktif = true;
    }

    public void VignetteTidakAktif()
    {
        vignetteAktif = false;
    }

    public void SaveData()
    {
        //SaveSystem.SavePlayer(totalscore.dataPemain);
    } 

    public void flipping()
    {
        flip = !flip;

        Vector3 flipp = transform.localScale;
        flipp.x *= -1;
        transform.localScale = flipp;
    }

    public void mati()
    {
        transform.position = respawn;
    }

    public void respawnn()
    {
        Respawn = true;
    }
    /*
    public void HimpunanData(totalscore player)
    {
        wins = player.totalwins;
        deaths = player.totalmati;
        scores = player.total;
        SaveSystem.SavePlayer(player);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // kena RedzParable
        if(collision.gameObject.tag == "red")
        {
            FindObjectOfType<audiomanager>().Play("mati");
            VignetteAktif();
            Invoke(nameof(VignetteTidakAktif), 0.5f);
            transform.position = respawn;
            fixedEnergi();
            Pintu.angka3 = 1;
            Pintu2.angka3 = 1;
            keteken.angka3 = 1;
            keteken.aktif = false;
            keteken2.aktif = false;
            keteken2.angka3 = 1;
            kenahilangasli.angka3 = 1;
            kesentuhjatuhkebawah.angka3J = 1;
            kesentuhjatuh.angka3 = 1;
            isibalok.angka3 = 1;
            //totalscore.angkaMati++;
            //totalscore.totalsementaramati++;
            //PlayerPrefs.SetInt("S", totalscore.totalsementaramati);
            //totalscore.angka--;
            //totalscore.totalsementara--;
            //PlayerPrefs.SetInt("H", totalscore.totalsementara);
            //totalscore.dataPemain.deaths++;
            //totalscore.dataPemain.scores--;
            duaenergi.Energi = 2;
            empatenergi.Energi = 4;
            satuenergi.Energi = 1;
            lompatVelo = 19;
            lompatan = 900f;
            scoreasli.Score -= 1;
            kecepatan = 10f;
        }
        else
        {
            kenahilangasli.angka3 = 0;
            kesentuhjatuhkebawah.angka3J = 0;
            kesentuhjatuh.angka3 = 0;
            isibalok.angka3 = 0;
        }

        /// blooxzButton
        if (collision.gameObject.tag == "button")
        {
            nutup.kecepatan = -4;
            memanjang.kecepatan = 2;
            rotating.VrotasiTambah = 100;
        }

        if(collision.gameObject.tag == "greenz")
        {
            naik.kecepatan = 2;
            Pintu.kecepatan = -2;
            Pintu2.kecepatan = 2;
        }

        if(collision.gameObject.tag == "balok" || collision.gameObject.tag == "balok2")
        {
            bisaLompat = true;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "balok" || collision.gameObject.tag == "balok2")
        {
            bisaLompat = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /// kelevel1-120
        if (other.tag == "greenzParable2")
        {
            //totalscore.angkaWin++;
            //totalscore.totalsementarawin++;
            //PlayerPrefs.SetInt("T", totalscore.totalsementarawin);
            //totalscore.angka++;
            //totalscore.totalsementara++;
            //PlayerPrefs.SetInt("H", totalscore.totalsementara);
            //totalscore.dataPemain.wins++;
            //totalscore.dataPemain.scores++;
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + scoreasli.Score);
            PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths") + DeathsStat.deaths);
            PlayerPrefs.SetInt("scene", SceneManager.GetActiveScene().buildIndex + 1);
            finished();
        }

        // Ending
        if(other.gameObject.tag == "greenzParable3")
        {
            //totalscore.angkaWin++;
            //totalscore.totalsementarawin++;
            //PlayerPrefs.SetInt("T", totalscore.totalsementarawin);
            //totalscore.angka++;
            //totalscore.totalsementara++;
            //PlayerPrefs.SetInt("H", totalscore.totalsementara);
            //totalscore.dataPemain.wins++;
            //totalscore.dataPemain.scores++;
            transform.position = hilang.position;
            Nyala2.aktif = true;
            Invoke(nameof(Ending), 5f);
        }


        if (other.gameObject.tag == "greenz2")
        {
            keteken.aktif = true;
            keteken.targetbawah = -10.782f;
        }

        if(other.gameObject.tag == "greenz")
        {
            FindObjectOfType<audiomanager>().Play("tombolpintu");
            Pintu.kecepatan = -2;
            Pintu2.kecepatan = 2;
        }

        if(other.gameObject.tag == "booxz2")
        {
            FindObjectOfType<audiomanager>().Play("tombolpintu");
            naik.kecepatan = 10f;
        }

        if(other.gameObject.tag == "blooxz")
        {
            keteken2.aktif = true;
            keteken2.targetBawah = -0.467f;
            keteken.warna = true;
        }

        if(other.gameObject.tag == "gkhabis")
        {
            Gakhabis = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "blooxz")
        {
            keteken2.hancur = true;
        }
    }

    // SFX Energi habis
    public void SfxAktif()
    {
        cumaduaenergi.SFXAktif = false;
        cumaempatenergi.sfxAktif = false;
        cumasatuenergi.sfxAktif = false;
    }

    public void gkfinish()
    {
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    void finished()
    {
        finish.SetActive(true);
        Time.timeScale = 0f;
    }

    public void energihabis()
    {
        if(duaenergi.Energi == 0)
        {
            AdaEnergi = false;
            if (AdaEnergi)
            {
                adaEnergi.SetActive(true);
            }
            else
            {
                adaEnergi.SetActive(false);
            }
            HabisEnergi = true;
            if (HabisEnergi)
            {
                habisEnergi.SetActive(true);
            }
            else
            {
                habisEnergi.SetActive(false);
            }
        }

    }

    public void energigkhabis()
    {
        if(duaenergi.Energi > 0)
        {
            AdaEnergi = true;
            if (AdaEnergi)
            {
                adaEnergi.SetActive(true);
            }
            else
            {
                adaEnergi.SetActive(false);
            }
            HabisEnergi = false;
            if (HabisEnergi)
            {
                habisEnergi.SetActive(true);
            }
            else
            {
                habisEnergi.SetActive(false);
            }
        }

    }

    public void Ulang()
    {
        FindObjectOfType<audiomanager>().Play("Retry");
        transform.position = respawn;
        Pintu.angka = 1;
        Pintu2.angka = 1;
        cumaduaenergi.angkaP = 1;
        keteken.angka = 1;
        keteken.aktif = false;
        keteken2.aktif = false;
        keteken2.angka = 1;
        kesentuhjatuh.angka = 1;
        kalokitajatuhdiabakanspawnlagi.angka = 1;
        isibalok.angka = 1;
        kenahilangasli.angka = 1;
        kesentuhjatuhkebawah.angkaJ = 1;
        Score.Energi = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        lompatVelo = 19;
        lompatan = 900f;
        kecepatan = 10f;
        scoreasli.Score -= 1;
        //totalscore.angkaMinus--;
        //totalscore.angka--;
        //totalscore.totalsementara--;
        //PlayerPrefs.SetInt("H", totalscore.totalsementara);
    }

    public void fixedEnergi()
    {
        Energi = 1;
        effectJatuh.aktif = true;
        Invoke("tidakFixedLockEnergi", 0.3f);
    }

    public void tidakFixedLockEnergi()
    {
        Energi = 2;
        effectJatuh.aktif = false;
    }

    public void keluar()
    {
        FindObjectOfType<audiomanager>().Play("tombol");
        AudioONorOFF.Mute = true;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        switch (Time.timeScale)
        {
            case 1:
                AudioONorOFF.angka = 2;
                AudioONorOFF.angkaSementara = 2;
                DeathsStat.deaths = 0;
                scoreasli.Score = 1;
                Score.Energi = 2;
                duaenergi.Energi = 2;
                empatenergi.Energi = 4;
                satuenergi.Energi = 1;
                Gakhabis = false;
                effectJatuh.aktif = false;
                //Advertisement.Show(IklanBiasa);
                break;
        }

        finish.SetActive(false);
    }

    public void lanjutlevel2()
    {
        ///greenzParable1
        SceneManager.LoadScene(3);
        //totalscore.dataPemain.levelPoint = 2;
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel3()
    {
        ///greenzParable2
        SceneManager.LoadScene(4);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel4()
    {
        ///greenzParable2
        SceneManager.LoadScene(5);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel5()
    {
        ///greenzParable2
        SceneManager.LoadScene(6);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel6()
    {
        ///greenzParable2
        SceneManager.LoadScene(7);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel7()
    {
        ///greenzParable2
        SceneManager.LoadScene(8);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel8()
    {
        ///greenzParable2
        SceneManager.LoadScene(9);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }public void lanjutlevel9()
    {
        ///greenzParable2
        SceneManager.LoadScene(10);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel10()
    {
        ///greenzParable2
        SceneManager.LoadScene(11);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }public void lanjutlevel11()
    {
        ///greenzParable2
        SceneManager.LoadScene(12);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel12()
    {
        ///greenzParable2
        SceneManager.LoadScene(13);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel13()
    {
        ///greenzParable2
        SceneManager.LoadScene(14);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel14()
    {
        ///greenzParable2
        SceneManager.LoadScene(15);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel15()
    {
        ///greenzParable2
        SceneManager.LoadScene(16);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel16()
    {
        ///greenzParable2
        SceneManager.LoadScene(17);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel17()
    {
        ///greenzParable2
        SceneManager.LoadScene(18);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel18()
    {
        ///greenzParable2
        SceneManager.LoadScene(19);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel19()
    {
        ///greenzParable2
        SceneManager.LoadScene(20);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel20()
    {
        ///greenzParable2
        SceneManager.LoadScene(21);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel21()
    {
        ///greenzParable2
        SceneManager.LoadScene(22);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel22()
    {
        ///greenzParable2
        SceneManager.LoadScene(23);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel23()
    {
        ///greenzParable2
        SceneManager.LoadScene(24);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel24()
    {
        ///greenzParable2
        SceneManager.LoadScene(25);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel25()
    {
        ///greenzParable2
        SceneManager.LoadScene(26);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel26()
    {
        ///greenzParable2
        SceneManager.LoadScene(27);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel27()
    {
        ///greenzParable2
        SceneManager.LoadScene(28);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel28()
    {
        ///greenzParable;
        SceneManager.LoadScene(29);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel29()
    {
        ///greenzParable;
        SceneManager.LoadScene(30);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel30()
    {
        ///greenzParable;
        SceneManager.LoadScene(31);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel31()
    {
        ///greenzParable;
        SceneManager.LoadScene(32);
        Time.timeScale = 1;
        DeathsStat.deaths = 0;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        scoreasli.Score = 1;
        Gakhabis = false;
        finish.SetActive(false);
    }
    public void lanjutlevel32()
    {
        //greeenzParable;
        SceneManager.LoadScene(33);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel33()
    {
        //greenzParable;
        SceneManager.LoadScene(34);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel34()
    {
        //greenzParable;
        SceneManager.LoadScene(35);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel35()
    {
        SceneManager.LoadScene(36);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel36()
    {
        ///greenzParable2;
        SceneManager.LoadScene(37);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel37()
    {
        ///greenzParable;
        SceneManager.LoadScene(38);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel38()
    {
        ///greenzParable2;
        SceneManager.LoadScene(39);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel39()
    {
        ///greenzParable2;
        SceneManager.LoadScene(40);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel40()
    {
        ///greenzParable;
        SceneManager.LoadScene(41);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel41()
    {
        SceneManager.LoadScene(42);
        scoreasli.Score = 1;
        DeathsStat.deaths = 0;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel42()
    {
        SceneManager.LoadScene(43);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel43()
    {
        SceneManager.LoadScene(44);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel44()
    {
        SceneManager.LoadScene(45);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel45()
    {
        SceneManager.LoadScene(46);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel46()
    {
        SceneManager.LoadScene(47);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }


    public void lanjutlevel47()
    {
        SceneManager.LoadScene(48);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel48()
    {
        SceneManager.LoadScene(49);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel49()
    {
        SceneManager.LoadScene(50);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel50()
    {
        SceneManager.LoadScene(51);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel51()
    {
        SceneManager.LoadScene(52);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel52()
    {
        SceneManager.LoadScene(53);
        scoreasli.Score = 1;
        DeathsStat.deaths = 0;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel53()
    {
        SceneManager.LoadScene(54);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel54()
    {
        SceneManager.LoadScene(55);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel55()
    {
        SceneManager.LoadScene(56);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel56()
    {
        SceneManager.LoadScene(57);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel57()
    {
        SceneManager.LoadScene(58);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel58()
    {
        SceneManager.LoadScene(59);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel59()
    {
        SceneManager.LoadScene(60);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel60()
    {
        SceneManager.LoadScene(61);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel61()
    {
        SceneManager.LoadScene(62);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel62()
    {
        SceneManager.LoadScene(63);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel63()
    {
        SceneManager.LoadScene(64);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel64()
    {
        SceneManager.LoadScene(65);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    } public void lanjutlevel65()
    {
        SceneManager.LoadScene(66);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel66()
    {
        SceneManager.LoadScene(67);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel67()
    {
        SceneManager.LoadScene(68);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel68()
    {
        SceneManager.LoadScene(69);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel69()
    {
        SceneManager.LoadScene(70);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel70()
    {
        SceneManager.LoadScene(71);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel71()
    {
        SceneManager.LoadScene(72);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel72()
    {
        SceneManager.LoadScene(73);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel73()
    {
        SceneManager.LoadScene(74);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel74()
    {
        SceneManager.LoadScene(75);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel75()
    {
        SceneManager.LoadScene(76);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel76()
    {
        SceneManager.LoadScene(77);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel77()
    {
        SceneManager.LoadScene(78);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel78()
    {
        SceneManager.LoadScene(79);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel79()
    {
        SceneManager.LoadScene(80);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel80()
    {
        SceneManager.LoadScene(81);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel81()
    {
        SceneManager.LoadScene(82);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel82()
    {
        SceneManager.LoadScene(83);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel83()
    {
        SceneManager.LoadScene(84);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel84()
    {
        SceneManager.LoadScene(85);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel85()
    {
        SceneManager.LoadScene(86);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel86()
    {
        SceneManager.LoadScene(87);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel87()
    {
        SceneManager.LoadScene(88);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel88()
    {
        SceneManager.LoadScene(89);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel89()
    {
        SceneManager.LoadScene(90);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel90()
    {
        SceneManager.LoadScene(91);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel91()
    {
        SceneManager.LoadScene(92);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel92()
    {
        SceneManager.LoadScene(93);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel93()
    {
        SceneManager.LoadScene(94);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel94()
    {
        SceneManager.LoadScene(95);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel95()
    {
        SceneManager.LoadScene(96);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel96()
    {
        SceneManager.LoadScene(97);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel97()
    {
        SceneManager.LoadScene(98);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel98()
    {
        SceneManager.LoadScene(99);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel99()
    {
        SceneManager.LoadScene(100);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel100()
    {
        SceneManager.LoadScene(101);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }

    public void lanjutlevel101()
    {
        SceneManager.LoadScene(102);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void lanjutlevel102()
    {
        SceneManager.LoadScene(103);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel103()
    {
        SceneManager.LoadScene(104);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel104()
    {
        SceneManager.LoadScene(105);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel105()
    {
        SceneManager.LoadScene(106);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel106()
    {
        SceneManager.LoadScene(107);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel107()
    {
        SceneManager.LoadScene(108);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel108()
    {
        SceneManager.LoadScene(109);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel109()
    {
        SceneManager.LoadScene(110);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel110()
    {
        SceneManager.LoadScene(111);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel111()
    {
        SceneManager.LoadScene(112);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel112()
    {
        SceneManager.LoadScene(113);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel113()
    {
        SceneManager.LoadScene(114);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel114()
    {
        SceneManager.LoadScene(115);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel115()
    {
        SceneManager.LoadScene(116);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel116()
    {
        SceneManager.LoadScene(117);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel117()
    {
        SceneManager.LoadScene(118);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel118()
    {
        SceneManager.LoadScene(119);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }
    public void lanjutlevel119()
    {
        SceneManager.LoadScene(120);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1f;
    }
    public void lanjutlevel120()
    {
        SceneManager.LoadScene(121);
        DeathsStat.deaths = 0;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    public void UlangDariAwal()
    {
        //totalscore.dataPemain.levelPoint = 1;
    }

    public void Ending()
    {
        SceneManager.LoadScene(122);
        //totalscore.dataPemain.angkaBadge++;
        //totalscore.dataPemain.levelPoint = -1;
        AudioONorOFF.Mute = true;
        AudioONorOFF.angka = 2;
        AudioONorOFF.angkaSementara = 2;
        scoreasli.Score = 1;
        duaenergi.Energi = 2;
        empatenergi.Energi = 4;
        satuenergi.Energi = 1;
        Gakhabis = false;
        finish.SetActive(false);
        Time.timeScale = 1;
    }

    //lanjut

    public void energiberkurang()
    {
        kurangenergi();
    }

    public void kurang()
    {
        energiberkurangHorizontal();
    }

    public void energiberkurangHorizontal()
    {
        duaenergi.Energi -= 1;
        empatenergi.Energi -= 1;
        satuenergi.Energi -= 1;
    }

    public void energiberkuranglevel3()
    {
        kurangenergi();
    }

    public void kurangenergi()
    {
        if(rigid.velocity.y > 0)
        {
            duaenergi.Energi -= 1;
            empatenergi.Energi -= 1;
            satuenergi.Energi -= 1;
        }
    }

    public void lompatlompat()
    {
        FindObjectOfType<audiomanager>().Play("lompat");
    }

}
