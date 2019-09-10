using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    private int count = 0;
    private int player = 1;
    private int[,] chess = new int[3, 3];
    //img ----bc
    public Texture2D img;

    void Awake()
    {
        img = (Texture2D)Resources.Load("timg");
    }


    // Use this for initialization
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Reset()
    {
        count = 0;
        player = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                chess[i, j] = 0;
            }
        }
    }

    private void OnGUI()
    {
        string aa = "";

        //构造一个空的GUIStyle
        GUIStyle bb = new GUIStyle();

        //设置bb正常显示时是背景图片
        bb.normal.background = img;
        GUI.Label(new Rect(0, 0, 1370, 780), aa, bb);

        //font size, text color, background color of button.
        GUI.skin.button.fontSize = 20;
        GUI.skin.label.fontSize = 30;
        GUI.skin.label.normal.textColor = Color.black;
        GUI.backgroundColor = Color.cyan;

        GUI.Label(new Rect(200, 180, 300, 50), "Player1 -- O");
        GUI.Label(new Rect(200, 230, 300, 50), "Player2 -- X");

        //press [reset] button.
        if (GUI.Button(new Rect(500, 400, 100, 50), "Reset"))
        {
            Reset();
        }

        //get results (if any) ---3 conditions.
        int result = GetResult();
        if (result == 1)
        {
            GUI.Label(new Rect(510, 20, 100, 50), "O wins");
        }
        else if (result == 2)
        {
            GUI.Label(new Rect(510, 20, 100, 50), "X wins");
        }
        else if (result == 3)
        {
            GUI.Label(new Rect(530, 20, 200, 50), "Tie!");
        }

        //chess 1---O   2---X
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chess[i, j] == 1)
                    GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "O");
                if (chess[i, j] == 2)
                    GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "X");
                //play chess
                if (GUI.Button(new Rect(i * 100 + 400, j * 100 + 80, 100, 100), "") && result == 0)
                {

                    if (player == 1)
                    {
                        chess[i, j] = 1;
                        player = 2;
                    }
                    else if (player == 2)
                    {
                        chess[i, j] = 2;
                        player = 1;
                    }
                    count++;
                }
            }
        }
    }

    int GetResult()
    {
        //Rows.
        for (int i = 0; i < 3; i++)
        {
            if (chess[i, 0] == chess[i, 1] && chess[i, 0] == chess[i, 2] && chess[i, 0] != 0)
            {
                return chess[i, 0]; //1---O wins
            }
        }

        //Columns.
        for (int j = 0; j < 3; j++)
        {
            if (chess[0, j] == chess[1, j] && chess[0, j] == chess[2, j] && chess[0, j] != 0)
            {
                return chess[0, j]; //2---X wins
            }
        }

        //Diagonals.
        if (chess[0, 0] == chess[1, 1] && chess[0, 0] == chess[2, 2] && chess[0, 0] != 0) return chess[0, 0];
        if (chess[0, 2] == chess[1, 1] && chess[0, 2] == chess[2, 0] && chess[0, 2] != 0) return chess[0, 2];

        //if the game is Tied.
        if (count == 9) return 3;   //tie!
        return 0;
    }
}
