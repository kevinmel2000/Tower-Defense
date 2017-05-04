using UnityEngine;
using UnityEngine.UI;

public class GameCondition : MonoBehaviour
{
    public int life;
    public Text labelLife;

    bool isWaveFinish;
    int numberOfZombies;

    public void GameLose()
    {
        Debug.Log("Game Lose");
    }

    public void GameWin()
    {
        Debug.Log("Game Win");
    }

    public void WaveFinish()
    {
        isWaveFinish = true;
    }

    void ZombieSpawn()
    {
        numberOfZombies++;
    }

    public void ZombieArrived()
    {
        if(life > 0)
        {
            life--;
        }
        else
        {
            GameLose();
        }
    }

    public void ZombieDead()
    {
        numberOfZombies--;
    }

    private void OnEnable()
    {
        WaveManager.Finish += WaveFinish;
        WaveManager.Spawn += ZombieSpawn;
        Zombie.Finish += ZombieArrived;
        Zombie.Dead += ZombieDead;
    }

    private void OnDisable()
    {
        WaveManager.Finish -= WaveFinish;
        WaveManager.Spawn -= ZombieSpawn;
        Zombie.Finish -= ZombieArrived;
        Zombie.Dead -= ZombieDead;
    }

    private void Update()
    {
        labelLife.text = life.ToString();
        if (isWaveFinish && (numberOfZombies <= 0)) GameWin();
    }
}