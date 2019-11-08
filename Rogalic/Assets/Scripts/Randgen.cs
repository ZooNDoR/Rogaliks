using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;

public class Randgen : MonoBehaviour
{
    public GameObject Main_room;
    public GameObject Bonus_room;
    public GameObject Monster_room;
    public GameObject Trap_room;
    public GameObject Boss_room;
    List<GameObject> pref = new List<GameObject>();
    private GameObject u;
    public Random rnd = new Random();
    public int room_limit_bonus = 3, room_limit_enemy = 10, room_limit_trap = 2;
    private int room_limit_all;
    
    // Start is called before the first frame update
    bool Randgener()
        {
            if (Mathf.RoundToInt(Random.Range(0f, 10f)) > 5)
                return true;
            else
                return false;
        }
    public void Start()
    {
            room_limit_all = room_limit_bonus + room_limit_enemy + room_limit_trap + 1;
            int room_limit_bonus_be = 0, room_limit_enemy_be = 0, room_limit_trap_be = 0;
            int room_limit_all_be = 0;
            int var, xlen = 7, ylen = 7;
            int[,] map = new int[xlen, ylen];

            map[3, 3] = 1;map[4, 4] = 8;map[2, 2] = 8;map[4, 2] = 8;map[2, 4] = 8;

            while (room_limit_all_be < room_limit_all)
            {
                for (int i = 1; i < xlen - 1; i++){
                    for (int j = 1; j < ylen - 1; j++)
                    {
                        if ((map[i, j] == 1) || (map[i, j] == 2) || (map[i, j] == 3))
                        {
                            for (int u = -1; u <= 1; u++){
                                for (int v = -1; v <= 1; v++)
                                {
                                    if ((map[i + u, j + v] == 0) && (room_limit_all_be < room_limit_all) && (Mathf.Abs(v) != Mathf.Abs(u)))
                                    {
                                        if (Randgener())
                                        {
                                            if (room_limit_all_be == room_limit_all - 1)
                                            {
                                                map[i + u, j + v] = 7;
                                                room_limit_all_be++;
                                                break;
                                            }
                                            else
                                            {

                                                var = Mathf.RoundToInt(Random.Range(2f, 5f));
                                                switch (var)
                                                {
                                                    case 2:
                                                        if (room_limit_bonus_be < room_limit_bonus)
                                                        {
                                                            map[i + u, j + v] = var;
                                                            room_limit_all_be++;
                                                            room_limit_bonus_be++;
                                                        }
                                                        break;
                                                    case 3:
                                                        if (room_limit_enemy_be < room_limit_enemy)
                                                        {
                                                            map[i + u, j + v] = var;
                                                            room_limit_all_be++;
                                                            room_limit_enemy_be++;
                                                        }
                                                        break;
                                                    case 4:
                                                        if (room_limit_trap_be < room_limit_trap)
                                                        {
                                                            map[i + u, j + v] = var;
                                                            room_limit_all_be++;
                                                            room_limit_trap_be++;
                                                        }
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < xlen; i++){
                for (int j = 0; j < ylen; j++)
                {
                    switch(map[i, j]){
                        case 1:
                            u = Instantiate(Main_room, new Vector3(i*8-24,j*5-15,0), Quaternion.identity);
                            pref.Add(u);
                            break;
                        case 2:
                            u = Instantiate(Bonus_room, new Vector3(i*8-24,j*5-15,0), Quaternion.identity);
                            pref.Add(u);
                            break;
                        case 3:
                            u = Instantiate(Monster_room, new Vector3(i*8-24,j*5-15,0), Quaternion.identity);
                            pref.Add(u);
                            break;
                        case 4:
                            u = Instantiate(Trap_room, new Vector3(i*8-24,j*5-15,0), Quaternion.identity);
                            pref.Add(u);
                            break;
                        case 7:
                            u = Instantiate(Boss_room, new Vector3(i*8-24,j*5-15,0), Quaternion.identity);
                            pref.Add(u);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    
        // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.Space )){
            foreach(GameObject element in pref)
            {
                Destroy(element);
            }
            Start(); 
        }
            
    }
}
    

