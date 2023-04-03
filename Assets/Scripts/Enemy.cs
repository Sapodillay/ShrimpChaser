using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Pathfinding _pathFinding;

    [SerializeField] float moveSpeed = 5;

    [SerializeField] GameObject player;

    bool isStunned = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(WalkToPlayer());
        }   
        if(Input.GetKeyDown(KeyCode.V))
        {
            Stun();
        }

    }



    void HandlePlayerDamage(int damageAmount)
    {
        Debug.Log("DAMAGING PLAYER... ");
    }

    void Stun()
    {
        isStunned = true;
        Debug.Log("Stunning enemy");
    }



    IEnumerator WalkToPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        List<Node> path = _pathFinding.FindPath(gameObject.transform.position, playerPosition);

        if (path == null)
        {
            Debug.Log("No walkable path find for enemy: (" + playerPosition.x + ":" + playerPosition.y + ")");
        }

        Vector2 startingPos = gameObject.transform.position;
        Node previosNode = null;

        bool isPlayerFound = false;

        //Reverse nodes to make easier to traverse in a while loop
        path.Reverse();

        //Loop through each node and lerp between them
        while(!isPlayerFound | !isStunned)
        {
            Debug.Log(isStunned);
            Node node = path[path.Count - 1];

            for (float f = 0; f <= moveSpeed; f+= Time.deltaTime)
            {
                //If starting node, interpolate between enemy starting position and the first node
                if (previosNode == null)
                {
                    gameObject.transform.position = Vector2.Lerp(startingPos, node.worldPosition, f / moveSpeed);
                }
                else
                {
                    gameObject.transform.position = Vector2.Lerp(previosNode.worldPosition, node.worldPosition, f / moveSpeed);
                }
                yield return null;
            }
            previosNode = node;

            //Check if player has been found
            //Checking this here isn't the best as it only checks every node. change in the future to do in a different tick.
            if (Vector2.Distance(gameObject.transform.position, player.transform.position) < 1 )
            {
                isPlayerFound = true;
                Debug.Log("Player has been found");
            }


            //Check if the player has moved to a new node.
            bool hasMoved = Mathf.Abs(Vector3.Magnitude(playerPosition - player.transform.position)) > 1 ? true : false;
            if (hasMoved)
            {
                //Update path
                playerPosition = player.transform.position;
                path = _pathFinding.FindPath(gameObject.transform.position, playerPosition);
                path.Reverse();
                previosNode = null;
                startingPos = gameObject.transform.position;
            }
            else
            {
                //Remove traversed node
                path.Remove(node);
            }


        }


        if (isPlayerFound)
        {
            HandlePlayerDamage(5);
        }

        yield return null;         
    }

}
