using Assets._Scripts.Structures.Enumerators;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

namespace Assets._Scripts.Structures.AbstractClasses.CardProps
{
    public abstract partial class Card
    {

        public UInt32 Id;
        public String Name;
        public String CardCode;
        public String Description;
        public String FlavorText;
        public string EffectLog = "";
        public UInt16 _set;
        public UInt16 ManaCost;
        public string ImageURL = "http://dd.b.pvp.net/4_0_0/";
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
        protected void LoadLocalImage()
        {
            var SpriteTexture = LoadTexture();
            Image = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0));
        }

        private Texture2D LoadTexture()
        {
            Texture2D Text2D;
            byte[] fileData;

            string currentPath = Application.dataPath;
            string sFile =  currentPath + $"/Sprites/Cards/{CardCode}.png";
            string filePath = Path.GetFullPath(sFile);

            if (System.IO.File.Exists(filePath))
            {
                fileData = System.IO.File.ReadAllBytes(filePath);
                Text2D = new Texture2D(2, 3);
                if(Text2D.LoadImage(fileData))
                    return Text2D;
            }
            return null;
        }
    }
}
