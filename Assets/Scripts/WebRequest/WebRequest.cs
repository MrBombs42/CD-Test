using UnityEngine.Networking;
using System;
using System.Collections;

public class WebRequest{    
    public IEnumerator Get(string url, Action<string> sucessCallback, Action<string> errorCallback)
    {
        using(UnityWebRequest request = UnityWebRequest.Get(url)){
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError){
                var errorMsg = string.Format("Error: {0}, {1}", request.error, request.downloadHandler.text);
                UnityEngine.Debug.LogError(errorMsg);
                errorCallback(errorMsg);
                yield break;
            }
            // Skip thr first 3 bytes (i.e. the UTF8 BOM)
            var result = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data, 3, request.downloadHandler.data.Length -3);  
            sucessCallback(result);
        }        
    }
}