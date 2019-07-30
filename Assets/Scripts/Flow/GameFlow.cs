using UnityEngine;

public class GameFlow : Flow
{
    MainEntry mainEntry;

    public static bool isGame;

    public override void Initialize()
    {
        mainEntry = GameObject.FindObjectOfType<MainEntry>();

      
        initialized = true;
        isGame = true;
    }

    public override void Update(float dt)
    {
        if (isGame)
        {
           
        }

    }

    public override void FixedUpdate(float dt)
    {
        
        if (isGame)
        {
           
        }

    }

    public override void EndFlow()
    {
      

    }


    public void PlayerDied()
    {
        isGame = false;
        //UIManager.Instance.CallDeathScreen();
    }
}
