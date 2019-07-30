using UnityEngine;

public class PlayerManager
{
    #region Singleton Pattern
    private static PlayerManager instance = null;
    private PlayerManager() { }
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }
    #endregion

    public Player player;
    public GameFlow gameFlow;

    public void Initialize(GameFlow gameFlow)
    {
     

    }

    public void UpdateManager(float dt)
    {
     
    }

    public void FixedUpdateManager(float dt)
    {
       

    }

    public void StopManager()
    {//Reset everything
        instance = null;
    }


    void SpawnPlayer()
    {
      
    }

    void GameOver()
    {
     
    }


}
