using UnityEngine;

public class LogBuildHandler : MonoBehaviour
{

    public void Start()
    {
#if DEVELOPMENT_BUILD
        Debug.logger.logEnabled=true;
#else
        Debug.logger.logEnabled=false;
#endif
    }
}