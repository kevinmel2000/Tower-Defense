using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject zombie;
    public Transform[] lines;
    public int numberOfZombie;
    public float deltaZombieSpawn;
    public float standbyTime;

    float indexDeltaZombieSpawn;
    int numberOfLine;

    public delegate void OnWaveFinishHandler();
    public delegate void OnZombieSpawnHandler();

    public static event OnWaveFinishHandler Finish;
    public static event OnZombieSpawnHandler Spawn;

    void SpawnZombie(int line)
    {
        Transform posY = lines[line];
        Vector3 newPos = new Vector3(this.transform.position.x, posY.position.y, 0);
        GameObject bul = Instantiate(zombie, newPos, Quaternion.identity) as GameObject;
        Spawn();
    }

    void OnWaveFinish()
    {
        Finish();
    }

    private void Start()
    {
        indexDeltaZombieSpawn = 0;
        numberOfLine = lines.Length;
    }

    private void Update()
    {
        if((numberOfZombie > 0) && (standbyTime <= 0))
        {
            if(indexDeltaZombieSpawn <= 0)
            {
                SpawnZombie(Random.Range(0, numberOfLine));
                indexDeltaZombieSpawn = deltaZombieSpawn;
                numberOfZombie--;
            }
            indexDeltaZombieSpawn -= Time.deltaTime;
        }

        if (standbyTime > 0) standbyTime -= Time.deltaTime;
        if (numberOfZombie == 0) OnWaveFinish();
    }
}