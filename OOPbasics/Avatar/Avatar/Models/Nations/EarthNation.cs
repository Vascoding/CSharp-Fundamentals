using System.Collections.Generic;
using System.Linq;

namespace Avatar.Models.Nations
{
    public class EarthNation : Nation
    {
        public EarthNation(string name) : base(name)
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
            return "Earth Nation\r\n" + base.ToString();
        }
    }
}