﻿using System;
using System.Collections.Generic;

namespace Core.Plugin.Unity.API
{
    internal class User
    {
        public string Username;
        public string Password;
        public string Email;
    }

    internal class UserToken
    {
        public string grant_type;
        public string username;
        public string password;
    }

    internal class Token
    {
        public string access_token;
        public string expires_in;
        public string token_type;
        public string scope;
        public string refresh_token;
}

    internal class File
    {
        public uint Id;
        public string Title;
        public string Description;
        public bool in_store;
        public string file;
        public User user;
        public User owner;
        public FileType file_type;
        public DateTime created;
        public DateTime updated;
    }

    internal class FileType
    {
        public uint id;
        public string label;
        public string descirption;
    }

    internal class FileUpload
    {
        public uint file_type_id;
        public string title;
        public byte[] file;
    }

    internal class FileList
    {
        public uint count;
        public object next;
        public object previous;
        public List<File> results;
    }
}