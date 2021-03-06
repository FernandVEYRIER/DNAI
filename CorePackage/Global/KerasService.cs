﻿using MathNet.Numerics.LinearAlgebra;
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace CorePackage.Global
{
    public static class KerasService
    {
        private static bool IsProcessRunning { get; set; } = false;

        private static string PythonProgram { get; } = ".Keras_loaded_model/python/python";
        
        private static string KerasScript { get; } = ".Keras_loaded_model/keras_restore_machine_learning.py";

        private static Process PythonProcess { get; } = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };

        private static TcpListener Server { get; set; }

        private static TcpClient Client { get; set; }

        private static StreamReader Output { get; set; }

        private static StreamWriter Input { get; set; }

        private static Task ProcessThread { get; set; }

        private static string LastModelLoaded { get; set; }

        private static string LastWeightsLoaded { get; set; }
        
        public static void Init()
        {
            string pythonPath = $"{Entity.Type.Resource.Instance.Directory}/{PythonProgram}";
            string kerasPath = $"{Entity.Type.Resource.Instance.Directory}/{KerasScript}";

            if (!IsProcessRunning && File.Exists(kerasPath))
            {
                IsProcessRunning = true;

                Server = new TcpListener(IPAddress.Loopback, 0);
                Server.Start();

                int port = ((IPEndPoint)Server.LocalEndpoint).Port;

                Debug.WriteLine($"Running server on port {port}");

                PythonProcess.StartInfo.FileName = pythonPath;
                PythonProcess.StartInfo.Arguments = $"\"{kerasPath}\" -p {port}";
                PythonProcess.Start();

                DateTime startTime = DateTime.Now;
                
                while ((DateTime.Now - startTime).Seconds < 10)
                {
                    if (Server.Pending())
                    {
                        Client = Server.AcceptTcpClient();
                        break;
                    }
                    Thread.Sleep(100);
                }

                if (Client == null)
                {
                    throw new SocketException((int)SocketError.TimedOut);
                }
                
                Input = new StreamWriter(Client.GetStream()) { AutoFlush = false };
                Output = new StreamReader(Client.GetStream());

                ProcessThread = Task
                    .Run(() =>
                    {
                        PythonProcess.WaitForExit();
                        Server.Stop();
                    })
                    .ContinueWith(t => IsProcessRunning = false);
            }
        }

        private static string GetData()
        {
            string line = Output.ReadLine();

            if (line.Contains("ERROR: "))
            {
                throw new InvalidOperationException(line);
            }

            return line;
        }

        private static string GetOutputLine()
        {
            return GetData();
        }

        private static string GetError()
        {
            return GetData();
        }

        private static void SendCommand(string command, params string[] args)
        {
            Debug.WriteLine(command);
            Input.WriteLine(command);
            foreach (string arg in args)
            {
                Debug.WriteLine(arg);
                Input.WriteLine(arg);
            }
            Input.Flush();
        }

        public static void LoadModel(string model)
        {
            string path = $"{Entity.Type.Resource.Instance.Directory}/{model}";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Model file not found for prediction: {path}");
            }

            if (!path.Equals(LastModelLoaded))
            {
                SendCommand("LOAD_MODEL", path);
            }
        }

        public static void LoadWeights(string weights)
        {
            string path = $"{Entity.Type.Resource.Instance.Directory}/{weights}";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Weights file not found for prediction: {path}");
            }

            if (!path.Equals(LastWeightsLoaded))
            {
                SendCommand("LOAD_WEIGHTS", path);
            }
        }

        public static Matrix<double> Predict(Matrix<double> inputs, string shape)
        {
            string csvData = Entity.Type.Matrix.Instance.toCSV(inputs);

            SendCommand("PREDICT", $"{inputs.RowCount}", $"{inputs.ColumnCount}", shape, csvData);

            int resultCount = Int32.Parse(GetOutputLine());
            StringBuilder matrixBuilder = new StringBuilder();

            for (int i = 0; i < resultCount; i++)
            {
                matrixBuilder.Append((i == 0 ? "" : "\n") + GetOutputLine());
            }

            return Entity.Type.Matrix.Instance.fromCSV(matrixBuilder.ToString());
        }

        public static void Quit()
        {
            SendCommand("QUIT");
        }
    }
}
