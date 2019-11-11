using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;

public class Generator : MonoBehaviour
{
    public GameObject Character;
    private GameObject ban;
    public GameObject Main_room;
    public GameObject Bonus_room;
    public GameObject Monster_room;
    public GameObject Trap_room;
    public GameObject Boss_room;
    
    private static int xlen = 9, ylen = 9;
    private GameObject[,] map = new  GameObject[xlen, ylen];
    private GameObject some_Object;
    public Random rnd = new Random();
    public int room_limit_bonus = 3, room_limit_enemy = 10, room_limit_trap = 2;
    private int room_limit_all;
    
    // Start is called before the first frame update
    bool Randgener()//absolutely random function
        {
            return (Mathf.RoundToInt(Random.Range(0f, 1f))==1)?true:false;
        }
    void Start()
    {
        Character = Instantiate(Character, new Vector3(0,0,-0.5f), Quaternion.identity);
        Generation();
    }

        // Update is called once per frame
    void FixedUpdate()
    {
        if ( Input.GetKeyDown ( KeyCode.Space )){
            Clearing();
            Generation();
            
        }     
    }
    void Clearing()
    {
            for (int i = 0; i < xlen; i++){
                for (int j = 0; j < ylen; j++)
                {
                    Destroy(map[i,j]);
                    map[i,j] = null;
                }   
            }
    }
    void Generation(){
        ban = new GameObject("empty");
        room_limit_all = room_limit_bonus + room_limit_enemy + room_limit_trap + 1;
        int room_limit_bonus_be = 0, room_limit_enemy_be = 0, room_limit_trap_be = 0, room_limit_all_be = 0;
        int rand;
        map[3, 3] = Main_room; map[2, 2] = ban;map[4, 4] = ban;map[2, 4] = ban;map[4, 2] = ban;

        while (room_limit_all_be < room_limit_all)
        {
            for (int i = 2; i < xlen - 2; i++){
                for (int j = 2; j < ylen - 2; j++)
                {
                    if ((map[i, j] != null) && (map[i, j] != ban))
                    {
                        for (int u = -1; u <= 1; u++){
                            for (int v = -1; v <= 1; v++)
                            {
                                if ((map[i + u, j + v] == null) && (room_limit_all_be < room_limit_all) && (Mathf.Abs(v) != Mathf.Abs(u)) && Randgener())
                                {
                                    
                                    if (room_limit_all_be == room_limit_all - 1)
                                    {
                                        map[i + u, j + v] = Boss_room;
                                        room_limit_all_be++;
                                        break;
                                    }
                                    else
                                    {

                                        rand = Mathf.RoundToInt(Random.Range(2f, 5f));
                                        switch (rand)
                                        {
                                            case 2:
                                                if (room_limit_bonus_be < room_limit_bonus)
                                                {
                                                    map[i + u, j + v] = Bonus_room;
                                                    room_limit_all_be++;
                                                    room_limit_bonus_be++;
                                                }
                                                break;
                                            case 3:
                                                if (room_limit_enemy_be < room_limit_enemy)
                                                {
                                                    map[i + u, j + v] = Monster_room;
                                                    room_limit_all_be++;
                                                    room_limit_enemy_be++;
                                                }
                                                break;
                                            case 4:
                                                if (room_limit_trap_be < room_limit_trap)
                                                {
                                                    map[i + u, j + v] = Trap_room;
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
        for (int i = 0; i < xlen; i++){
            for (int j = 0; j < ylen; j++)
            {
                if((map[i, j] != null) && (map[i, j] != ban))
                {
                    some_Object = Instantiate(map[i, j], new Vector3(i*8-24,j*5-15,0), Quaternion.identity);
                    if((map[i+1, j] == null) || (map[i+1, j] == ban)){
                        some_Object.transform.Find("right_door").gameObject.SetActive(false);
                    }
                    if((map[i-1, j] == null) || (map[i-1, j] == ban)){
                        some_Object.transform.Find("left_door").gameObject.SetActive(false);
                    }
                    if((map[i, j+1] == null) || (map[i, j+1] == ban)){
                        some_Object.transform.Find("up_door").gameObject.SetActive(false);
                    }
                    if((map[i, j-1] == null) || (map[i, j-1] == ban)){
                        some_Object.transform.Find("down_door").gameObject.SetActive(false);
                    }
                    map[i, j] = some_Object;
                }
            }
        }
    }
}
    

