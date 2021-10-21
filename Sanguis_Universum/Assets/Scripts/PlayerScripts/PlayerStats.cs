using UnityEngine.SceneManagement;
using System.Collections;

using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] GameObject DeadScreen;

    public int Health = 50;
    public int Stamina = 8;
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
        //HealAndDamage(); // simple function for test of mechanic
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadScene();
            LoadPlayerStats();
            LoadPlayerPosition();
            //Debug.Log("L");
            //StartCoroutine(LoadScene());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SavePlayer();
            //Debug.Log("K");
        }
        if (dead && Input.GetKeyDown(KeyCode.R))
        {
            LoadLastSave();
        }
    }
    public void Damage(int DamageAmount) // Player take damage and cannot have HP belove 0
    {
        Health -= DamageAmount;
        if (Health <= 0)
        {
            dead = true;
            Health = 0;
            if (dead)
            {
                DeadScreen.SetActive(dead);
                Time.timeScale = 0f;
                Debug.LogError(dead);
            }
        }

    }
    public void LoadLastSave()
    {
        LoadScene();
        LoadPlayerStats();
        DeadScreen.SetActive(false);
        Time.timeScale = 1f;
        Debug.LogError("Button");
    }
    public PlayerStats(int MaxHealth)
    {
        this.MaxHealth = MaxHealth;
        Health = MaxHealth;
    }
    public int GetHealth()  {    return Health;     }
    //Weapon Collider Script
    /*
    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.tag == "Player")
        {
            hit.GetComponent<PlayerHealth>().TakeDamage(15);

            CameraShake.Shake(0.25f, 0.4f);

        }

    }
    */
    
    public  void Heal(int HealAmount) // Player take heal and cannot have HP more than 100
    {
        Health += HealAmount;
        if (Health >= MaxHealth)
            Health = MaxHealth;
    }
    /*
    public void HealAndDamage()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Damage(10);
        if (Input.GetKeyDown(KeyCode.Mouse1))
            Heal(10);
    }
    */
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayerStats()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Health = data.Health;
        Stamina = data.Stamina;
        MaxHealth = data.MaxHealth;
    }
    /*

    IEnumerator LoadScene()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        AsyncOperation AsyncLoad = SceneManager.LoadSceneAsync(data.SceneIndex);

        //SceneManager.LoadScene(data.SceneIndex);
        while (!AsyncLoad.isDone)
        {
        LoadPlayerPosition();
            yield return null;
        }
    }
    */


    public void LoadScene()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.SceneIndex);
    }
    public void LoadPlayerPosition()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

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