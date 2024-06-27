// Encapsulation
class Student {
    constructor(name, age, grade) {
        this._name = name;
        this._age = age;
        this._grade = grade;
    }

    getDetails() {
        return `Name: ${this._name}, Age: ${this._age}, Grade: ${this._grade}`;
    }

    setGrade(newGrade) {
        this._grade = newGrade;
    }
}

// Inheritance
class CollegeStudent extends Student {
    constructor(name, age, grade, major) {
        super(name, age, grade);
        this.major = major;
    }

    getDetails() {
        return `${super.getDetails()}, Major: ${this.major}`;
    }
}

// Polymorphism
class SchoolStudent extends Student {
    constructor(name, age, grade, schoolName) {
        super(name, age, grade);
        this.schoolName = schoolName;
    }

    getDetails() {
        return `${super.getDetails()}, School: ${this.schoolName}`;
    }
}

// Abstraction
class UniversityStudent extends Student {
    constructor(name, age, grade, universityName) {
        super(name, age, grade);
        this.universityName = universityName;
    }

    study() {
        console.log(`${this._name} is studying.`);
    }

    getDetails() {
        return `${super.getDetails()}, University: ${this.universityName}`;
    }
}

const collegeStudent = new CollegeStudent('Alice', 20, 'A', 'Computer Science');
const schoolStudent = new SchoolStudent('Bob', 16, 'B', 'High School');
const universityStudent = new UniversityStudent('Charlie', 22, 'A', 'MIT');

console.log(collegeStudent.getDetails());
console.log(schoolStudent.getDetails());
console.log(universityStudent.getDetails());
universityStudent.study();
  