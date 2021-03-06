﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker;
using LootLocker.Requests;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LootLocker.Requests
{
    public class LootLockerGetAllKeyValuePairsResponse : LootLockerResponse
    {
        public bool success { get; set; }
        public int streamedObjectCount = 0;
        public LootLockerInstanceStoragePair[] keypairs;
    }

    public class LootLockerInstanceStoragePair
    {
        public int instance_id { get; set; }
        public LootLockerStorage storage { get; set; }
    }

    public class LootLockerStorage
    {
        public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }


    public class LootLockerAssetDefaultResponse : LootLockerResponse
    {
        public bool success { get; set; }
        public LootLockerStorage[] storage { get; set; }
    }


    public class LootLockerCreateKeyValuePairRequest
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class LootLockerUpdateOneOrMoreKeyValuePairRequest
    {
        public LootLockerCreateKeyValuePairRequest[] storage { get; set; }
    }


    public class LootLockerInspectALootBoxResponse : LootLockerResponse
    {
        public bool success { get; set; }
        public LootLockerContent[] contents { get; set; }
    }

    public class LootLockerContent
    {
        public int asset_id { get; set; }
        public int? asset_variation_id { get; set; }
        public int? asset_rental_option_id { get; set; }
        public int weight { get; set; }
    }

    public class LootLockerOpenLootBoxResponse : LootLockerResponse
    {
        public bool success { get; set; }
        public bool check_grant_notifications { get; set; }
    }

}

namespace LootLocker
{
    public partial class LootLockerAPIManager
    {
        public static void GetAllKeyValuePairs(Action<LootLockerGetAllKeyValuePairsResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getAllKeyValuePairs;

            string getVariable = endPoint.endPoint;

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, onComplete: (serverResponse) =>
            {
                LootLockerGetAllKeyValuePairsResponse response = new LootLockerGetAllKeyValuePairsResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerGetAllKeyValuePairsResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void GetAllKeyValuePairsToAnInstance(LootLockerGetRequest data, Action<LootLockerAssetDefaultResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getAllKeyValuePairsToAnInstance;

            string getVariable = string.Format(endPoint.endPoint, data.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, onComplete: (serverResponse) =>
            {
                LootLockerAssetDefaultResponse response = new LootLockerAssetDefaultResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerAssetDefaultResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void GetAKeyValuePairById(LootLockerGetRequest data, Action<LootLockerAssetDefaultResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getAKeyValuePairById;
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            string getVariable = string.Format(endPoint.endPoint, data.getRequests[0], data.getRequests[1]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, onComplete: (serverResponse) =>
            {
                LootLockerAssetDefaultResponse response = new LootLockerAssetDefaultResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerAssetDefaultResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void CreateKeyValuePair(LootLockerGetRequest lootLockerGetRequest, LootLockerCreateKeyValuePairRequest data, Action<LootLockerAssetDefaultResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.createKeyValuePair;
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, onComplete: (serverResponse) =>
            {
                LootLockerAssetDefaultResponse response = new LootLockerAssetDefaultResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerAssetDefaultResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void UpdateOneOrMoreKeyValuePair(LootLockerGetRequest lootLockerGetRequest, LootLockerUpdateOneOrMoreKeyValuePairRequest data, Action<LootLockerAssetDefaultResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.updateOneOrMoreKeyValuePair;
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, onComplete: (serverResponse) =>
            {
                LootLockerAssetDefaultResponse response = new LootLockerAssetDefaultResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerAssetDefaultResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void UpdateKeyValuePairById(LootLockerGetRequest lootLockerGetRequest, LootLockerCreateKeyValuePairRequest data, Action<LootLockerAssetDefaultResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.updateKeyValuePairById;
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0], lootLockerGetRequest.getRequests[1]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, onComplete: (serverResponse) =>
            {
                LootLockerAssetDefaultResponse response = new LootLockerAssetDefaultResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerAssetDefaultResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void DeleteKeyValuePair(LootLockerGetRequest data, Action<LootLockerAssetDefaultResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.deleteKeyValuePair;

            string getVariable = string.Format(endPoint.endPoint, data.getRequests[0], data.getRequests[1]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, onComplete: (serverResponse) =>
            {
                LootLockerAssetDefaultResponse response = new LootLockerAssetDefaultResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerAssetDefaultResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void InspectALootBox(LootLockerGetRequest data, Action<LootLockerInspectALootBoxResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.deleteKeyValuePair;

            string getVariable = string.Format(endPoint.endPoint, data.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, onComplete: (serverResponse) =>
            {
                LootLockerInspectALootBoxResponse response = new LootLockerInspectALootBoxResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerInspectALootBoxResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void OpenALootBox(LootLockerGetRequest data, Action<LootLockerOpenLootBoxResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.deleteKeyValuePair;

            string getVariable = string.Format(endPoint.endPoint, data.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, onComplete: (serverResponse) =>
            {
                LootLockerOpenLootBoxResponse response = new LootLockerOpenLootBoxResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    LootLockerSDKManager.DebugMessage(serverResponse.text);
                    response = JsonConvert.DeserializeObject<LootLockerOpenLootBoxResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.text = serverResponse.text;
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }
    }
}