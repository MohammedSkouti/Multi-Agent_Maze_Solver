using ActressMas;
using Message = ActressMas.Message;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Reactive
{
    public class PlanetAgent : Agent
    {
        private string someoneIsMoving = "";
        private Queue agentsThatWantToMove = new Queue();
        private PlanetForm _formGui;
        private Stopwatch stopwatch = new Stopwatch();
        private bool solved = false;
        public Dictionary<string, string> ExplorerPositions { get; set; }

        public PlanetAgent()
        {
            ExplorerPositions = new Dictionary<string, string>();

            Thread t = new Thread(new ThreadStart(GUIThread));
            t.Start();
        }

        private void GUIThread()
        {
            _formGui = new PlanetForm();
            _formGui.SetOwner(this);
            _formGui.ShowDialog();
            Application.Run();
        }

        public override void Setup()
        {
            Console.WriteLine("Starting " + Name);
            stopwatch.Start();
        }

        public override void Act(Message message)
        {
            Console.WriteLine("\t[{1} -> {0}]: {2}", this.Name, message.Sender, message.Content);

            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters);

            switch (action)
            {
                case "position":
                    HandlePosition(message.Sender, parameters);
                    break;

                case "change":
                    HandleChange(message.Sender, parameters);
                    break;

                case "winner":
                    if (!solved)
                    {
                        solved = true;
                        stopwatch.Stop();
                        long elapsed_time = stopwatch.ElapsedMilliseconds;
                        saveTime(Utils.NoExplorers, Utils.maze.GetLength(0), Utils.maze.GetLength(1), elapsed_time);
                    }

                    if (someoneIsMoving == message.Sender)
                    {
                        FreeOthers();
                    }
                    ExplorerPositions.Remove(message.Sender);
                    break;

                default:
                    break;
            }
            _formGui.UpdatePlanetGUI();
        }

        private void saveTime(int noExplorers, int rows, int columns, long elapsed_time)
        {
            string myfile = @"times.txt";
            using (StreamWriter sw = File.AppendText(myfile))
            {
                sw.WriteLine("noExplorers {0} ", noExplorers);
                sw.WriteLine("maze {0}, {1} ", rows, columns);
                sw.WriteLine("elapsed time {0} ", elapsed_time);
                sw.WriteLine();
            }

            // Opening the file for reading
            using (StreamReader sr = File.OpenText(myfile))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        private void FreeOthers()
        {
            someoneIsMoving = "";
            if (agentsThatWantToMove.Count > 0)
            {
                string agentWaiting = (string)agentsThatWantToMove.Dequeue();
                someoneIsMoving = agentWaiting;
                Send(agentWaiting, "move " + string.Join(" ", ExplorerPositions.Values.Select((elem) => elem.Replace(" ", "-"))));
            }
        }

        private void HandlePosition(string sender, string position)
        {
            ExplorerPositions.Add(sender, position);
            someoneIsMoving = sender;
            Send(sender, "move " + string.Join(" ", ExplorerPositions.Values.Select((elem) => elem.Replace(" ", "-"))));
        }

        private void HandleChange(string sender, string position)
        {
            ExplorerPositions[sender] = position;

            if (someoneIsMoving == sender)
            {
                if (agentsThatWantToMove.Count > 0)
                {
                    FreeOthers();
                    agentsThatWantToMove.Enqueue(sender);
                }
                else Send(sender, "move " + string.Join(" ", ExplorerPositions.Values.Select((elem) => elem.Replace(" ", "-"))));
            }
            else if (someoneIsMoving != "") { 
                agentsThatWantToMove.Enqueue(sender);
            }
            else {
                someoneIsMoving = sender;
                Send(sender, "move " + string.Join(" ", ExplorerPositions.Values.Select((elem) => elem.Replace(" ", "-"))));
            }
        }
    }
}