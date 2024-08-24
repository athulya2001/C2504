Problem Statement: Hospital Medication Management
- Define a class: `HospitalMedication` with the following properties:
- `HospitalID` (integer)
- `DoctorName` (string)
- `Medication` (string)
- `Dosage` (double, in milligrams)
- Tasks:
1. Data Entry:
- Read N `hospitalMedications` from the keyboard.
2. Find Maximum Dosage by a Specific Doctor:
- For a given doctor's name, display the medication with the highest dosage prescribed by them.
Solve in time complexity of O(N).
Dont use built-in C# sorting or LINQ.
3. Find Second Least Dosage Overall:
- Display the medication with the second least dosage across all hospitals.
Solve in time complexity of O(N).
Dont use built-in C# sorting or LINQ.
4. Sort by Medication Name:
- Implement and call your own sorting algorithm.
Dont use built-in C# sorting or LINQ.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessementFourthWeek
{
    public class HospitalMedication
    {
        public int HospitalID { get; set; }
        public string DoctorName { get; set; }
        public string Medication { get; set; }
        public double Dosage { get; set; }
    }

    public class ReadHosptitalMedication
    {
        public HospitalMedication[] medications;

        public ReadHosptitalMedication(int N)
        {
            medications = new HospitalMedication[N];
        }

        public void ReadMedications()
        {
            for (int i = 0; i < medications.Length; i++)
            {
                medications[i] = new HospitalMedication();

                Console.Write("Enter Hospital ID: ");
                medications[i].HospitalID = int.Parse(Console.ReadLine());

                Console.Write("Enter Doctor Name: ");
                medications[i].DoctorName = Console.ReadLine();

                Console.Write("Enter Medication: ");
                medications[i].Medication = Console.ReadLine();

                Console.Write("Enter Dosage (mg): ");
                medications[i].Dosage = double.Parse(Console.ReadLine());
            }
        }

        public HospitalMedication FindHighestDosageByDoctor(string doctorName)
        {
            HospitalMedication maxDosageMedication = null;
            double maxDosage = double.MinValue;

            foreach (var medication in medications)
            {
                if (medication.DoctorName == doctorName && medication.Dosage > maxDosage)
                {
                    maxDosage = medication.Dosage;
                    maxDosageMedication = medication;
                }
            }

            return maxDosageMedication;
        }

        public HospitalMedication FindSecondLeastDosage()
        {
            HospitalMedication leastDosageMedication = null;
            HospitalMedication secondLeastDosage = null;

            foreach (var medication in medications)
            {
                if (leastDosageMedication == null || medication.Dosage < leastDosageMedication.Dosage)
                {
                    secondLeastDosage = leastDosageMedication;
                    leastDosageMedication = medication;
                }
                else if (secondLeastDosage == null || medication.Dosage < secondLeastDosage.Dosage)
                {
                    secondLeastDosage = medication;
                }
            }

            return secondLeastDosage;
        }

        public void SortMedicationsByName()
        {
            // Implementing selection sorting algorithm here
            for (int i = 0; i < medications.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < medications.Length; j++)
                {
                    if (string.Compare(medications[j].Medication, medications[minIndex].Medication, StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Swap elements
                HospitalMedication temp = medications[i];
                medications[i] = medications[minIndex];
                medications[minIndex] = temp;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the number of hospital medications: ");
            int N = int.Parse(Console.ReadLine());


            ReadHosptitalMedication manager = new ReadHosptitalMedication(N);
            manager.ReadMedications();

            Console.WriteLine("Enter Doctor name:");
            string doctorName = Console.ReadLine();

            HospitalMedication highestDosageMedication = manager.FindHighestDosageByDoctor(doctorName);
            Console.WriteLine("Medication with highest dosage:");
            Console.WriteLine($"Medication: {highestDosageMedication.Medication}");
            Console.WriteLine($"Dosage: {highestDosageMedication.Dosage} mg");

            HospitalMedication secondLeastDosageMedication = manager.FindSecondLeastDosage();
            Console.WriteLine("Medication with second least dosage:");
            Console.WriteLine($"Medication: {secondLeastDosageMedication.Medication}");
            Console.WriteLine($"Dosage: {secondLeastDosageMedication.Dosage} mg");

            manager.SortMedicationsByName();
            Console.WriteLine("Sorted medications by name:");
            foreach (var medication in manager.medications)
            {
                Console.WriteLine($"Medication: {medication.Medication}, Dosage: {medication.Dosage} mg");
            }
        }
    }
}


  
Enter the number of hospital medications: 3
Enter Hospital ID: 234
Enter Doctor Name: athulya
Enter Medication: wef
Enter Dosage (mg): 45
Enter Hospital ID: 234
Enter Doctor Name: athulya
Enter Medication: erf
Enter Dosage (mg): 50
Enter Hospital ID: 456
Enter Doctor Name: raj
Enter Medication: erf
Enter Dosage (mg): 60
Enter Doctor name:
athulya
Medication with highest dosage:
Medication: erf
Dosage: 50 mg
Medication with second least dosage:
Medication: erf
Dosage: 50 mg
Sorted medications by name:
Medication: erf, Dosage: 50 mg
Medication: erf, Dosage: 60 mg
Medication: wef, Dosage: 45 mg
Press any key to continue . . .
