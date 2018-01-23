using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDate {
    public int trailNo;
    public float appleFallTime;
    public bool appleCatched;	
}

public class GameDateStore
{
    public IList<GameDate> myGameDataList;
    private string fileName;

    public GameDateStore() {
        myGameDataList = new List<GameDate>();
        fileName = "playRecords.csv";
    }

    public void addData(GameDate newData)
    {
        myGameDataList.Add(newData);
        saveDataToFile(newData);
    }

    public void saveDataToFile(GameDate newData)
    {
        if (!File.Exists(fileName))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine("TrailNo, AppleFallTime, AppleCatched");
            }
        }

        using (StreamWriter sw = File.AppendText(fileName))
        {
            sw.WriteLine(newData.trailNo + "," + newData.appleFallTime + "," + newData.appleCatched);
        }
    }
}