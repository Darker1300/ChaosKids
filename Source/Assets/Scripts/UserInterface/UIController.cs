using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    MainMenu,
    Game,
    Settings,
    Paused,
    EndScreen,
}

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject m_MainMenuUI = null;
	[SerializeField] private GameObject m_GameUI = null;
	[SerializeField] private GameObject m_SettingsUI = null;
	[SerializeField] private GameObject m_PausedUI = null;
	[SerializeField] private GameObject m_EndGameUI = null;

	[SerializeField] private UIState m_CurrentState;
    [SerializeField] private GameObject m_CurrentUI = null;

    private Stack<UIState> m_UIStack;

    #region SingltonePlusAwake

    private static UIController m_Instance;         // The current instance 
	public static UIController Instance             // The public current instance
	{
		get { return m_Instance; }
	}

	/// <summary>
	/// Called as script is loaded
	/// </summary>
	void Awake()
	{
		// Initialize Singleton
		if (m_Instance != null && m_Instance != this)
			Destroy(this.gameObject);
		else
			m_Instance = this;

        m_CurrentUI = m_MainMenuUI;
        m_UIStack = new Stack<UIState>();
        LoadMainMenu();
	}
    #endregion

    // Returns to the previous UI in the stack
    public void ReturnToPreviousUI()
    {
        if (m_UIStack.Count >= 2)

        {
            m_UIStack.Pop();
            OnExitPreviousState();
            UIState state = m_UIStack.Peek();
            m_CurrentState = state;
            UpdateState();
        }
    }

    // What happens when the previous state when the current state is changed
    void OnExitPreviousState()
    {

        switch (m_CurrentState) 
        {
            case UIState.MainMenu:
                //unload menu stuff
                break;

            case UIState.Game:
                break;

            case UIState.Settings:
                break;

            case UIState.Paused:
                break;

            case UIState.EndScreen:
                break;
        }
    }

	void UpdateState()
    {
        OnExitPreviousState(); // only run if state changes
        m_CurrentState = m_UIStack.Peek();
        m_CurrentUI.SetActive(false);

        switch (m_CurrentState)
        {
            case UIState.MainMenu:
                m_CurrentUI = m_MainMenuUI;
                break;

            case UIState.Game:
                m_CurrentUI = m_GameUI;
                break;

            case UIState.Settings:
                m_CurrentUI = m_SettingsUI;
                break;

            case UIState.Paused:
                m_CurrentUI = m_PausedUI;
                break;

            case UIState.EndScreen:
                m_CurrentUI = m_EndGameUI;
                break;
        }

        m_CurrentUI.SetActive(true);
        OnEnterState();
    }

    // Do something when entering new state
    void OnEnterState()
    {
        switch (m_CurrentState)
        {
            case UIState.MainMenu:
                break;

            case UIState.Game:
                break;

            case UIState.Settings:
                break;

            case UIState.Paused:
                break;

            case UIState.EndScreen:
                break;
        }
    }
		
    public void LoadMainMenu()
    {
        m_UIStack.Clear();
        m_UIStack.Push(UIState.MainMenu);
        UpdateState();
    }

    public void LoadGame()
    {
        m_UIStack.Clear();
        m_UIStack.Push(UIState.Game);
        UpdateState();
    }
    
    public void LoadSettings()
    {
        m_UIStack.Push(UIState.Settings);
        UpdateState();
    }

    public void LoadPaused()
    {
        m_UIStack.Push(UIState.Paused);
        UpdateState();
    }

    public void LoadEndScreen()
    {
        m_UIStack.Clear();
        m_UIStack.Push(UIState.EndScreen);
        UpdateState();
    }

}
