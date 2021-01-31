using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RandomItem : MonoBehaviour
{
    public Image[] images;
    public Sprite[] sprites;
    public Text[] textures;
    public GameObject end;

    private Dictionary<string, int> dic = new Dictionary<string, int>();
    private Dictionary<string, int> existDic = new Dictionary<string, int>();
    private string spriteName;
    private string[] order = new string[13];
    private string clickName;
    private string printName;
    private int value;
    private bool isClickRight = false;
    private int findTypeNum;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            int random = Random.Range(0, sprites.Length);
            images[i].GetComponent<Image>().sprite = sprites[random];
            spriteName = sprites[random].name;
            if (!dic.ContainsKey(spriteName))
                dic.Add(spriteName, 1);

            else
                dic[spriteName] ++;
        }

        do
        {
            findTypeNum = Random.Range(0, textures.Length);
        } while (findTypeNum > dic.Count);

        for (int j = 0; j < findTypeNum; j++)
        {
            int itemNum;
            string itemName;
            do
            {
                do
                {
                    itemNum = Random.Range(0, sprites.Length);
                }
                while (!dic.ContainsKey(sprites[itemNum].name));
                itemName = sprites[itemNum].name;
            }
            while (existDic.ContainsKey(itemName));
            int findNum = Random.Range(0, dic[itemName]) + 1;
            existDic.Add(itemName, findNum);
            order[j] = itemName;
            textures[j].text = itemName + "*" + findNum;
        }
        //foreach (var item in dic)
        //Debug.Log(item.Key + item.Value);

        //Debug.Log(order[0]);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Click()
    {
        isClickRight = false;
        clickName = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name;
        int zeroCount = 0;
        
        for (int m = 0; m < existDic.Count; m++)
        {
            printName = order[m];
            value = existDic[printName];
            if(value > 0)
            {
                if (printName.Equals(clickName))
                {
                    value--;
                    if(value == 0)
                    {
                        textures[m].color = new Color(255, 255, 255, 0);
                        zeroCount++;
                    }

                    existDic[printName] = value;
                    isClickRight = true;

                }

            } else
            {
                zeroCount++;
            }
            
            textures[m].text = printName + "*" + value;
        }

        //Debug.Log(zeroCount);

        FindItems.judge.GetMousePosition(isClickRight);
        if (isClickRight)
            EventSystem.current.currentSelectedGameObject.SetActive(false);

        if(zeroCount == existDic.Count)
        {
            end.SetActive(true);
        }
    }
}
