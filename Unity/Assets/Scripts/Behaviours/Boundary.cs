using System.Collections.Generic;
using System.Linq;
using LudumDare49.Unity.Clients;
using LudumDare49.Unity.Models;
using Mirror;
using UnityEngine;

namespace LudumDare49.Unity.Behaviours
{
    public class Boundary : NetworkBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isServer) return;

            if (other.gameObject.CompareTag("Player"))
            {
                var loserId = other.gameObject.GetComponent<PlayerController>().Id;

                var gos = GameObject.FindGameObjectsWithTag("Player");
                var playerIds = new List<string>();
                foreach (var go in gos)
                {
                    playerIds.Add(go.GetComponent<PlayerController>().Id);
                }

                Destroy(other.gameObject);

                var winnerId = playerIds.FirstOrDefault(x => x != loserId) ?? "UNKNOWN";
                MatchClient.PostResults(new MatchResults
                {
                    WinnerId = winnerId,
                    LoserId = loserId
                });
                // TODO: Blood fx
                // TODO: Announce who won on clients
            }
            
            
        }
    }
}