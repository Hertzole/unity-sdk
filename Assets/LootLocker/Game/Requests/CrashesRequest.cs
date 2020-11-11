﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker;
using LootLockerRequests;


namespace LootLockerRequests
{
    public class SubmittingACrashLogRequest
    {
        public string logFileName { get; set; }
        public string logFilePath { get; set; }
        public string game_version { get; set; }
        public string type_identifier { get; set; }
        public string local_crash_time { get; set; }
    }
}

namespace LootLocker
{
    public partial class LootLockerAPIManager
    {
        public static void SubmittingACrashLog(SubmittingACrashLogRequest data, Action<LootLockerResponse> onComplete)
        {
            EndPointClass requestEndPoint = LootLockerEndPoints.current.submittingACrashLog;

            Dictionary<string, string> formData = new Dictionary<string, string>();

            if(!string.IsNullOrEmpty(data.game_version)) formData.Add("game_version", data.game_version);
            if(!string.IsNullOrEmpty(data.type_identifier)) formData.Add("type_identifier", data.type_identifier);
            if(!string.IsNullOrEmpty(data.local_crash_time)) formData.Add("local_crash_time", data.local_crash_time);

            if (string.IsNullOrEmpty(data.logFileName))
            {
                string[] splitFilePath = data.logFilePath.Split(new char[] { '\\', '/' });
                string defaultFileName = splitFilePath[splitFilePath.Length - 1];
                data.logFileName = defaultFileName;
            }

            ServerRequest.UploadFile(requestEndPoint.endPoint, requestEndPoint.httpMethod, System.IO.File.ReadAllBytes(data.logFilePath), 
                data.logFileName, "application/zip", formData, onComplete: (serverResponse) =>
            {
                LootLockerResponse response = new LootLockerResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerResponse>(serverResponse.text);
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, useAuthToken: false);
        }
    }
}
