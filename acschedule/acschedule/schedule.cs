using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acschedule
{
    [Serializable]
    public class ScheduleResource
    {
        //default constructor
        public ScheduleResource()
        {
            classrooms = new List<Room>();
            instructors = new List<Instructor>();
            courses = new List<Course>();
            programs = new List<Program>();
            sections = new List<Section>();
            classes = new List<School_Class>();
        }

        public ScheduleResource(string Description, int SchoolYear_From, int Schoolyear_To, string Semester)
        {
            this.description = Description;
            this.syFrom = SchoolYear_From;
            this.syTo = Schoolyear_To;
            this.semester = Semester;

            classrooms = new List<Room>();
            instructors = new List<Instructor>();
            classes = new List<School_Class>();
            courses = new List<Course>();
            programs = new List<Program>();
            sections = new List<Section>();
        }

        //private fields
        private string description;
        private int syFrom;
        private int syTo;
        private string semester;

        private List<Room> classrooms;
        private List<Instructor> instructors;
        private List<School_Class> classes;
        private List<Course> courses;
        private List<Program> programs;
        private List<Section> sections;


        //public properties
        // native type properties
        public string Description
        {
            get {
                return this.description;
            }
            set {
                this.description = value;
            }
        }
        public int SYFrom
        {
            get {
                return this.syFrom;
            }
            set {
                this.syFrom = value;
            }
        }
        public int SYTo {
            get {
                return this.syTo;
            }
            set {
                this.syTo = value;
            }
        }
        public string Semester
        {
            get
            {
                return this.semester;
            }
            set {
                this.semester = value;
            }
        }

        // object properties

        public List<Room> Rooms
        {
            get {
                return classrooms;
            }
            set {
                classrooms = value;
            }
        }
        public List<Instructor> Instructors
        {
            get {
                return instructors;
            }
            set {
                instructors = value;
            }
        }
        public List<School_Class> Classes
        {
            get {
                return this.classes;
            }
            set {
                this.classes = value;
            }
        }
        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
        public List<Program> Programs
        {
            get
            {
                return this.programs;
            }
            set
            {
                this.programs = value;
            }
        }
        public List<Section> Sections
        {
            get
            {
                return this.sections;
            }
            set
            {
                this.sections = value;
            }
        }

        //methods

        private int FindMaxId()
        {
            if (this.classes.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int maxId = int.MinValue;
            foreach (School_Class sclass in this.classes)
            {
                if (sclass.Id > maxId)
                {
                    maxId = sclass.Id;
                }
            }
            return maxId;
        }

        public bool AddClass(List<Section> Section, Course Course, Instructor Instructor, Room room, DateTime Class_StartTime, DateTime Class_EndTime, string Day, string Class_Type, out int Conflicted_Class)
        {
            bool isnoconflict = false;
            bool result;

            if (this.classes.Count == 0)
            {
                this.classes.Add(new School_Class(1, Section, Course, Instructor, room, Class_StartTime, Class_EndTime, Day, Class_Type));
                Conflicted_Class = 0;
                result = true;
            }
            else
            {
                for (int i = 0; i < this.classes.Count; i++)
			    {
                    for (double x = 1.0; x < new TimeSpan(Class_EndTime.Hour - Class_StartTime.Hour, Class_EndTime.Minute - Class_StartTime.Minute, 0).TotalMinutes; x += 1.0)
			        {
                        if (DateTime.Compare(DateTime.Parse(Class_StartTime.ToShortTimeString()).AddMinutes(x), DateTime.Parse(this.classes[i].Class_TimeStart.ToShortTimeString())) > 0 && DateTime.Compare(DateTime.Parse(Class_StartTime.ToShortTimeString()).AddMinutes(x), DateTime.Parse(this.classes[i].Class_TimeEnd.ToShortTimeString())) < 0)
	                    {
		                    if (Day == this.classes[i].Day)
	                        {
		                        if (room.Name == this.classes[i].Room.Name || Instructor.Identification  == this.classes[i].Instructor.Identification || Section[0].SectionName == this.classes[i].Sections[0].SectionName)
	                            {
		                            result =  false;
                                    Conflicted_Class = i;
                                    return result;
	                            }
                                isnoconflict = true;
	                        }
                            else
	                        {
                                isnoconflict = true;
	                        }
	                    }
			        }
			    }
                if (isnoconflict)
	            {
		            this.classes.Add(new School_Class(FindMaxId()+1, Section, Course, Instructor, room, Class_StartTime, Class_EndTime, Day, Class_Type));
                    Conflicted_Class = 0;
                    result = true;
	            }
                else
	            {
                    this.classes.Add(new School_Class(FindMaxId()+1, Section, Course, Instructor, room, Class_StartTime, Class_EndTime, Day, Class_Type));
                    Conflicted_Class = 0;
                    result = true;
	            }
            }
            return result;      
        }
    }

    public class School_Class
    {
        public School_Class()
        {
            sections = new List<Section>();
        }

        public School_Class(int Id, List<Section> Sections, Course Course, Instructor Instructor, Room Room, DateTime Class_TimeStart, DateTime Class_TimeEnd, string Day, string Class_Type)
        {
            this.id = Id;
            this.sections = Sections;
            this.course = Course;
            this.instructor = Instructor;
            this.room = Room;
            this.class_timeStart = Class_TimeStart;
            this.class_timeEnd = Class_TimeEnd;
            this.day = Day;
            this.classType = Class_Type;
        }

        //private fields
        private int id;
        private List<Section> sections;
        private Course course;
        private Instructor instructor;
        private Room room;
        private DateTime class_timeStart;
        private DateTime class_timeEnd;
        private string day;
        private string classType;


        //public properites
        public int Id
        {
            get {
                return this.id;
            }
        }

        public List<Section> Sections
        {
            get {
                return this.sections;
            }
            set {
                this.sections = value;
            }
        }
        public Course Course
        {
            get {
                return this.course;
            }
            set {
                this.course = value;
            }
        }
        public Instructor Instructor
        {
            get {
                return this.instructor;
            }
            set {
                this.instructor = value;
            }
        }
        public Room Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }
        }
        public DateTime Class_TimeStart
        {
            get
            {
                return this.class_timeStart;
            }
            set
            {
                this.class_timeStart = value;
            }
        }
        public DateTime Class_TimeEnd
        {
            get
            {
                return this.class_timeEnd;
            }
            set
            {
                this.class_timeEnd = value;
            }
        }
        public string Day
        {
            get {
                return this.day;
            }
            set {
                this.day = value;
            }
        }
        public string Class_Type
        {
            get {
                return this.classType;
            }
            set{
                this.classType = value;
            }
        }

        //methods

        public void MergeSection(Section Section_to_be_added)
        {
            this.sections.Add(Section_to_be_added);
        }
    }

    public class Instructor
    {
        //constructors
        public Instructor()
        { }

        public Instructor(string Identification, string FirstName, string LastName, string Email_Address, string DepartmentId, string DepartmentDescription, string UserName, string Password)
        {
            this.id = Identification;
            this.userName = UserName;
            this.password = Password;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.emailAddr = Email_Address;
            this.departmentId = DepartmentId;
            this.departmentDescription = DepartmentDescription;
        }

        // private fields
        private string id;
        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private string emailAddr;
        private string departmentId;
        private string departmentDescription;

        // public properties
        public string Identification
        {
            get {
                return this.id;
            }
            set {
                this.id = value;
            }
        }
        public string UserName
        {
            get {
                return this.userName;
            }
            set {
                this.userName = value;
            }
        }
        public string FirstName
        {
            get {
                return this.firstName;
            }
            set {
                this.firstName = value;
            }
        }  
        public string LastName
        {
            get {
                return this.lastName;
            }
            set {
                this.lastName = value;
            }
        }
        public string Email_Address
        {
            get {
                return this.emailAddr;
            }
            set {
                this.emailAddr = value;
            }
        }
        public string Department_Id
        {
            get {
                return this.departmentId;
            }
            set {
                this.departmentId = value;
            }
        }
        public string Department_Description
        {
            get {
                return this.departmentDescription;
            }
            set {
                this.departmentDescription = value;
            }
        }

        // methods
        public string GetPassword()
        {
            return this.password;
        }
    }

    public class Room
    {
        public Room()
        { }

        public Room(string Name)
        {
            this.name = Name;
            this.rtype = "";
        }
        public Room(string Name, string RoomType)
        {
            this.name = Name;
            this.rtype = RoomType;
        }

        //private fields
        private string name;
        private string rtype;

        //public fields
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string RoomType
        {
            get
            {
                return this.rtype;
            }
            set
            {
                this.rtype = value;
            }
        }

        //methods
        public void Update(string NewName, string NewType)
        {
            this.name = NewName;
            this.rtype = NewType;
        }
    }

    public class Course 
    {
        public Course()
        { }

        public Course(string courseCode, string courseDescription, int Num_of_units)
        {
            this.cursCode = courseCode;
            this.cursDesc = courseDescription;
            this.cursUnits = Num_of_units;
        }

        //fields
        private string cursCode;
        private string cursDesc;
        private int cursUnits;

        //properties
        public string Coursecode
        {
            get {
                return this.cursCode;
            }
            set {
                this.cursCode = value;
            }
        }

        public string CourseDescription
        {
            get
            {
                return this.cursDesc;
            }
            set
            {
                this.cursDesc = value;
            }
        }

        public int Units
        {
            get
            {
                return this.cursUnits;
            }
            set
            {
                this.cursUnits = value;
            }
        }

    }

    public class Program
    {
        public Program()
        { }

        public Program(string programCode, string programDescription, string departmentId)
        {
            this.programcode = programCode;
            this.programdesc = programDescription;
            this.deptid = departmentId;
        }

        //fields
        private string programcode;
        private string programdesc;
        private string deptid;

        //properties
        public string ProgramCode
        {
            get {
                return this.programcode;
            }
            set {
                this.programcode = value;
            }
        }
        public string ProgramDescription
        {
            get
            {
                return this.programdesc;
            }
            set
            {
                this.programdesc = value;
            }
        }
        public string DepartmentId
        {
            get
            {
                return this.deptid;
            }
            set
            {
                this.deptid = value;
            }
        }
    }

    public class Section
    {
        public Section()
        { }

        public Section(string SectionName)
        {
            this.sectionName = SectionName;
            this.progCode = "";
            this.sectionYrLevel = 0;
            this.classDensity = 0;
            courses = new List<Course>();

        }
        public Section(string SectionName,int YearLevel, string ProgramCode, int Class_Density)
        {
            this.sectionName = SectionName;
            this.sectionYrLevel = YearLevel;
            this.progCode = ProgramCode;
            this.classDensity = Class_Density;
            courses = new List<Course>();
        }

        //fields
        private string sectionName;
        private int sectionYrLevel;
        private string progCode;
        private int classDensity;
        private List<Course> courses;


        //properties
        public string SectionName
        {
            get {
                return this.sectionName;
            }
            set {
                this.sectionName = value;
            }
        }
        public int YearLevel
        {
            get {
                return this.sectionYrLevel;
            }
            set {
                sectionYrLevel = value;
            }
        }
        public string ProgramCode
        {
            get
            {
                return this.progCode;
            }
            set
            {
                this.progCode = value;
            }
        }
        public int Class_Density
        {
            get {
                return this.classDensity;
            }
            set {
                this.classDensity = value;
            }
        }
        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
    }

    public class Department
    {
        public Department()
        { }

        public Department(string Department_Id, string Department_Description)
        {
            this.deptid = Department_Id;
            this.deptdesc = Department_Description;
        }

        //private fields
        private string deptid;
        private string deptdesc;

        //properties
        public string DepartmentId
        {
            get {
                return this.deptid;
            }
            set {
                this.deptid = value;
            }
        }
        public string DepartmentDescription
        {
            get
            {
                return this.deptdesc;
            }
            set
            {
                this.deptdesc = value;
            }
        }
    }
}