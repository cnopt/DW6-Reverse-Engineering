﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers.Binary;

class Program

{
    

    static void Main()
    {
        R();
    }

    static void R()
    {
        string file = @"C:\Users\TTGCh\Desktop\dw6-saves\new-save.dat";
        int numBytes = 4;
        byte[] test = new byte[numBytes];

        // To read data at specific byte: Address = Seek offset + number of bytes
        // i.e. to get data at offset 100 = Seek offset 99, as number of bytes is set to 1
        // if changing the size of bytes, adjust offset up or down
        // holy shit i finally figured it out
        // was using reader.read(), was giving me a random fucking idiot number.
        // even reversing the endianness was still giving out random shit
        // tried converting to int16/int32 AFTER read(), was still giving the same result. 
        // reserved the endianness WHILE ALSO reading it as an int16 gave out -26330, which is
        // 9981 in big endian. so i reversed and back and bam, 9881 returned
        // seems like officer XP could start at index 3052. previously it was around 4700
        // as i thought it started at zhao yun, but looks like it might start with the Wei officers


        using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
        {
            int baseStart = 3052;
            for (int i = 0; i < 10000; i++)
            {
                reader.BaseStream.Seek(baseStart+i, SeekOrigin.Begin);
                reader.Read(test, 0, 4);
                Console.WriteLine(reader.ReadInt32());
                i = i + 167;
            }

            /*
            reader.BaseStream.Seek(4736, SeekOrigin.Begin);     // where to start reading from 
            reader.Read(test, 0, 4);                            // number of bytes to read
            int zhaoYunKillsVal = reader.ReadInt32(); // this has two extra bytes of 0's so might be stored as an int32 to allow for huge values

            reader.BaseStream.Seek(4732, SeekOrigin.Begin);
            reader.Read(test, 0, 4);
            int zhaoYunXP = reader.ReadInt32(); // also a 32bit int

            reader.BaseStream.Seek(4726, SeekOrigin.Begin);
            reader.Read(test, 0, 2);
            int zhaoYunTitle = reader.ReadInt16();

            reader.BaseStream.Seek(4730, SeekOrigin.Begin);
            reader.Read(test, 0, 2);
            int zhaoYunLevel = reader.ReadInt16();

            // offset between XP = 168????
            reader.BaseStream.Seek(4900, SeekOrigin.Begin);
            reader.Read(test, 0, 4);
            int guanYuXP = reader.ReadInt32();

            // 5068 = next officer xp??
            reader.BaseStream.Seek(5068, SeekOrigin.Begin);
            reader.Read(test, 0, 4);
            int zhangFeiXP = reader.ReadInt32();
        

            reader.BaseStream.Seek(5236, SeekOrigin.Begin);
            reader.Read(test, 0, 4);
            int zhugeLiangXP = reader.ReadInt32();
            */
       



            
        }

        // read all
        //FileStream fs = new FileStream(file, FileMode.Open);
        //int hexIn;
        //String hex;
        //
        //for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
        //{
        //    hex = string.Format("{0:X2}", hexIn);
        //    Console.Write(hex);   
        //}






        while (true) ;
    }
}

