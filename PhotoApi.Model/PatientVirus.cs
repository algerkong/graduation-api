using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace PhotoApi.Model
{
    [MiddleTable]
    public class PatientVirus : TopBasePoco
    {
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public Virus Virus { get; set; }
        public Guid VirusId { get; set; }

    }
}
