
using RCD.BL.Utils;
using RCD.DAL.Repositories;
using RCD.DAL.ViewModel;
using RCD.Model;
using System.Collections.Generic;
using System.IO;
using System;

namespace RCD.BL.Services
{
    public class MetadataService
    {

        public static void AddMetadata(FileInfo fileInfo, int fileId)
        {

            string ext = Util.GetFileExtension(fileInfo.Extension);

            List<string> txt = new List<string> { "Length", "Name", "CreationTime", "IsReadOnly", "LastAccessTime", "LastWriteTime", "Attributes"};
            List<string> jpg = new List<string> { "Length", "Name", "CreationTime", "IsReadOnly", "LastAccessTime", "LastWriteTime", "Attributes" };
            List<string> pdf = new List<string> { "Length", "Name", "CreationTime", "IsReadOnly", "LastAccessTime", "LastWriteTime", "Attributes" };

            //if the set of metadatas for the new extension does not exist in the database use the defaultList of metadata
            List<string> defaultList = new List<string> { "Length", "Name", "CreationTime", "IsReadOnly", "LastAccessTime", "LastWriteTime", "Attributes"};


            //all the metadata extensions
            Dictionary<string, List<string>> extensions = new Dictionary<string, List<string>>() {
       { "default", defaultList},
                { "txt", txt },
                { "jpg", jpg},
                { "pdf", pdf}

            };
            ext = extensions.ContainsKey(ext) ? ext : "default";
            foreach (string metadataTypeName in extensions[ext])
            {
                var metadata = new Model.Metadata();
                metadata.Value = ReflectPropertyValuefileInfo(fileInfo, metadataTypeName).ToString();

                RepositoryMetadata.SaveMetadataToDb(metadata, GetMetadataTypeId(metadataTypeName), fileId);
            }
        }

        public static void SaveMetadataIntoDb(Metadata metadata, string metadataTypeName, int fileId)
        {
            RepositoryMetadata.SaveMetadataToDb(metadata, GetMetadataTypeId(metadataTypeName), fileId);
        }

        public static List<Metadata> GetMetadaForFile(DAL.ViewModel.FileViewModel file)
        {
            return null;
        }

        //get the value of the object property
        private static object ReflectPropertyValuefileInfo(FileInfo source, string property)
        {
            return source.GetType().GetProperty(property).GetValue(source, null);
        }
        
        public static int GetMetadataTypeId(string metadataTypeName)
        {
            return MetadataTypeService.GetMetadataTypeById(metadataTypeName);
        }

        public static List<Metadata> GetMetadataByType(int metadataTypeId)
        {
            return RepositoryMetadata.GetMetadataByType(metadataTypeId);
        }

        public static List<Metadata> GetAllMetadaForFile()
        {
            return RepositoryMetadata.GetAllMetadataFiles();
        }
      }
    }


