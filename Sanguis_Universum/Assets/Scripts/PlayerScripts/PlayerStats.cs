using UnityEngine.SceneManagement;
using System.Collections;

using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] GameObject DeadScreen;

    public int Health;
    public int Stamina;
    public int MaxHealth = 100;
    public bool dead;

    public bool key1;
    public bool key1Used;
    public int SceneIndex;

    private void Start()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Update()
    {
        HealAndDamage(); // simple function for test of mechanic
        SavesLoad();
    }

    private void SavesLoad()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            LoadAll();
            //StartCoroutine(LoadSceneCouratine());
            //LoadScene();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SavePlayer();
        }
        if (dead && Input.GetKeyDown(KeyCode.Space))
        {
            dead = true;
            LoadAll();
        }
    }

    public void Dead()
    {
        Time.timeScale = 0f;
        DeadScreen.SetActive(dead);
        Debug.LogError(dead);
    }
    public void Damage(int DamageAmount) // Player take damage and cannot have HP belove 0
    {
        Health -= DamageAmount;
        if (Health <= 0)
        {
            dead = true;
            Health = 0;
            Dead();
        }
    }
    public void LoadAll()
    {
        StartCoroutine(LoadScene());
        //LoadPlayerPosition();
        LoadPlayerStats();
        DeadScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public PlayerStats(int MaxHealth)
    {
        this.MaxHealth = MaxHealth;
        Health = MaxHealth;
    }
    public int GetHealth() { return Health; }
    public void Heal(int HealAmount) // Player take heal and cannot have HP more than 100
    {
        Health += HealAmount;
        if (Health >= MaxHealth)
            Health = MaxHealth;
    }

    public void HealAndDamage()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Damage(10);
            Debug.LogError(Health);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Heal(10);
            Debug.LogError(Health);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayerPosition()
    {
        Debug.LogError("Position");
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    IEnumerator LoadScene()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(data.SceneIndex);
        while (!AsyncLoad.isDone)
        {
            yield return null;
        }
    }
    /*
        public void LoadScene()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.SceneIndex);

        if(SceneIndex == data.SceneIndex)
        {
            LoadPlayerPosition();
        }
    }
    */
    public void LoadPlayerStats()
    {
        //Debug.LogError("Stats");

        PlayerData data = SaveSystem.LoadPlayer();
        Health = data.Health;
        Stamina = data.Stamina;
        MaxHealth = data.MaxHealth;
    }

    public void PickUpKey1()
    {
        if (!key1)
        {
            key1 = true;
            Debug.Log("I found a key of the first foor!");
        }
    }
    public void useKey1()
    {
        if (!key1Used)
        {
            Debug.Log("Door has been opened...");
        }
    }
    
}

    
