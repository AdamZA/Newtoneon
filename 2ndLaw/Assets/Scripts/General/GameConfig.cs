using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Newtoneon/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Player")]
    public float shotSpeed = 8f;
    public float playerRecoilSpeed = 3f;
    public float shotCooldown = 0.3f;
    public float gunSafetyDelay = 0.5f;

    [Header("Scoring")]
    public int killScore = 50;
    public int scorePerSpeedStep = 400;

    [Header("Enemy Difficulty")]
    public float enemySpeedIncrement = 0.25f;
    public float enemySpeedCap = 3f;
    public int killsPerExtraEnemy = 20;
    public int maxEnemiesPerWave = 15;
}
