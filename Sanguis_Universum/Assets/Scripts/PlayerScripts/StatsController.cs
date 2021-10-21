using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController 
{ 
    //PlayerStats kk = new PlayerStats();
    public int Health;
    public int MaxHealth = 100;
    public int health;
    public StatsController(int health)
    {
        this.health = Health;
        Health = MaxHealth;
       // Health = kk.Health;
    }
    public int GetHealth()
    {
        return health;
    }
}
