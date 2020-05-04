using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Izone.Helper
{
    public sealed class FirebaseHelper
    {
        private FirebaseClient client;

        private FirebaseHelper()
        {
            client = new FirebaseClient("https://izoneapp-4f52a.firebaseio.com/");
        }

        public async Task<IEnumerable<Model.Member>> GetListMemberAsync()
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
            }).OrderBy(x => x.ID);
        }

        public async Task<IEnumerable<Model.Album>> GetListAlbumAsync()
        {
            return (await client.Child("Albums").OnceAsync<Model.Album>()).Select(x => new Model.Album()
            {
                ID = x.Object.ID,
                Name = x.Object.Name,
                ReleaseDate = x.Object.ReleaseDate,
                ImageUri = x.Object.ImageUri
            }).OrderBy(x => DateTime.ParseExact(x.ReleaseDate, "dd/MM/yyyy", CultureInfo.CurrentCulture));
        }

        public async Task<IEnumerable<Model.Single>> GetListSingleByAlbumAsync(string albumName)
        {
            return (await client.Child("Singles").Child(albumName).OnceAsync<Model.Single>()).Select(x => new Model.Single()
            {
                ID = x.Object.ID,
                Name = x.Object.Name,
                Mp3Uri = x.Object.Mp3Uri,
                Mp4Uri = x.Object.Mp4Uri,
                SingleImage = x.Object.SingleImage
            }).OrderBy(x => x.ID);
        }

        //
        private static readonly object padlock = new object();
        private static FirebaseHelper instance = null;
        public static FirebaseHelper Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FirebaseHelper();
                    }
                    return instance;
                }
            }
        }
    }
}