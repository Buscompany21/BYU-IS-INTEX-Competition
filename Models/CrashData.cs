using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace INTEX2.Models
{
    public class CrashData
    {
        public int Dui { get; set; }
        public int Old { get; set; }
        public int Teen { get; set; }
        public int Drowsy { get; set; }
        public int Distracted { get; set; }
        public int Restraint { get; set; }
        public int Night { get; set; }
        public int Beaver { get; set; }
        public int BoxElder { get; set; }
        public int Cache { get; set; }
        public int Carbon { get; set; }
        public int Daggett { get; set; }
        public int Davis { get; set; }
        public int Duchesne { get; set; }
        public int Emery { get; set; }
        public int Garfield { get; set; }
        public int Grand { get; set; }
        public int Iron { get; set; }
        public int Juab { get; set; }
        public int Kane { get; set; }
        public int Millard { get; set; }
        public int Morgan { get; set; }
        public int Piute { get; set; }
        public int Rich { get; set; }
        public int SaltLake { get; set; }
        public int SanJuan { get; set; }
        public int Sanpete { get; set; }
        public int Sevier { get; set; }
        public int Summit { get; set; }
        public int Tooele { get; set; }
        public int Uintah { get; set; }
        public int Utah { get; set; }
        public int Wasatch { get; set; }
        public int Washington { get; set; }
        public int Wayne { get; set; }
        public int Weber { get; set; }

        public Tensor<int> AsTensor()
        {
            int[] data = new int[]
            {
            Dui, Old, Teen, Drowsy,
            Distracted, Restraint, Night, Beaver,
            BoxElder, Cache, Carbon, Daggett, Davis, Duchesne, Emery, Garfield, Grand, Iron, Juab, Kane, Millard, Morgan, Piute, 
            Rich, SaltLake, SanJuan, Sanpete, Sevier, Summit, Tooele, Uintah, Utah, Wasatch, Washington, Wayne, Weber
            };
            int[] dimensions = new int[] { 1, 8 };
            return new DenseTensor<int>(data, dimensions);
        }

    }
}
