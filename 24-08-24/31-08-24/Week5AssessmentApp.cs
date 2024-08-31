//assembly.conf
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ConsoleApp_6")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ConsoleApp_6")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ef694139-7ca5-47b4-ba60-b8871e9d53ef")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: log4net.Config.XmlConfigurator]

//app.conf
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	</configSections>

	<log4net>
		<!-- File Appender -->
		<appender name="FileAppender" type="log4net.Appender.RollingFileAppender">
			<file value="week4assessment_app_log.log" />
			<appendToFile value="true" />
			<rollingStyle value="Size" />
			<maxSizeRollBackups value="5" />
			<maximumFileSize value="10MB" />
			<staticLogFileName value="true" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
			</layout>
		</appender>

		<!-- Console Appender -->
		<appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
			</layout>
		</appender>

		<!-- Root logger -->
		<root>
			<level value="ALL" />
			<appender-ref ref="FileAppender" />
			<appender-ref ref="ConsoleAppender" />
		</root>
	</log4net>
	<startup>
		<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
	</startup>
</configuration>

//progrm.cs
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_6
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }

    public class HospitalMedication
    {
        public int HospitalID { get; set; }
        public string DoctorName { get; set; }
        public string Medication { get; set; }
        public double Dosage { get; set; }

        public override string ToString()
        {
            return $"[{HospitalID},{DoctorName},{Medication},{Dosage}]";
        }
    }

    public class HospitalMedicationRepo
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=medication_db;Integrated Security=True;";

        public static void Create(HospitalMedication hospitalMedication)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO HospitalMedication (HospitalID, DoctorName, Medication, Dosage) VALUES (@HospitalID, @DoctorName, @Medication, @Dosage)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HospitalID", hospitalMedication.HospitalID);
                    cmd.Parameters.AddWithValue("@DoctorName", hospitalMedication.DoctorName);
                    cmd.Parameters.AddWithValue("@Medication", hospitalMedication.Medication);
                    cmd.Parameters.AddWithValue("@Dosage", hospitalMedication.Dosage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new ServerException($"[0104] Server Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ServerException($"[0105] Error: {ex.Message}");
            }
        }

        public static void Update(HospitalMedication hospitalMedication)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE HospitalMedication SET HospitalID = @HospitalID, DoctorName = @DoctorName, Medication = @Medication, Dosage = @Dosage WHERE HospitalID = @HospitalID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HospitalID", hospitalMedication.HospitalID);
                    cmd.Parameters.AddWithValue("@DoctorName", hospitalMedication.DoctorName);
                    cmd.Parameters.AddWithValue("@Medication", hospitalMedication.Medication);
                    cmd.Parameters.AddWithValue("@Dosage", hospitalMedication.Dosage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new ServerException($"[0106] Server Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ServerException($"[0107] Error: {ex.Message}");
            }
        }

        public static void Delete(int hospitalID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM HospitalMedication WHERE HospitalID = @HospitalID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HospitalID", hospitalID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new ServerException($"[0108] Server Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ServerException($"[0109] Error: {ex.Message}");
            }
        }

        public static void Read(HospitalMedication[] hospitalMedications)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT HospitalID, DoctorName, Medication, Dosage FROM HospitalMedication";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    int index = 0;
                    while (reader.Read() && index < hospitalMedications.Length)
                    {
                        hospitalMedications[index++] = new HospitalMedication
                        {
                            HospitalID = (int)reader["HospitalID"],
                            DoctorName = reader["DoctorName"].ToString(),
                            Medication = reader["Medication"].ToString(),
                            Dosage = (double)reader["Dosage"]
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ServerException($"[0102] Server Error: {ex.Message}");
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServerException($"[0103] Server Error: {ex.Message}");
            }
        }

        public static void SelectionSort(HospitalMedication[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] != null && (array[minIndex] == null || string.Compare(array[j].Medication, array[minIndex].Medication, StringComparison.Ordinal) < 0))
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    HospitalMedication temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        public static HospitalMedication FindSecondLeastDosage(HospitalMedication[] hospitalMedications)
        {
            if (hospitalMedications.Length < 2) return null;

            HospitalMedication leastDosage = null;
            HospitalMedication secondLeastDosage = null;

            foreach (var hospitalMedication in hospitalMedications)
            {
                if (hospitalMedication != null)
                {
                    if (leastDosage == null || hospitalMedication.Dosage < leastDosage.Dosage)
                    {
                        secondLeastDosage = leastDosage;
                        leastDosage = hospitalMedication;
                    }
                    else if (secondLeastDosage == null || hospitalMedication.Dosage < secondLeastDosage.Dosage)
                    {
                        if (hospitalMedication.Dosage > leastDosage.Dosage)
                        {
                            secondLeastDosage = hospitalMedication;
                        }
                    }
                }
            }

            return secondLeastDosage;
        }

        public static HospitalMedication FindHighestDosageByDoctor(HospitalMedication[] hospitalMedications, string doctorName)
        {
            if (hospitalMedications.Length == 0) return null;

            HospitalMedication highestDosage = hospitalMedications[0];
            foreach (var hospitalMedication in hospitalMedications)
            {
                if (hospitalMedication != null && hospitalMedication.DoctorName == doctorName && hospitalMedication.Dosage > highestDosage.Dosage)
                {
                    highestDosage = hospitalMedication;
                }
            }

            return highestDosage;
        }
    }

    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create HospitalMedication");
                Console.WriteLine("2. Update HospitalMedication");
                Console.WriteLine("3. Delete HospitalMedication");
                Console.WriteLine("4. Find Highest Dosage by Doctor");
                Console.WriteLine("5. Find Second Least Dosage");
                Console.WriteLine("6. Sort HospitalMedications by Medication");
                Console.WriteLine("7. Read HospitalMedications");
                Console.WriteLine("8. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 8)
                {
                    break;
                }

                HospitalMedication[] hospitalMedications = new HospitalMedication[100];

                switch (choice)
                {
                    case 1:
                        CreateHospitalMedication();
                        break;
                    case 2:
                        UpdateHospitalMedication();
                        break;
                    case 3:
                        DeleteHospitalMedication();
                        break;
                    case 4:
                        ReadAllHospitalMedications(hospitalMedications);
                        FindHighestDosage(hospitalMedications);
                        break;
                    case 5:
                        ReadAllHospitalMedications(hospitalMedications);
                        FindSecondLeastDosage(hospitalMedications);
                        break;
                    case 6:
                        ReadAllHospitalMedications(hospitalMedications);
                        SortHospitalMedications(hospitalMedications);
                        break;
                    case 7:
                        ReadAllHospitalMedications(hospitalMedications);
                        break;
                    default:
                        log.Warn("Invalid choice");
                        break;
                }
            }
        }

        private static void CreateHospitalMedication()
        {
            Console.Write("Enter Hospital ID: ");
            int hospitalID = int.Parse(Console.ReadLine());
            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter Medication: ");
            string medication = Console.ReadLine();
            Console.Write("Enter Dosage (mg): ");
            double dosage = double.Parse(Console.ReadLine());

            HospitalMedication hospitalMedication = new HospitalMedication
            {
                HospitalID = hospitalID,
                DoctorName = doctorName,
                Medication = medication,
                Dosage = dosage
            };

            try
            {
                HospitalMedicationRepo.Create(hospitalMedication);
                log.Info("HospitalMedication created successfully.");
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }

        private static void UpdateHospitalMedication()
        {
            Console.Write("Enter Hospital ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter new Doctor Name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter new Medication: ");
            string medication = Console.ReadLine();
            Console.Write("Enter new Dosage (mg): ");
            double dosage = double.Parse(Console.ReadLine());

            HospitalMedication hospitalMedication = new HospitalMedication
            {
                HospitalID = id,
                DoctorName = doctorName,
                Medication = medication,
                Dosage = dosage
            };

            try
            {
                HospitalMedicationRepo.Update(hospitalMedication);
                log.Info("HospitalMedication updated successfully.");
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }

        private static void DeleteHospitalMedication()
        {
            Console.Write("Enter Hospital ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                HospitalMedicationRepo.Delete(id);
                log.Info("HospitalMedication deleted successfully.");
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }

        private static void FindHighestDosage(HospitalMedication[] hospitalMedications)
        {
            Console.Write("Enter Doctor name: ");
            string doctorName = Console.ReadLine();

            try
            {
                HospitalMedication highestDosage = HospitalMedicationRepo.FindHighestDosageByDoctor(hospitalMedications, doctorName);
                if (highestDosage != null)
                {
                    log.Info($"Highest Dosage by Doctor: {highestDosage.ToString()}");
                }
                else
                {
                    log.Info("No hospital medications found for this doctor.");
                }
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }

        private static void FindSecondLeastDosage(HospitalMedication[] hospitalMedications)
        {
            try
            {
                HospitalMedication secondLeastDosage = HospitalMedicationRepo.FindSecondLeastDosage(hospitalMedications);
                if (secondLeastDosage != null)
                {
                    log.Info($"Second Least Dosage: {secondLeastDosage.ToString()}");
                }
                else
                {
                    log.Info("Not enough data to determine the second least dosage.");
                }
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }

        private static void SortHospitalMedications(HospitalMedication[] hospitalMedications)
        {
            try
            {
                HospitalMedicationRepo.SelectionSort(hospitalMedications);
                log.Info("HospitalMedications sorted by medication.");
                foreach (var hospitalMedication in hospitalMedications)
                {
                    if (hospitalMedication != null)
                    {
                        log.Info(hospitalMedication.ToString());
                    }
                }
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }

        private static void ReadAllHospitalMedications(HospitalMedication[] hospitalMedications)
        {
            try
            {
                HospitalMedicationRepo.Read(hospitalMedications);
                log.Info("HospitalMedications read successfully.");
                foreach (var hospitalMedication in hospitalMedications)
                {
                    if (hospitalMedication != null)
                    {
                        log.Info(hospitalMedication.ToString());
                    }
                }
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
        }
    }
}

//test code
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week4AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_6;

namespace Week4AssessmentApp.Tests
{
    [TestClass()]
    public class HospitalMedicationRepoTests
    {
        [TestMethod()]
        public void FindSecondLeastDosage_Test()
        {
            HospitalMedication[] hospitalMedications = new HospitalMedication[3];
            HospitalMedicationRepo.Read(hospitalMedications);
            HospitalMedication expected = new HospitalMedication
            {
                HospitalID = 2,
                DoctorName = "Dr. Smith",
                Medication = "Aspirin",
                Dosage = 500
            };
            HospitalMedication actual = HospitalMedicationRepo.FindSecondLeastDosage(hospitalMedications);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void FindHighestDosageByDoctor_Test()
        {
            HospitalMedication[] hospitalMedications = new HospitalMedication[3];
            HospitalMedicationRepo.Read(hospitalMedications);
            HospitalMedication expected = new HospitalMedication
            {
                HospitalID = 1,
                DoctorName = "Dr. Jones",
                Medication = "Ibuprofen",
                Dosage = 800
            };
            HospitalMedication actual = HospitalMedicationRepo.FindHighestDosageByDoctor(hospitalMedications, "Dr. Jones");
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void SelectionSort_Test()
        {
            HospitalMedication[] hospitalMedications = new HospitalMedication[3];
            HospitalMedicationRepo.Read(hospitalMedications);
            HospitalMedication expected = new HospitalMedication
            {
                HospitalID = 3,
                DoctorName = "Dr. Brown",
                Medication = "Paracetamol",
                Dosage = 500
            };
            HospitalMedicationRepo.SelectionSort(hospitalMedications);
            HospitalMedication actual = hospitalMedications[0];
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}



//SQL query

 create database medication_db
 use medication_db

 CREATE TABLE Hospitals (
    HospitalID INT PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE TABLE Medications (
    MedicationID INT PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE TABLE HospitalMedications (
    HospitalMedicationID INT PRIMARY KEY,
    HospitalID INT,
    DoctorID INT,
    MedicationID INT,
    Dosage DECIMAL(10, 2),
    FOREIGN KEY (HospitalID) REFERENCES Hospitals(HospitalID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (MedicationID) REFERENCES Medications(MedicationID)
);

INSERT INTO Hospitals (HospitalID, Name)
VALUES
    (1, 'Hospital A'),
    (2, 'Hospital B'),
    (3, 'Hospital C');

INSERT INTO Doctors (DoctorID, Name)
VALUES
    (1, 'Dr. John Smith'),
    (2, 'Dr. Jane Doe'),
    (3, 'Dr. Bob Johnson');

INSERT INTO Medications (MedicationID, Name)
VALUES
    (1, 'Aspirin'),
    (2, 'Ibuprofen'),
    (3, 'Paracetamol');

INSERT INTO HospitalMedications (HospitalMedicationID, HospitalID, DoctorID, MedicationID, Dosage)
VALUES
    (1, 1, 1, 1, 100.00),
    (2, 1, 1, 2, 200.00),
    (3, 1, 2, 3, 50.00),
    (4, 2, 2, 1, 150.00),
    (5, 2, 3, 2, 250.00),
    (6, 3, 1, 3, 75.00),
    (7, 3, 2, 1, 120.00),
    (8, 3, 3, 2, 300.00);

    SELECT * FROM HospitalMedications;

    SELECT * FROM Hospitals WHERE Name = 'Hospital A';

    SELECT SUM(Dosage) FROM HospitalMedications WHERE MedicationID = 1;
