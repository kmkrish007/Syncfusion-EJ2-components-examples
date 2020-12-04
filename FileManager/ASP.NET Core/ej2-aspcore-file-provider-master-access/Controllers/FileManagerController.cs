using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Syncfusion.EJ2.FileManager.Base;

namespace EJ2APIServices.Controllers
{
    public class FileManagerDirectoryContent1
    {
        public FileManagerDirectoryContent[] Data { get; set; }
        public bool ShowHiddenItems { get; set; }
        public string SearchString { get; set; }
        public bool CaseSensitive { get; set; }
        public IList<IFormFile> UploadFiles { get; set; }
        public string[] RenameFiles { get; set; }
        public string TargetPath { get; set; }
        public string ParentId { get; set; }
        public string FilterId { get; set; }
        public string FilterPath { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public bool IsFile { get; set; }
        public bool HasChild { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string PreviousName { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public string[] Names { get; set; }
        public string NewName { get; set; }
        public string Action { get; set; }
        public string Path { get; set; }
        public string role { get; set; }
        public FileManagerDirectoryContent TargetData { get; set; }
        public AccessPermission Permission { get; set; }
    }

    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class FileManagerController : Controller
    {
        public PhysicalFileProvider operation;
        public string basePath;
        string root = "wwwroot\\Files";
        public FileManagerController(IHostingEnvironment hostingEnvironment)
        {
            this.basePath = hostingEnvironment.ContentRootPath;
            this.operation = new PhysicalFileProvider();
            this.operation.RootFolder(this.basePath + "\\" + this.root);
          
        }
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerDirectoryContent1 args)
        {
            this.operation.SetRules(GetRules(args.role));
            if (args.Action == "delete" || args.Action == "rename")
            {
                if ((args.TargetPath == null) && (args.Path == ""))
                {
                    FileManagerResponse response = new FileManagerResponse();
                    response.Error = new ErrorDetails { Code = "401", Message = "Restricted to modify the root folder." };
                    return this.operation.ToCamelCase(response);
                }
            }
            switch (args.Action)
            {
                case "read":
                    // reads the file(s) or folder(s) from the given path.
                    return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "delete":
                    // deletes the selected file(s) or folder(s) from the given path.
                    return this.operation.ToCamelCase(this.operation.Delete(args.Path, args.Names));
                case "copy":
                    // copies the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                    return this.operation.ToCamelCase(this.operation.Copy(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "move":
                    // cuts the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                    return this.operation.ToCamelCase(this.operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "details":
                    // gets the details of the selected file(s) or folder(s).
                    return this.operation.ToCamelCase(this.operation.Details(args.Path, args.Names, args.Data));
                case "create":
                    // creates a new folder in a given path.
                    return this.operation.ToCamelCase(this.operation.Create(args.Path, args.Name));
                case "search":
                    // gets the list of file(s) or folder(s) from a given path based on the searched key string.
                    return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                case "rename":
                    // renames a file or folder.
                    return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName));
            }
            return null;
        }

        // uploads the file(s) into a specified path
        [Route("Upload")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action, string role)
        {
            this.operation.SetRules(GetRules(role));
            FileManagerResponse uploadResponse;
            uploadResponse = operation.Upload(path, uploadFiles, action, null);
            if (uploadResponse.Error != null)
            {
               Response.Clear();
               Response.ContentType = "application/json; charset=utf-8";
               Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
               Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
            }
            return Content("");
        }

        // downloads the selected file(s) and folder(s)
        [Route("Download")]
        public IActionResult Download(string downloadInput)
        {
            FileManagerDirectoryContent1 args = JsonConvert.DeserializeObject<FileManagerDirectoryContent1>(downloadInput);
            this.operation.SetRules(GetRules(args.role));
            return operation.Download(args.Path, args.Names, args.Data);
        }

        // gets the image(s) from the given path
        [Route("GetImage")]
        public IActionResult GetImage(FileManagerDirectoryContent1 args)
        {
            this.operation.SetRules(GetRules(args.role));
            return this.operation.GetImage(args.Path, args.Id,false,null, null);
        }
        public AccessDetails GetRules(string args)
        {
            AccessDetails accessDetails = new AccessDetails();
            List<AccessRule> accessRules = new List<AccessRule> {
                // For Default User
                new AccessRule { Path = "/*.*", Role = "Default User", Read = Permission.Deny, Write = Permission.Deny, Copy = Permission.Deny, Download = Permission.Deny, IsFile = true },
                // For Administrator
                new AccessRule { Path = "/*.*", Role = "Administrator", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Allow, Download = Permission.Allow, IsFile = true },
                // For Document Manager
                new AccessRule { Path = "/*.*", Role = "Document Manager", Read = Permission.Deny, Write = Permission.Deny, Copy = Permission.Deny, Download = Permission.Deny, IsFile = true },
                new AccessRule { Path = "/Documents/*.*", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Allow, Download = Permission.Allow, IsFile = true },
                new AccessRule { Path = "/*.png", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Deny, Copy = Permission.Deny, Download = Permission.Deny, IsFile = true },
                new AccessRule { Path = "/Documents/*.png", Role = "Document Manager", Read = Permission.Deny, Write = Permission.Allow, Copy = Permission.Deny, Download = Permission.Allow, IsFile = true },
                new AccessRule { Path = "/2.*", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Deny, Download = Permission.Deny, IsFile = true },
                new AccessRule { Path = "/Documents/2.*", Role = "Document Manager", Read = Permission.Deny, Write = Permission.Deny, Copy = Permission.Deny, Download = Permission.Allow, IsFile = true },
                new AccessRule { Path = "/2.png", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Deny, Download = Permission.Allow, IsFile = true },
                new AccessRule { Path = "/Documents/2.png", Role = "Document Manager", Read = Permission.Deny, Write = Permission.Deny, Copy = Permission.Deny, Download = Permission.Deny, IsFile = true },
                new AccessRule { Path = "/text", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Deny, Download = Permission.Allow, IsFile = true },
                new AccessRule { Path = "/Documents/text", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Deny, Copy = Permission.Deny, Download = Permission.Deny, IsFile = true },
           
                // For Default User
                new AccessRule { Path = "*", Role = "Default User", Read = Permission.Deny, Write = Permission.Deny, Copy = Permission.Deny, WriteContents = Permission.Deny, Upload = Permission.Deny, Download = Permission.Deny, IsFile = false },
                new AccessRule { Path = "/", Role = "Default User", Read = Permission.Allow, Write = Permission.Deny, Copy = Permission.Deny, WriteContents = Permission.Deny, Upload = Permission.Deny, Download = Permission.Deny, IsFile = false },
                // For Administrator
                new AccessRule { Path = "*", Role = "Administrator", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Allow, WriteContents = Permission.Allow, Upload = Permission.Allow, Download = Permission.Deny, IsFile = false },
                new AccessRule { Path = "/", Role = "Administrator", Read = Permission.Allow, Write = Permission.Deny, Copy = Permission.Allow, WriteContents = Permission.Allow, Upload = Permission.Allow, Download = Permission.Deny, IsFile = false },
                // For Document Manager
                new AccessRule { Path = "*", Role = "Document Manager", Read = Permission.Deny, Write = Permission.Deny, Copy = Permission.Deny, WriteContents = Permission.Deny, Upload = Permission.Deny, Download = Permission.Deny, IsFile = false },
                new AccessRule { Path = "/", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Deny, Copy = Permission.Deny, WriteContents = Permission.Deny, Upload = Permission.Deny, Download = Permission.Deny, IsFile = false },
                new AccessRule { Path = "/Documents", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Deny, Copy = Permission.Allow, WriteContents = Permission.Allow, Upload = Permission.Allow, Download = Permission.Deny, IsFile = false },
                new AccessRule { Path = "/Documents/*", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Allow, WriteContents = Permission.Allow, Upload = Permission.Allow, Download = Permission.Allow, IsFile = false },
                new AccessRule { Path = "/Music.png", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Allow, WriteContents = Permission.Allow, Upload = Permission.Allow, Download = Permission.Allow, IsFile = false },
                new AccessRule { Path = "/Documents/Music.png", Role = "Document Manager", Read = Permission.Allow, Write = Permission.Allow, Copy = Permission.Allow, WriteContents = Permission.Allow, Upload = Permission.Deny, Download = Permission.Deny, IsFile = false },
            };
            accessDetails.AccessRules = accessRules;
            accessDetails.Role = args;
            return accessDetails;
        }

    }

}
