using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace INTEX2.Models
{
    public class CrashData
    {
        public long Dui { get; set; }
        public long Old { get; set; }
        public long Teen { get; set; }
        public long Drowsy { get; set; }
        public long Distracted { get; set; }
        public long Restraint { get; set; }
        public long Night { get; set; }
        public long Beaver { get; set; }
        public long BoxElder { get; set; }
        public long Cache { get; set; }
        public long Carbon { get; set; }
        public long Daggett { get; set; }
        public long Davis { get; set; }
        public long Duchesne { get; set; }
        public long Emery { get; set; }
        public long Garfield { get; set; }
        public long Grand { get; set; }
        public long Iron { get; set; }
        public long Juab { get; set; }
        public long Kane { get; set; }
        public long Millard { get; set; }
        public long Morgan { get; set; }
        public long Piute { get; set; }
        public long Rich { get; set; }
        public long SaltLake { get; set; }
        public long SanJuan { get; set; }
        public long Sanpete { get; set; }
        public long Sevier { get; set; }
        public long Summit { get; set; }
        public long Tooele { get; set; }
        public long Uintah { get; set; }
        public long Utah { get; set; }
        public long Wasatch { get; set; }
        public long Washington { get; set; }
        public long Wayne { get; set; }
        public long Weber { get; set; }
        public Tensor<long> AsTensor()
        {
            long[] data = new long[]
            {
            Dui, Old, Teen, Drowsy,
            Distracted, Restraint, Night, Beaver,
            BoxElder, Cache, Carbon, Daggett, Davis, Duchesne, Emery, Garfield, Grand, Iron, Juab, Kane, Millard, Morgan, Piute, 
            Rich, SaltLake, SanJuan, Sanpete, Sevier, Summit, Tooele, Uintah, Utah, Wasatch, Washington, Wayne, Weber
            };
            int[] dimensions = new int[] { 1, 36 };
            return new DenseTensor<long>(data, dimensions);
        }

    }
}
