using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject precissionStrikeObj;
    public enum MainGameStates
    {
        NEWWORLD,FLARE,SQAUDDEPLOY,EXPLOREPLAN,NIGHTDEFENSE
    }
    public MainGameStates maingamestates;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.RightDragEvent += PrecissionStrikeToggle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StateHandler()
    {
        switch (maingamestates)
        {
            case MainGameStates.NEWWORLD:
                break;
            case MainGameStates.FLARE:

                break;
            case MainGameStates.SQAUDDEPLOY:
                break;
            case MainGameStates.EXPLOREPLAN:
                //turn on precision strike if left down
                

                //PrecissionStrikeEnabler()
                //InputManager.

                break;
            case MainGameStates.NIGHTDEFENSE:
                break;
            default:
                break;
        }

    }
    //turn on/off strike 
    public void PrecissionStrikeToggle(bool state)
    {
        Debug.Log("StrikeUiTOggled");
        if (state)
        {
            precissionStrikeObj.SetActive(true);

        }
        else precissionStrikeObj.SetActive(false);
    
    }
}
