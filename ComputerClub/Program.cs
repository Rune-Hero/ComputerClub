using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ComputerClub.Models;
using ComputerClub.Repositories;

namespace ComputerClub
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Forms.MainForm());
        }
    }
}