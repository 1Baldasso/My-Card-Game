using Assets._Scripts.Structures.Enumerators;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

namespace Assets._Scripts.Structures.AbstractClasses
{
    public abstract class Card
    {

        public UInt32 Id;
        public String Name;
        public String CardCode;
        public String Description;
        public String FlavorText;
        public UInt16 ManaCost;
        public string ImageURL;
        public Sprite Image;
        public List<CardTypeEnum> Types = new();
        public CardRegionEnum Region;
        public RarityEnum Rarity;
        public CardStateEnum CardState = CardStateEnum.OnDeck;

        public void LoadImage()
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(this.ImageURL);
            UnityWebRequestAsyncOperation asyncOperation = webRequest.SendWebRequest();
            asyncOperation.completed += HandleWebRequestCompleted;
        }
        void HandleWebRequestCompleted(AsyncOperation obj)
        {
            // Get the UnityWebRequest that completed
            UnityWebRequest webRequest = ((UnityWebRequestAsyncOperation)obj).webRequest;

            // Check for errors
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(webRequest.error);
                return;
            }

            // Get the downloaded image as a Texture2D
            Texture2D downloadedImage = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;

            // Create a new Sprite from the downloaded image
            Image = Sprite.Create(downloadedImage, new Rect(0, 0, downloadedImage.width, downloadedImage.height), new Vector2(0.5f, 0.5f));
        }
    }
}
