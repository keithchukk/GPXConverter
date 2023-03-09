using GPXConverter.Helper;
using GPXConverter.Model;
using Newtonsoft.Json;
using System.Globalization;
using System.Xml;

namespace CsvToGpxConverter
{
    class Program
    {
        public static string _outPutPath = "";
        public static string _processedPath = "";

        static void Main(string[] args)
        {
            try
            {
                CreateFolder();

                string exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string[] csvFiles = Directory.GetFiles(exeDir, "*.csv");


                Console.WriteLine($"{csvFiles.Length} csv file(s) detected.");
                int _OK = 0;
                int _errorCount = 0;

                foreach (string csvFile in csvFiles)
                {

                    string fileName = Path.GetFileName(csvFile);
                    string FileNameNoExt = fileName.Split('.')[0];
                    string _OutFileName = $"{FileNameNoExt}.{DateTime.Now.ToString("HHmmssffff")}.gpx";
                    string _OutPutPath = Path.Combine(_outPutPath, _OutFileName);

                    Console.WriteLine($"Processing : {csvFile}");
                    List<GpxPoint> points = ParseCsvToGpx(csvFile);

                    if (points.Count > 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        WriteGpxFile2(points, _OutPutPath, FileNameNoExt);
                        Console.WriteLine($"OutPut : {_OutPutPath}");
                        _OK++;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Skipped : {csvFile} - no GPS point");
                        _errorCount++;
                    }


                    string sourceFile = csvFile;
                    string destinationFolder = _processedPath;

                    string destFile = Path.Combine(destinationFolder, Path.GetFileName(sourceFile));

                    File.Move(sourceFile, destFile);
                    Console.ResetColor();
                }
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine($"{_OK} file(s) OK");
                Console.WriteLine($"{_errorCount} file(s) NOT OK");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"Press any key to continue...");
                Console.Read();
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void CreateFolder()
        {
            string folderName = "OUTPUT";
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);

            _outPutPath = folderPath;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string folderName2 = "PROCESSED";
            string folderPath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName2);

            _processedPath = folderPath2;
            if (!Directory.Exists(folderPath2))
            {
                Directory.CreateDirectory(folderPath2);
            }
        }

        static List<GpxPoint> ParseCsvToGpx(string csvFilePath)
        {
            try
            {
                var _dt = CSVHelper.Convert(csvFilePath);
                string json = JsonConvert.SerializeObject(_dt);

                var _lstRaw = JsonConvert.DeserializeObject<List<EdgeTX_TBS_CrossFire>>(json);

                List<EdgeTX_TBS_CrossFire> _Converted = new List<EdgeTX_TBS_CrossFire>();

                if (_lstRaw != null && _lstRaw.Any())
                {
                    foreach (var eaRaw in _lstRaw)
                    {
                        // 2023-02-19 15:49:57.250
                        string format = "yyyy-MM-dd HH:mm:ss.fff";
                        string strDatetime = eaRaw.Date + " " + eaRaw.Time;
                        DateTime dateTime = DateTime.ParseExact(strDatetime, format, CultureInfo.InvariantCulture);
                        eaRaw._DateTime = dateTime;
                        eaRaw.Altitude = double.Parse(eaRaw.Altm);
                        
                        string _mixGPS = eaRaw.GPS; // 3.169202 101.580497 dont ask, this is edgetx output, dont bother
                        if (!String.IsNullOrEmpty(_mixGPS))
                        {
                            eaRaw.Longitude = double.Parse(_mixGPS.Split(" ")[1]);
                            eaRaw.Latitude = double.Parse(_mixGPS.Split(" ")[0]);
                            _Converted.Add(eaRaw);
                        }
                    }
                }

                List<GpxPoint> gpxPoints = new List<GpxPoint>();

                foreach (var eaConverted in _Converted.OrderBy(x => x._DateTime).ToList())
                {
                    GpxPoint point = new GpxPoint();
                    point.Latitude = eaConverted.Latitude;
                    point.Longitude = eaConverted.Longitude;
                    point.Time = eaConverted._DateTime;
                    point.Altitude = eaConverted.Altitude;
                    gpxPoints.Add(point);
                }
                return gpxPoints;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        static void WriteGpxFile2(List<GpxPoint> points, string gpxFilePath, string TrackName)
        {
            try
            {
                using (var writer = XmlWriter.Create(gpxFilePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("gpx", "http://www.topografix.com/GPX/1/1");
                    writer.WriteAttributeString("version", "1.1");
                    writer.WriteAttributeString("creator", "CsvToGpxConverter");

                    writer.WriteStartElement("trk");

                    if (!string.IsNullOrEmpty(TrackName))
                    {
                        writer.WriteElementString("name", TrackName);
                    }

                    writer.WriteStartElement("trkseg");

                    foreach (var point in points)
                    {
                        writer.WriteStartElement("trkpt");
                        writer.WriteAttributeString("lat", point.Latitude.ToString(CultureInfo.InvariantCulture));
                        writer.WriteAttributeString("lon", point.Longitude.ToString(CultureInfo.InvariantCulture));
                        writer.WriteElementString("ele", point.Altitude.ToString(CultureInfo.InvariantCulture));
                        writer.WriteElementString("time", point.Time.ToString("yyyy-MM-ddTH:mm:ssZ", CultureInfo.InvariantCulture));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void WriteGpxFile2(List<GpxPoint> points, string gpxOutFilePath)
        {
            WriteGpxFile2(points, gpxOutFilePath, "");
        }
    }

  
}
