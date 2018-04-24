using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Hospital
    {
        public int Room { get; set; }
        public int Bed { get; set; }
        public HashSet<string> Patient { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hospital> hospital = new Dictionary<string, Hospital>();
            Dictionary<string, HashSet<string>> patients = new Dictionary<string, HashSet<string>>();
            Dictionary<string, Dictionary<int, HashSet<string>>> rooms = new Dictionary<string, Dictionary<int, HashSet<string>>>();
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0].Equals("Output"))
                {
                    break;
                }
                var department = input[0];
                var doctor = input[1] + " " + input[2];
                var patient = input[3];
                if (!hospital.ContainsKey(department))
                {
                    hospital.Add(department, new Hospital
                    {
                        Bed = 0,
                        Room = 0,
                        Patient = new HashSet<string>()
                    });
                }
                if (hospital[department].Room <= 20)
                {
                    hospital[department].Patient.Add(patient);
                    
                    if (hospital[department].Bed % 3 == 0)
                    {
                        hospital[department].Room++;
                    }
                    hospital[department].Bed++;
                }

                if (!patients.ContainsKey(doctor))
                {
                    patients.Add(doctor, new HashSet<string>());
                    patients[doctor].Add(patient);
                }
                else
                {
                    patients[doctor].Add(patient);
                }

            }
            foreach (var h in hospital)
            {
                var r = 1;
                var p = 0;
                foreach (var v in h.Value.Patient)
                {
                    
                    if (r < 20)
                    {
                        if (p >= 3)
                        {
                            r++;
                            p = 0;
                        }
                        if (!rooms.ContainsKey(h.Key))
                        {
                            rooms.Add(h.Key, new Dictionary<int, HashSet<string>>());
                        }
                        if (!rooms[h.Key].ContainsKey(r))
                        {
                            rooms[h.Key].Add(r, new HashSet<string>());
                        }
                        rooms[h.Key][r].Add(v);
                    }
                    p++;
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (command[0].Equals("End"))
                {
                    break;
                }

                if (command.Length == 2)
                {
                    int num;
                    int.TryParse(command[1], out num);
                    if (char.IsDigit(command.Last().Last()))
                    {
                        foreach (var h in rooms.Where(k => k.Key == command[0]))
                        {
                            foreach (var v in h.Value.Where(a => a.Key == num))
                            {
                                foreach (var k in v.Value.OrderBy(a => a))
                                {
                                    Console.WriteLine($"{k}");
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var h in patients.Where(k => k.Key == command[0] + " " + command[1]))
                        {
                            foreach (var v in h.Value.OrderBy(a => a))
                            {
                                Console.WriteLine($"{v}");
                            }
                        }
                    }
                }
                else
                {
                    foreach (var h in rooms.Where(k => k.Key == command[0]))
                    {
                        foreach (var v in h.Value)
                        {
                            foreach (var s in v.Value)
                            {
                                Console.WriteLine($"{s}");
                            }
                        }
                    }
                }

            }
        }
    }
}
