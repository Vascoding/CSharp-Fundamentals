using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avatar.Models.Nations
{
    public class AirNation : Nation
    {
        public AirNation(string name) : base(name)
        {
        }
       
        public override double TotalPower()
        {
            var bendersTotalPower = this.Benders.Sum(b => b.TotalPower());
            var monumentsTotalPower = this.Monuments.Sum(a => a.TotalAffinity());
            var procentage = (bendersTotalPower / 100) * monumentsTotalPower;
            return procentage + bendersTotalPower;
        }

        public override string ToString()
        {
            return "Air Nation" + Environment.NewLine + base.ToString();
        }
    }
}