using Services;
using UnityEngine;

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
