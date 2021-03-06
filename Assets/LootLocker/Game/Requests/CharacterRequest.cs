﻿using LootLocker;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using Newtonsoft.Json;
using System.Linq;



namespace LootLocker.Requests
{

    public class LootLockerGetCurrentLoadouttoDefaultCharacterResponse : LootLockerResponse
    {
        public bool success { get; set; }
        public LootLockerDefaultCharacterLoadout[] loadout { get; set; }

        public string[] GetContexts()
        {
            string[] context = loadout.Select(x => x.asset.context).ToArray();
            return context;
        }

        public LootLockerCommonAsset[] GetAssets()
        {
            LootLockerCommonAsset[] context = loadout.Select(x => x.asset).ToArray();
            return context;
        }
    }

    public class LootLockerDefaultCharacterLoadout
    {
        public int variation_id { get; set; }
        public int instance_id { get; set; }
        public DateTime mounted_at { get; set; }
        public LootLockerCommonAsset asset { get; set; }
        public LootLockerRental rental { get; set; }
    }

    public class LootLockerLoadouts
    {
        public string variation_id { get; set; }
        public int instance_id { get; set; }
        public DateTime mounted_at { get; set; }
        public LootLockerCommonAsset asset { get; set; }
    }

    public class LootLockerUpdateCharacterRequest
    {
        public bool is_default { get; set; }
        public string name { get; set; }
        public string type { get; set; }

    }

    public class LootLockerEquipByIDRequest
    {
        public int instance_id { get; set; }
    }


    public class LootLockerEquipByAssetRequest
    {
        public int asset_id { get; set; }
        public int asset_variation_id { get; set; }
    }

    public class LootLockerCharacterLoadoutResponse : LootLockerResponse
    {
        public bool success { get; set; }
        public LootLockerLootLockerLoadout[] loadouts { get; set; }
    }

    public class LootLockerLootLockerLoadout : ILootLockerStageData
    {
        public LootLockerCharacter character { get; set; }
        public LootLockerLoadouts[] loadout { get; set; }
    }

    public class LootLockerCharacter
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public bool is_default { get; set; }
    }

    public class LootLockerCharacterAsset
    {
        public string Asset { get; set; }
    }

}

namespace LootLocker
{
    public partial class LootLockerAPIManager
    {
        public static void GetCharacterLoadout(Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.characterLoadouts;

            string getVariable = endPoint.endPoint;

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void GetOtherPlayersCharacterLoadout(LootLockerGetRequest data, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getOtherPlayersCharacterLoadouts;

            string getVariable = string.Format(endPoint.endPoint, data.getRequests[0], data.getRequests[1]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void UpdateCharacter(LootLockerGetRequest lootLockerGetRequest, LootLockerUpdateCharacterRequest data, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            EndPointClass endPoint = LootLockerEndPoints.current.updateCharacter;

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void EquipIdAssetToDefaultCharacter(LootLockerEquipByIDRequest data, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            EndPointClass endPoint = LootLockerEndPoints.current.equipIDAssetToDefaultCharacter;

            string getVariable = endPoint.endPoint;

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void EquipGlobalAssetToDefaultCharacter(LootLockerEquipByAssetRequest data, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            EndPointClass endPoint = LootLockerEndPoints.current.equipGlobalAssetToDefaultCharacter;

            string getVariable = endPoint.endPoint;

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void EquipIdAssetToCharacter(LootLockerGetRequest lootLockerGetRequest, LootLockerEquipByIDRequest data, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            EndPointClass endPoint = LootLockerEndPoints.current.equipIDAssetToCharacter;

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void EquipGlobalAssetToCharacter(LootLockerGetRequest lootLockerGetRequest, LootLockerEquipByAssetRequest data, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            string json = "";
            if (data == null) return;
            else json = JsonConvert.SerializeObject(data);

            EndPointClass endPoint = LootLockerEndPoints.current.equipGlobalAssetToCharacter;

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, json, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void UnEquipIdAssetToDefaultCharacter(LootLockerGetRequest lootLockerGetRequest, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.unEquipIDAssetToDefaultCharacter;

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void UnEquipIdAssetToCharacter(LootLockerGetRequest lootLockerGetRequest, Action<LootLockerCharacterLoadoutResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.unEquipIDAssetToCharacter;

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerCharacterLoadoutResponse response = new LootLockerCharacterLoadoutResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerCharacterLoadoutResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void GetCurrentLoadOutToDefaultCharacter(Action<LootLockerGetCurrentLoadouttoDefaultCharacterResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getCurrentLoadoutToDefaultCharacter;

            string getVariable = endPoint.endPoint;

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerGetCurrentLoadouttoDefaultCharacterResponse response = new LootLockerGetCurrentLoadouttoDefaultCharacterResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerGetCurrentLoadouttoDefaultCharacterResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);//getEquipableContextToDefaultCharacter
        }

        public static void GetCurrentLoadOutToOtherCharacter(LootLockerGetRequest lootLockerGetRequest, Action<LootLockerGetCurrentLoadouttoDefaultCharacterResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getOtherPlayersCharacterLoadouts;

            string getVariable = string.Format(endPoint.endPoint, lootLockerGetRequest.getRequests[0]);

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerGetCurrentLoadouttoDefaultCharacterResponse response = new LootLockerGetCurrentLoadouttoDefaultCharacterResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerGetCurrentLoadouttoDefaultCharacterResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        public static void GetEquipableContextToDefaultCharacter(Action<LootLockerContextResponse> onComplete)
        {
            EndPointClass endPoint = LootLockerEndPoints.current.getEquipableContextToDefaultCharacter;

            string getVariable = endPoint.endPoint;

            LootLockerServerRequest.CallAPI(getVariable, endPoint.httpMethod, null, (serverResponse) =>
            {
                LootLockerContextResponse response = new LootLockerContextResponse();
                if (string.IsNullOrEmpty(serverResponse.Error))
                {
                    response = JsonConvert.DeserializeObject<LootLockerContextResponse>(serverResponse.text);
                    response.text = serverResponse.text;
                    onComplete?.Invoke(response);
                }
                else
                {
                    response.message = serverResponse.message;
                    response.Error = serverResponse.Error;
                    onComplete?.Invoke(response);
                }
            }, true);
        }

        //public static void GetInventory(Action<InventoryResponse> onComplete)
        //{
        //    EndPointClass endPoint = LootLockerEndPoints.current.getInventory;

        //    ServerRequest.CallAPI(endPoint.endPoint, endPoint.httpMethod, null, onComplete: (serverResponse) =>
        //    {
        //        InventoryResponse response = new InventoryResponse();
        //        if (string.IsNullOrEmpty(serverResponse.Error))
        //        {
        //            response = JsonConvert.DeserializeObject<InventoryResponse>(serverResponse.text);
        //            response.text = serverResponse.text;
        //            onComplete?.Invoke(response);
        //        }
        //        else
        //        {
        //            response.message = serverResponse.message;
        //            response.Error = serverResponse.Error;
        //            onComplete?.Invoke(response);
        //        }
        //    }, true);
        //}
    }
}