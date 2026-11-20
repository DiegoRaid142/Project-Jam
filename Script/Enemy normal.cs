using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemynormal : MonoBehaviour
{


    Vector3 Move;
    [SerializeField] float speed;
    bool Horizontalmove;
    void Start()
    {
        Horizontalmove = true;
        
    }


    void Update()
    {
        EnemyMovement(); 
    }

    void EnemyMovement()
    {
        var Position = Move.x * transform.position;
       // Position = Horizontalmove;
      

        transform.position = Position;
    }
}
