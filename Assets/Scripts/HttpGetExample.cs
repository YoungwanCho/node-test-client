using System.Collections;
using UnityEngine;

public class HttpGetExample : MonoBehaviour
{
    public string getUrl = "http://localhost:8081/zone?uuid=1020202&market=android&version=1.0.0";

    private void Start()
    {
        StartCoroutine("GetZone");
    }

    private IEnumerator GetZone()
    {
        Debug.Log("getting name from " + getUrl);

        WWW getName = new WWW(getUrl);

        yield return getName;

        Debug.Log(getName.text);

        Zone nameObject = JsonUtility.FromJson<Zone>(getName.text);

        Debug.Log("zone: " + nameObject.zone);
        Debug.Log("version_minor: " + nameObject.version_minor);
        Debug.Log("version_major: " + nameObject.version_major);
        Debug.Log("market_url: " + nameObject.market_url);
        Debug.Log("api_url: " + nameObject.api_url);
    }

    private class Zone
    {
        public string zone;
        public string version_minor;
        public string version_major;
        public string market_url;
        public string api_url;
    }
}
