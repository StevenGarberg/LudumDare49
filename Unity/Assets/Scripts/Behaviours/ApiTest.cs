using LudumDare49.Unity.Services;
using UnityEngine;

namespace LudumDare49.Unity.Behaviours
{
    public class ApiTest : MonoBehaviour
    {
        public void Save()
        {
            PlayerService.Save();
        }

        public void Fetch()
        {
            PlayerService.Fetch();
        }
    }
}
