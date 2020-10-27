using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MainSceneScript
{

    private static string Current_Level = "Mine";
    private static int Current_Level_Count = 0;
    private static int Max_Level_Count = 1;

    public static void NextLevel()
    {

        if (Current_Level_Count + 1 >= Max_Level_Count) { Application.Quit(0); } //win
        else
        {
            if (SceneManager.GetActiveScene().name.Contains("Bonus"))
            {

                Current_Level_Count++;
                SceneManager.LoadSceneAsync(Current_Level + "_Level_" + Current_Level_Count);

            }
            else
            {

                SceneManager.LoadSceneAsync(Current_Level + "_Bonus_0");

            }

        }

    }

}
