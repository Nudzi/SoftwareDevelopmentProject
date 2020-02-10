using Agency.Helpers;
using Agency.Models;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Agency
{
    public class FirebaseService : IFirebaseService
    {
        private static string _apiKey = "AIzaSyCpqmoF7QHwqyj9m2RYHLJUnKAMgz1KQAg";
        private static string _bucket = "agency2020app-dfc0d.appspot.com";
        private static string _authEmail = "agency2020app@gmail.com";
        private static string _authPassword = "Lozinka12345";

        public async Task<List<string>> AddRange(string path, IList<IFormFile> files)
        {
            List<string> links = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    //Firebase Auth
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(_authEmail, _authPassword);

                    //Cancellation Token
                    var cancellation = new CancellationTokenSource();

                    //Uploading File
                    var upload = new FirebaseStorage(
                        _bucket,
                        new FirebaseStorageOptions()
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true
                        })
                    .Child(path)
                    .Child(file.FileName)
                    .PutAsync(file.OpenReadStream(), cancellation.Token);

                    try
                    {
                        links.Add(await upload);
                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine("Custom Error:" + err);
                        throw;
                    }

                }
                else
                    return links;
            }
            return links;
        }


        public async Task<ResponseMessage> RemoveRange(string path, IList<string> fileNames)
        {
            List<string> links = new List<string>();
            foreach (var fileName in fileNames)
            {
                if (fileName.Length > 0)
                {
                    //Firebase Auth
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(_authEmail, _authPassword);

                    //Cancellation Token
                    var cancellation = new CancellationTokenSource();

                    //Uploading File
                    var upload = new FirebaseStorage(
                        _bucket,
                        new FirebaseStorageOptions()
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true
                        })
                    .Child(path)
                    .Child(fileName)
                    .DeleteAsync();


                    try
                    {
                        await upload;
                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine("Custom Error:" + err);
                        throw;
                    }

                }
                else
                    return new ResponseMessage("Removed all pictures successfuly!", true);
            }
            return new ResponseMessage("Something went wrong while removing the pictures!", false);
        }
    }


}
