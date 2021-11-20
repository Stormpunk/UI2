using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeybindManager : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text forward, backwards, left, right;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));

            baseSetup[i].keyDisplayText.text = keys[baseSetup[i].keyName].ToString();
        }
        //keys.Add("Forward", KeyCode.W);
        //keys.Add("Backwards", KeyCode.S);
        //keys.Add("Left", KeyCode.A);
        //keys.Add("Right", KeyCode.D);

        //forward.text = keys["Forward"].ToString();
        //backwards.text = keys["Backwards"].ToString();
        //left.text = keys["Left"].ToString();
        //right.text = keys["Right"].ToString();

    }
    [System.Serializable]
    public struct KeyUISetup
    {
        public string keyName;
        public Text keyDisplayText;
        public string defaultKey;
    }

    public KeyUISetup[] baseSetup;
    public GameObject currentKey;
    public Color32 changedKey = new Color32(39, 171, 249, 255);
    public Color32 selectedKey = new Color32(239, 116, 36, 255);


    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
    }
    public void ChangeKeys(GameObject clickedKey)
    {
        currentKey = clickedKey;
        if(clickedKey != null) 
        {
            clickedKey.GetComponent<Image>().color = selectedKey;
        }
    }

    private void OnGUI()
    {
        string newKey = "";
        Event e = Event.current;
        if(currentKey != null)
        {
            if (e.isKey)
            {
                newKey = e.keyCode.ToString();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }
            if (newKey != "")
            {
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                currentKey.GetComponentInChildren<Text>().text = newKey;
                currentKey.GetComponent<Image>().color = changedKey;
                currentKey = null; 
            }
        }
      
    }
}