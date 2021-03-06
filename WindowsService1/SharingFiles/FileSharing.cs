﻿using RCD.BL;
using RCD.BL.Services;
using RCD.BL.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.WindowsService.SharingFiles
{
    /// <summary>
    /// This class is responsible for the file's transaction
    /// </summary>
    class FileSharing
    {
        #region private variables
        private string _fileName;
        private string _sharedFolder;
        private string _destinationFolder;
        private string _fileExtensionWithoutDot;
        #endregion

        FileService fileService = new FileService();

        /// <summary>
        /// Constructor; initialize the private variables
        /// </summary>
        /// <param name="fileName">Files name</param>
        /// <param name="sharedFolder">Shared folder path</param>
        /// <param name="destinationFolder">Destination folder path</param>
        public FileSharing(string fileName, string sharedFolder, string destinationFolder)
        {
            _fileName                = fileName;
            _fileExtensionWithoutDot = Util.GetFileExtension(_fileName);
            _sharedFolder            = sharedFolder;
            _destinationFolder       = Path.Combine(destinationFolder, _fileExtensionWithoutDot); ;
        }

        #region StartFileProcess
        /// <summary>
        /// Starts the file sharing process
        /// </summary>
        public void StartFileSharingProcess()
        {
            Boolean isAlreadyShared = false;//the file is already shared
            Util.Log(String.Format("FileTypes Created:3 {0}", _fileName));
            string fileFullPath = Path.Combine(_sharedFolder, _fileName);//file location

            string newFileName = _fileName;
            try
            {

                //Create the destination directory if it not exist
                if (!Directory.Exists(_destinationFolder))
                {
                    // Try to create the directory.
                    try
                    {
                        Directory.CreateDirectory(_destinationFolder);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The directory couldn't been created : {0}", e.ToString());
                    }
                }
                else
                {
                    Util.Log(String.Format("FileTypes Created:4 "));
                    string tmpDestinationFile = Path.Combine(_destinationFolder, _fileName);
                    //check if the destination directory has another file with the same name
                    //if is true, check if the files are identical
                    if (File.Exists(tmpDestinationFile))
                    {
                        Util.Log(String.Format("FileTypes Created:5 "));
                        //isAlreadyShared = FileAction.FilesCompare(fileFullPath, tmpDestinationFile);
                        Util.Log(String.Format("FileTypes Created:6 "));
                    }

                    if (!isAlreadyShared)
                    {
                        Util.Log(String.Format("FileTypes Created:7"));
                        newFileName = SetFileName(); //rename the file if the name is already used
                    }

                }

                //if the file is already in destination, delete it from shared directory
                if (isAlreadyShared == true)
                {
                    FileAction.DeleteFile(fileFullPath);
                //Move the file in the destnation direcotry
                } else
                {
                    Util.Log(String.Format("FileTypes Created:9 "));
                    string fullDestinationPath = Path.Combine(_destinationFolder, newFileName);
                    FileAction.MoveFile(fileFullPath, fullDestinationPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        
        /// <summary>
        /// Verify if is another file in the transition folder with the same name
        /// </summary>
        /// <returns>A new name for the file</returns>
        private string SetFileName()
        {
            int count = 0;
            Util.Log(String.Format("FileTypes Created:8 "));
            string tempFileName     = Path.GetFileNameWithoutExtension(_fileName);
            string extensionWithDot = Util.GetFileExtension(_fileName, true);
            string baseNewFullPath  = _destinationFolder;

            string tempDestinationFolder = Path.Combine(_destinationFolder, tempFileName);

            //while there is a file with the same name
            while (File.Exists(tempDestinationFolder + extensionWithDot))
            {
                //change the file name
                tempFileName          = string.Format("{0}({1})", tempFileName, count++);
                tempDestinationFolder = Path.Combine(baseNewFullPath, tempFileName);
            }
            Util.Log(String.Format("FileTypes Created:8 "));
            return tempFileName + extensionWithDot;
        }

    }
}
