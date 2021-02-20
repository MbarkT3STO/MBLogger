using System;
using System.IO;
using System.Xml.Linq;
using MBLogger.Enums;
using MBLogger.Log.Options;

namespace MBLogger.Log.Builders
{
    static class LogFileBuilder
    {

        /// <summary>
        /// Create a new file to logged into
        /// </summary>
        /// <param name="logFileOptions">The file options</param>
        /// <returns></returns>
        public static void BuildLog(LogFileOptions logFileOptions)
        {

                                             if (!File.Exists(logFileOptions.Path))
                                             {
                                                 switch (logFileOptions.FileFormat)
                                                 {
                                                     case LogFileFormat.Text:
                                                          BuildText(logFileOptions.Path);
                                                         break; 
                                                     case LogFileFormat.Json:
                                                          BuildText(logFileOptions.Path);
                                                         break;
                                                     case LogFileFormat.Xml:
                                                          BuildXml(logFileOptions.Path);
                                                         break;
                                                 }
                                             }
                                        
        }


        /// <summary>
        /// Build a new <b>Text</b> file
        /// </summary>
        /// <param name="path">The file name/path</param>
        /// <returns></returns>
        private static void BuildText(string path)
        {

            using var stream = new StreamWriter(path);

        }


        /// <summary>
        /// Build a new <b>Json</b> file
        /// </summary>
        /// <param name="path">The file name/path</param>
        /// <returns></returns>
        private static void BuildJson(string path)
        {

            using var stream = new StreamWriter(path);

        }
        
        
        /// <summary>
        /// Build a new <b>Xml</b> file
        /// </summary>
        /// <param name="path">The file name/path</param>
        /// <returns></returns>
        private static void BuildXml(string path)
        {

                                             if (!IsFileExists(path))
                                             {

                                                 var xDoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                                                          new XElement("Root",
                                                                              new XElement("CreationDate",
                                                                                  DateTime.Now
                                                                                  .ToString("MM/dd/yyyy hh:mm:ss")))
                                                                         );
                                                 xDoc.Save(path);


                                             }

                                     
        }




        /// <summary>
        /// Check if the log file is already exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFileExists(string path) => File.Exists(path);

        /// <summary>
        /// Get the file extension
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string GetFileExtension(string path) => Path.GetExtension(path);
    }
}
