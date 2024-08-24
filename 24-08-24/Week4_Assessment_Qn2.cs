Problem Statement: Advanced Inheritance and Interface in Patient Care System
- Define a base class: `CareProvider` with properties:
- `ProviderID` (integer), `ProviderName` (string)
- Method: `ProvideCare()` (virtual, void)
- Define an interface: `IEmergencyResponder` with the following method:
- `RespondToEmergency()` (void)
- Define a derived class: `Nurse` that inherits from `CareProvider` and implements `IEmergencyResponder`:
- Additional Property: `ShiftTiming` (string)
- Implement `ProvideCare()` to display care provided during the shift.
- Implement `RespondToEmergency()` to handle emergency situations.
- Define another derived class: `Doctor` that also inherits from `CareProvider` and implements `IEmergencyResponder`:
- Additional Property: `Specialization` (string)
- Implement `ProvideCare()` to display care based on specialization.
- Implement `RespondToEmergency()` to handle critical emergency situations.
- Tasks:
1. Care Management:
- Read details for N `careProviders` (both Nurses and Doctors).
2. Emergency Response:
- Implement a method to simulate an emergency and call `RespondToEmergency()` for each care provider.
3. Care Providing:
- Display details of care provided by each provider using the overridden `ProvideCare()` method.
  
  
  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessementFourthWeek
{
    class CareProvider
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }

        public virtual void ProvideCare()
        {
            Console.WriteLine("Provide Care...");
        }
    }

    interface IEmergencyResponder
    {
        void RespondToEmergency();
    }

    class Nurse : CareProvider, IEmergencyResponder
    {
        public string ShiftTiming { get; set; }

        public override void ProvideCare()
        {
            Console.WriteLine($"Care provided during {ShiftTiming} shift.");
        }

        public void RespondToEmergency()
        {
            Console.WriteLine("Nurse is in emergency.");
        }
    }

    class Doctor : CareProvider, IEmergencyResponder
    {
        public string Specialization { get; set; }

        public override void ProvideCare()
        {
            Console.WriteLine($"Providing specialized care in {Specialization}.");
        }

        public void RespondToEmergency()
        {
            Console.WriteLine("Doctor is in critical emergency.");
        }
    }

    class PatientCareSystem
    {
        static void Main()
        {
            Console.WriteLine("Enter Number of Care providers : ");
            int N = int.Parse(Console.ReadLine()); // Number of care providers
            CareProvider[] careProviders = new CareProvider[N];

            // Reading details for care providers
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Enter details for care provider " + (i + 1));
                Console.Write("Provider ID: ");
                int providerID = int.Parse(Console.ReadLine());
                Console.Write("Provider Name: ");
                string providerName = Console.ReadLine();
                Console.WriteLine("Nurse/Doctor :");
                string providerType = Console.ReadLine();

                if (providerType.ToLower() == "nurse") // Create a Nurse
                {
                    Console.Write("Shift Timing: ");
                    string shiftTiming = Console.ReadLine();
                    careProviders[i] = new Nurse { ProviderID = providerID, ProviderName = providerName, ShiftTiming = shiftTiming };
                }
                else // Create a Doctor
                {
                    Console.Write("Specialization: ");
                    string specialization = Console.ReadLine();
                    careProviders[i] = new Doctor { ProviderID = providerID, ProviderName = providerName, Specialization = specialization };
                }
            }

            // Simulating an emergency
            Console.WriteLine("\nEmergency has occurred!");
            foreach (CareProvider provider in careProviders)
            {
                if (provider is IEmergencyResponder responder)
                {
                    responder.RespondToEmergency();
                }
            }

            // Displaying care provided
            Console.WriteLine("\nCare provided by each provider:");
            foreach (CareProvider provider in careProviders)
            {
                provider.ProvideCare();
            }
        }
    }
}


Enter Number of Care providers :
3
Enter details for care provider 1
Provider ID: 234
Provider Name: athulya
Nurse/Doctor :
Nurse
Shift Timing: 5
Enter details for care provider 2
Provider ID: 345
Provider Name: david
Nurse/Doctor :
doctor
Specialization: eye
Enter details for care provider 3
Provider ID: 333
Provider Name: das
Nurse/Doctor :
doctor
Specialization: ear

Emergency has occurred!
Nurse is in emergency.
Doctor is in critical emergency.
Doctor is in critical emergency.

Care provided by each provider:
Care provided during 5 shift.
Providing specialized care in eye.
Providing specialized care in ear.
Press any key to continue . . .
