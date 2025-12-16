// Skrypt jest podpiety do Level Managera ze sceny wyboru levelu, z niego korzysta LvlManager

using System.Collections.Generic;
using UnityEngine;

// zeby dodac level trzeba tu zrobic przypisania obiektow, dodac nazwe listy do LevelManager w SelectLevel()
// dodac LevelDataScriptableData z info o levelu
// uproscic proces, wyjebac ten skrypt i wkleic te listy do leveli
// a do nich przypisy

public class Beatmap_level : MonoBehaviour
{
    public List<object> level1 = new List<object>()
    { //id, delay, hasSpawned (int)
        16, 0f, 0,
        14, 1f, 0,
        12, 2f, 0,
        14, 3f, 0,
        16, 4f, 0,
        16, 5f, 0,
        16, 6f, 0,
        14, 8f, 0,
        14, 9f, 0,
        14, 10f, 0,
        16, 12f, 0,
        16, 13f, 0,
        16, 14f, 0,
        16, 16f, 0,
        14, 17f, 0,
        12, 18f, 0,
        14, 19f, 0,
        16, 20f, 0,
        16, 21f, 0,
        16, 22f, 0,
        16, 23f, 0,
        14, 24f, 0,
        14, 25f, 0,
        16, 26f, 0,
        14, 27f, 0,
        12, 28f, 0,
        
    };
    
    public List<object> level2 = new List<object>()
    {
        0, 0f, 0,
        1, 1f, 0,
        2, 2f, 0,
        3, 3f, 0,
        4, 4f, 0,
        5, 5f, 0,
        6, 6f, 0,
        7, 7f, 0,
        8, 8f, 0,
        9, 9f, 0,
        10, 10f, 0,
        11, 11f, 0,
        12, 12f, 0,
        13, 13f, 0,
        14, 14f, 0,
        15, 15f, 0,
        16, 16f, 0,
        17, 17f, 0,
        18, 18f, 0,
        19, 19f, 0,
        20, 20f, 0,
        21, 21f, 0,
        22, 22f, 0,
        23, 23f, 0,
        24, 24f, 0,
        25, 25f, 0,
        26, 26f, 0,
        27, 27f, 0,
        28, 28f, 0,
        29, 29f, 0,
        30, 30f, 0,
        31, 31f, 0,
        32, 32f, 0,
        33, 33f, 0,
        34, 34f, 0,
        35, 35f, 0,
        36, 36f, 0,
        37, 37f, 0,
        38, 38f, 0,
        39, 39f, 0,
        40, 40f, 0,
        41, 41f, 0,
        42, 42f, 0,
        43, 43f, 0,
        44, 44f, 0,
        45, 45f, 0,
        46, 46f, 0,
        47, 47f, 0,
        48, 48f, 0,
        49, 49f, 0,
        50, 50f, 0,
        51, 51f, 0,
        52, 52f, 0,
        53, 53f, 0,
        54, 54f, 0,
        55, 55f, 0,
        56, 56f, 0,
        57, 57f, 0,
        58, 58f, 0,
        59, 59f, 0,
        60, 60f, 0,
        20, 62f, 0,
        40, 62f, 0,
        50, 62f, 0,
    };

    public List<object> level3 = new List<object>()
    {
      0, 0f, 0,  
    };

    public List<object> undertale_ending = new List<object>()
    { // bpm 100, tact 3
        18, 0f, 0,
		25, 0.5f, 0,
		21, 1f, 0,
		20, 2f, 0,
		21, 2.5f, 0,
		23, 3f, 0,
		// ---
		16, 5.5f, 0,
		18, 6f, 0,
		25, 6.5f, 0,
		21, 7f, 0,
		20, 8f, 0,
		21, 8.5f, 0,
		23, 9f, 0,
		// --- upper line
		39, 10f, 0,
		40, 10.5f, 0,
		39, 11f, 0,
		40, 11.125f, 0,
		39, 11.25f, 0,
		35, 11.5f, 0,
		// bottom line beat 1
		18, 12f, 0,
		25, 12.5f, 0,
		21, 13f, 0,
		20, 14f, 0,
		21, 14.5f, 0,
		23, 15f, 0,
		// upper line beat 1
		37, 12f, 0,
		42, 13.5f, 0,
		45, 14.5f, 0,
		42, 15f, 0,
		44, 16f, 0,
		45, 16.5f, 0,
		47, 17f, 0,
		44, 17.5, 0,
		45, 18f, 0,
		// --- bottom line beat 2
		16, 17.5f, 0,
		18, 18f, 0,
		25, 18.5f, 0,
		21, 19f, 0,
		20, 20f, 0,
		21, 20.5f, 0,
		23, 21f, 0,
		// --- upperline beat 2
        44, 19.5f, 0,
        42, 20.5f, 0,
        40, 20.75f, 0,
        39, 21f, 0,
    };

 // jakbys sie zdecydowal na scriptabla
// using UnityEngine;
// using System.Collections.Generic;

// [CreateAssetMenu(fileName = "NewData", menuName = "Data/MyData")]
// public class MyData : ScriptableObject
// {
//     [System.Serializable]
//     public class DataEntry
//     {
//         public int intValue;
//         public float floatValue;
//         public bool boolValue;
//     }

//     public List<DataEntry> dataEntries = new List<DataEntry>();
// }




}
