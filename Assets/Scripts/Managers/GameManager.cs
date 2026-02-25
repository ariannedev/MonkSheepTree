using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public WorldMover worldMover;
    public Player player;

    private bool isGameOver = false;
    void Awake() => Instance = this;

    //handle game over
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        //stop the world from moving
        worldMover.enabled = false;
        //stop the player moving
        player.FreezePhysics();
    }
}
