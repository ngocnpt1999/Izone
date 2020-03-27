﻿using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Izone.Helper
{
    public class FirebaseHelper
    {
        private FirebaseClient client;

        public FirebaseHelper()
        {
            client = new FirebaseClient("https://izoneapp-b4dee.firebaseio.com/");
        }

        public async Task<List<Model.Member>> GetMembersAsync()
        {
            return (await client.Child("Members").OnceAsync<Model.Member>()).Select(x => new Model.Member()
            {
                ID = x.Object.ID,
                Avatar = x.Object.Avatar,
                ImagesUri = x.Object.ImagesUri,
                Birthday = x.Object.Birthday,
                FullName = x.Object.FullName,
                NickName = x.Object.NickName,
                ListRole = x.Object.ListRole,
                Height = x.Object.Height,
                Weight = x.Object.Weight,
                BloodType = x.Object.BloodType
            }).OrderBy(x => x.ID).ToList();
        }

        public async Task<List<Model.Album>> GetAlbumsAsync()
        {
            return (await client.Child("Albums").OnceAsync<Model.Album>()).Select(x => new Model.Album()
            {
                ID = x.Object.ID,
                Name = x.Object.Name,
                ReleaseDate = x.Object.ReleaseDate,
                ImageUri = x.Object.ImageUri
            }).OrderBy(x => DateTime.ParseExact(x.ReleaseDate, "dd/MM/yyyy", CultureInfo.CurrentCulture)).ToList();
        }

        public async Task<List<Model.Single>> GetSinglesAsync()
        {
            return (await client.Child("Singles").OnceAsync<Model.Single>()).Select(x => new Model.Single()
            {
                ID = x.Object.ID,
                IdAlbum = x.Object.IdAlbum,
                Name = x.Object.Name,
                Mp3Uri = x.Object.Mp3Uri
            }).ToList();
        }
    }
}