// Q1:  A Doctor class with details

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Exp { get; set; }
    public string Qualification { get; set; }
    public string Speciality { get; set; }
}

// Q2: Array of doctors

Doctor[] doctors = new Doctor[]
{
    new Doctor { Id = 1, Name = "John Doe", Age = 35, Exp = 10, Qualification = "MD", Speciality = "Cardiology" },
    new Doctor { Id = 2, Name = "Jane Doe", Age = 40, Exp = 12, Qualification = "PhD", Speciality = "Neurology" },
    new Doctor { Id = 3, Name = "Bob Smith", Age = 50, Exp = 20, Qualification = "MD", Speciality = "Oncology" },
    // add more doctors as needed
};

// Q3: Print the array

foreach (Doctor doctor in doctors)
{
    Console.WriteLine($"Id: {doctor.Id}, Name: {doctor.Name}, Age: {doctor.Age}, Exp: {doctor.Exp}, Qualification: {doctor.Qualification}, Speciality: {doctor.Speciality}");
}

// Q4: Given a speciality, print the doctor details in it

string speciality = "Cardiology";

Doctor matchingDoctor = doctors.FirstOrDefault(d => d.Speciality == speciality);

if (matchingDoctor != null)
{
    Console.WriteLine($"Doctor with speciality {speciality}:");
    Console.WriteLine($"Id: {matchingDoctor.Id}, Name: {matchingDoctor.Name}, Age: {matchingDoctor.Age}, Exp: {matchingDoctor.Exp}, Qualification: {matchingDoctor.Qualification}, Speciality: {matchingDoctor.Speciality}");
}
else
{
    Console.WriteLine($"No doctor found with speciality {speciality}.");
}
