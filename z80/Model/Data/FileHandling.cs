﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using z80.ViewModel;

namespace z80.Model.Data
{
    public static class FileHandling
    {
        public static void handleFile(string path, RegistersViewModel _vm, ConsoleViewModel _cvm)
        {
            try
            {
                path = path.Replace(@"\", @"/");
                StreamReader sr = new StreamReader(path);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                string[] inpArr;
                while (str != null)
                {
                    //z80class.ProcessFile(sr.ReadLine());
                    inpArr = str.Split(' ');
                    z80commands.defaultCommand(inpArr, _vm, _cvm);
                    str = sr.ReadLine();
                }
                sr.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e + ", " +path);
            }
            
        }
    }
}
