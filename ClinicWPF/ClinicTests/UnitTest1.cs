

using ClinicWPF.Models;
using Xunit.Sdk;

namespace ClinicTests
{
    public class UnitTest1
    {
        public ClinicSystemContext Context = new ClinicSystemContext();

        [Fact]
        public void AddPatientToDatabase()
        {
            // Arrange
            var newPatient = new Personal
            {

                Name = "John",
                Surname = "Doe",
                Date = new DateTime(1985, 5, 15),
                Phone = "555-1234",
                Email = "john.doe@example.com",
            };

            // Act
            Context.Personals.Add(newPatient);
            Context.SaveChanges();

            // Assert
            var retrievedPatient = Context.Personals.FirstOrDefault(p => p.Name == "John" && p.Surname == "Doe");
            Assert.NotNull(retrievedPatient);
        }

        [Fact]
        public void PatientCreation()
        {
            //arrange
            var patient = new Patient();

            //var context = new ClinicSystemContext();

            // Act & Assert
            Assert.NotNull(patient);

        }
        [Fact]
        public void DoctorCreation()
        {
            //arrange
            var doctor = new Doctor();

            // Act & Assert
            Assert.NotNull(doctor);

        }
        [Fact]
        public void DoctorSaveChange()
        {

            //arrange
            var doctor = new Doctor();
            var expected = "BamBam";

            //act
            doctor.Name = "BamBam";

            // Act & Assert
            Assert.Equal(expected, doctor.Name);

        }

        [Fact]
        public void AppointmentCreation()
        {
            // Arrange
            var appointment = new Appointment();

            // Act & Assert
            Assert.NotNull(appointment);
        }

        [Fact]
        public void MedicalTestCreation()
        {
            // Arrange
            var medicalTest = new MedicalTest();

            // Act & Assert
            Assert.NotNull(medicalTest);
        }

        [Fact]
        public void PersonalCreation()
        {
            // Arrange
            var personal = new Personal();

            // Act & Assert
            Assert.NotNull(personal);
        }

        [Fact]
        public void TestResultCreation()
        {
            // Arrange
            var testResult = new TestResult();

            // Act & Assert
            Assert.NotNull(testResult);
        }
        [Fact]
        public void AppointmentSaveChange()
        {
            // Arrange
            var appointment = new Appointment();
            var expected = "NewAppointmentName";

            // Act
            appointment.Status = "NewAppointmentName";

            // Assert
            Assert.Equal(expected, appointment.Status);
        }

        [Fact]
        public void MedicalTestSaveChange()
        {
            // Arrange
            var medicalTest = new MedicalTest();
            var expected = "NewMedicalTestName";

            // Act
            medicalTest.Name = "NewMedicalTestName";

            // Assert
            Assert.Equal(expected, medicalTest.Name);
        }

        [Fact]
        public void PersonalSaveChange()
        {
            // Arrange
            var personal = new Personal();
            var expected = "NewPersonalName";

            // Act
            personal.Name = "NewPersonalName";

            // Assert
            Assert.Equal(expected, personal.Name);
        }

        [Fact]
        public void TestResultSaveChange()
        {
            // Arrange
            var testResult = new TestResult();
            var expected = "NewTestResultName";

            // Act
            testResult.Result = "NewTestResultName";

            // Assert
            Assert.Equal(expected, testResult.Result);
        }
    }
}