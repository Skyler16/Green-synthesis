using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Texture2D cursorIcon;

    public static Game Get
    {
        get
        {
            return instance;
        }
    }
    static Game instance;

    bool isHolding = false;
    int objId = -1;

    public int lostScore = 0;
    public int getScore = 0;

    [SerializeField]
    GameObject pauseMenu;
    bool isPaused = false;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        lostScore = 0;
        getScore = 0;

        Vector2 cursorOffset = new Vector2(cursorIcon.width * 0.5f, cursorIcon.height * 0.5f);
        Cursor.SetCursor(cursorIcon, cursorOffset, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu();

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.transform.tag == "Resource")
                {
                    if (!isHolding)
                    {
                        Cursor.visible = false;

                        isHolding = true;
                        var ro = hit.transform.gameObject.GetComponent<ResoucePanelObject>();
                        objId = ro.objId;
                        ResourcePanel.Get.PickupObject(ro.gameObject);
                    }
                }
                if (hit.transform.tag == "Slot")
                {
                    if(isHolding)
                    {
                        Cursor.visible = true;
                        ResourcePanel.Get.PutDownObject();

                        Slot slot = hit.transform.gameObject.GetComponent<Slot>();
                        GameObject obj = Resources.Load<SynthesisData>("Object List").GetSynthesisGameObject(objId);
                        SynthesisPanel.Get.PlaceObject(slot, obj);

                        isHolding = false;
                    }
                    
                }
            }
        }
    }

    public void GameOver()
    {
        PauseGame();
        int totalScore = getScore - lostScore;
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ExitToMenu()
    {
        isPaused = false;
        //SceneManager.LoadScene()
    }
}
